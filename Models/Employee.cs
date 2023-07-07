using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3OT.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string DeptName { get; set; }
        public bool isActive { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Department")]
        public int FKDeptId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public Department Department { get; set; }
    }
}
