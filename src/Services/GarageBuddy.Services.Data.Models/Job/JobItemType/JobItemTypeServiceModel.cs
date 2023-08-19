﻿namespace GarageBuddy.Services.Data.Models.Job.JobItemType
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Base;

    using GarageBuddy.Data.Models.Job;

    using Mapping;

    using static GarageBuddy.Common.Constants.EntityValidationConstants.JobItemType;

    public class JobItemTypeServiceModel : BaseListServiceModel, IMapFrom<JobItemType>, IMapTo<JobItemType>
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(JobTypeNameMaxLength, MinimumLength = JobTypeNameMinLength)]
        public string JobTypeName { get; set; } = null!;
    }
}
