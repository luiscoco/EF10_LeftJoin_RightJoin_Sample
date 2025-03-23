using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_LeftJoin_RightJoin_Sample.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string? Name { get; set; } = null!;
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
