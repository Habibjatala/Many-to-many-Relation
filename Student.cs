using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many_to_many_Relation
{
    internal class Student
    {
        [Key]
        public int StudnetId { get; set; }  
        public string StudentName { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
