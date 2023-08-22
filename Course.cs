using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many_to_many_Relation
{
    internal class Course
    {
        [Key]
       
        public int CourseId { get; set;}
        public string CourseName { get; set; }  
        
        public ICollection<Student> Students { get; set; }


    }
}
