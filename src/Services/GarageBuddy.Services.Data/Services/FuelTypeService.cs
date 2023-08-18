﻿namespace GarageBuddy.Services.Data.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using GarageBuddy.Data.Common.Repositories;
    using GarageBuddy.Data.Models.Vehicle;

    using Microsoft.EntityFrameworkCore;

    using Models.Vehicle.FuelType;

    public class FuelTypeService : BaseService<FuelType, int>, IFuelTypeService
    {
        private readonly IDeletableEntityRepository<FuelType, int> fuelTypeRepository;

        public FuelTypeService(
            IDeletableEntityRepository<FuelType, int> entityRepository,
            IMapper mapper)
            : base(entityRepository, mapper)
        {
            this.fuelTypeRepository = entityRepository;
        }

        public async Task<ICollection<FuelTypeServiceModel>> GetAllAsync()
        {
            var query = this.fuelTypeRepository
                .All(ReadOnlyOption.ReadOnly, DeletedFilter.Deleted)
                .ProjectTo<FuelTypeServiceModel>(this.Mapper.ConfigurationProvider)
                .OrderBy(d => d.IsDeleted)
                .ThenBy(b => b.Id);

            return await query.ToListAsync();
        }

        public async Task<ICollection<FuelTypeSelectServiceModel>> GetAllSelectAsync()
        {
            return await fuelTypeRepository.All(ReadOnlyOption.ReadOnly, DeletedFilter.Deleted)
                .OrderBy(b => b.IsDeleted)
                .ThenBy(b => b.FuelName)
                .Select(b => new FuelTypeSelectServiceModel
                {
                    Id = b.Id,
                    FuelName = b.FuelName,
                }).ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await fuelTypeRepository.ExistsAsync(id);
        }

        public async Task<IResult<FuelTypeServiceModel>> GetAsync(int id)
        {
            if (!await ExistsAsync(id))
            {
                return await Result<FuelTypeServiceModel>.FailAsync(string.Format(Errors.EntityNotFound, "Fuel type"));
            }

            var model = await base.GetAsync<FuelTypeServiceModel>(id);
            return await Result<FuelTypeServiceModel>.SuccessAsync(model);
        }

        public async Task<IResult<int>> CreateAsync(FuelTypeServiceModel model)
        {
            return await CreateBasicAsync(model, "Fuel type");
        }

        public async Task<IResult> EditAsync(int id, FuelTypeServiceModel model)
        {
            return await base.EditAsync(id, model, "Fuel type");
        }
    }
}
