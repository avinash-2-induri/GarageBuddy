﻿namespace GarageBuddy.Web.Areas.Admin.Controllers
{
    using System.Net;

    using AutoMapper;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Contracts;
    using Services.Data.Models.Vehicle.FuelType;

    using ViewModels.Admin.FuelType;

    [Authorize(Policy = Policies.ManagerPolicy)]
    public class FuelTypeController : AdminController
    {
        private readonly IFuelTypeService fuelTypeService;

        private readonly IMapper mapper;

        public FuelTypeController(
            IHtmlSanitizer sanitizer,
            IFuelTypeService fuelTypeService,
            IMapper mapper) : base(sanitizer)
        {
            this.fuelTypeService = fuelTypeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await this.fuelTypeService.GetAllAsync();
            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FuelTypeCreateOrEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            SanitizeModel(model);
            var serviceModel = mapper.Map<FuelTypeServiceModel>(model);
            var result = await this.fuelTypeService.CreateAsync(serviceModel);

            if (!result.Succeeded)
            {
                var errors = string.Join(Environment.NewLine, result.Messages);
                ModelState.AddModelError(string.Empty, errors);
                TempData[NotifyError] = errors;
                return View(model);
            }

            TempData[NotifySuccess] = string.Format(Success.SuccessfullyCreatedEntity, "Fuel type");
            return RedirectToAction(Actions.Index);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.fuelTypeService.ExistsAsync(id))
            {
                return ShowError(string.Format(Errors.EntityNotFound, "Fuel type"), (int)HttpStatusCode.NotFound);
            }

            var fuelTypeResult = await this.fuelTypeService.GetAsync(id);
            var model = mapper.Map<FuelTypeCreateOrEditViewModel>(fuelTypeResult.Data);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FuelTypeCreateOrEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            SanitizeModel(model);
            var serviceModel = mapper.Map<FuelTypeServiceModel>(model);
            var result = await this.fuelTypeService.EditAsync(id, serviceModel);

            if (!result.Succeeded)
            {
                var errors = string.Join(Environment.NewLine, result.Messages);
                ModelState.AddModelError(string.Empty, errors);
                TempData[NotifyError] = errors;
            }

            TempData[NotifySuccess] = string.Format(Success.SuccessfullyEditedEntity, "Fuel type");
            return RedirectToAction(Actions.Index);
        }
    }
}
