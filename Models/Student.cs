using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_LeftJoin_RightJoin_Sample.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? DepartmentID { get; set; }

        public Department? Department { get; set; }
    }
}
