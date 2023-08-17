﻿namespace GarageBuddy.Data.Models.Vehicle
{
    using static GarageBuddy.Common.Constants.EntityValidationConstants.GearboxType;

    public class GearboxType : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(GearboxTypeNameMaxLength)]
        public string GearboxTypeName { get; set; } = null!;
    }
}
