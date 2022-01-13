using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPr
{
    class Course
    { 

        public string CourseName { get; set; }
        public Student CourseRepresnting { get; set; }
       
        internal class Student {    
        public string name { get; set; }
        public List<int> marks { get; set; }
            
        }
        public int ShowGrade(int i)
        {
            return this.CourseRepresnting.marks[i];
        }


    }
}
