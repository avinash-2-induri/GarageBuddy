﻿namespace GarageBuddy.Services.Data.Models
{
    using System;

    using AutoMapper;

    using Base;

    using GarageBuddy.Data.Models;

    using Mapping;

    public class GarageServiceModel : BaseListServiceModel, IMapFrom<Garage>, IMapTo<Garage>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? ImageUrl { get; set; }

        public string? WorkingHours { get; set; }

        public string? Description { get; set; }

        public string? Coordinates { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<GarageServiceModel, Garage>()
                .ForMember(d => d.Id,
                    opt => opt.Ignore());
        }
    }
}
