using System.ComponentModel.DataAnnotations;

namespace CloudHRMS.Models.DataModels
{
    public abstract class BaseEntity
    {
        [Key] //model attribute to assign Id as primary key
        [MaxLength(36)] //model attribute to set the maximum length of the Id to 36
        public required string Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; } // ? means this is nullable property
        public string? UpdatedBy { get; set; }
        public required string Ip { get; set; }
        public required bool IsActive { get; set; } //soft delete

    }
}
