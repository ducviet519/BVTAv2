
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public decimal Rate { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
    public class DepartmentDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class EmployeeDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DepartmentDto Department { get; set; }
    }
}
