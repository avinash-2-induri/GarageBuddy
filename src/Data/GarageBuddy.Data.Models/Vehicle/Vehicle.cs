﻿namespace GarageBuddy.Data.Models.Vehicle
{
    using static GarageBuddy.Common.Constants.EntityValidationConstants.Vehicle;

    public class Vehicle : BaseDeletableModel<Guid>
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid BrandId { get; set; }

        public Guid? BrandModelId { get; set; }

        [MaxLength(VehicleVinNumberMaxLength)]
        public string? VehicleIdentificationNumber { get; set; }

        [MaxLength(VehicleRegistrationNumberMaxLength)]
        public string? RegistrationNumber { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? DateOfManufacture { get; set; }

        public int? FuelTypeId { get; set; }

        public int? GearboxTypeId { get; set; }

        public int? DriveTypeId { get; set; }

        public int? EngineCapacity { get; set; }

        public int? EngineHorsePower { get; set; }

        [MaxLength(DefaultDescriptionMaxLength)]
        public string? Description { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = null!;

        [ForeignKey(nameof(BrandModelId))]
        public BrandModel? BrandModel { get; set; } = null!;

        [ForeignKey(nameof(FuelTypeId))]
        public FuelType? FuelType { get; set; }

        [ForeignKey(nameof(GearboxTypeId))]
        public GearboxType? GearboxType { get; set; }

        [ForeignKey(nameof(DriveTypeId))]
        public DriveType? DriveType { get; set; }
    }
}
