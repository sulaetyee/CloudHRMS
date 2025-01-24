using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CloudHRMS.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public required string Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public required char Gender { get; set; }
        public required DateTime DOB { get; set; }
        public required DateTime DOE { get; set; }
        public DateTime? DOR { get; set; }
        public required string Address { get; set; }

        public required decimal BasicSalary { get; set; }
        public required string Phone { get; set; }

        public required string DepartmentId { get; set; }
        public string DepartmentInfo { get; set; }
        public required string PositionId { get; set; }
        public string PositionInfo { get; set; }

    }
}
