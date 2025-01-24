using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMS.Models.DataModels
{
    [Table("Employee")] //Model Attribute in MVC (build Employee Table in database)
    public class EmployeeEntity : BaseEntity
    {

        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        [MaxLength(1)] //gender has maximun length 1
        public required char Gender { get; set; }
        public required DateTime DOB { get; set; }
        public required DateTime DOE { get; set; }
        public DateTime? DOR { get; set; }
        public required string Address { get; set; }
        [Precision(18, 2)] //Model attribute BasicSalary has been set to maximum number of integer number 18 and 2 decimal numbers.
        public required decimal BasicSalary { get; set; }
        public required string Phone { get; set; }
        //Foreign Key in here
        [ForeignKey(nameof(DepartmentId))] //[ForeignKey("DepartmentId")]
        public required string DepartmentId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public required string PositionId { get; set; }
    }
}
