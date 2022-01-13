using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPr
{
    class Program
    {
        private delegate bool myDeleget<in T>(T obj );
        static void Main(string[] args)
        {

            myDeleget<Course> filterDelget;
            myDeleget<Course> deleget;
            List<Course> courses = new List<Course>();
            Course c1 = new Course
            {
                CourseName = "c#",
                CourseRepresnting = new Course.Student
                {
                    name = "mostfa",
                    marks = new List<int> { 100, 90, 85 }
                }
            };
            Course c2 = new Course
            {
                CourseName = "java",
                CourseRepresnting = new Course.Student
                {
                    name = "mohamed",
                    marks = new List<int> { 80, 90, 85 }
                }
            };
            Course c3 = new Course
            {
                CourseName = "network",
                CourseRepresnting = new Course.Student
                {
                    name = "daniel",
                    marks = new List<int> { 100, 75, 85 }
                }
            };
            courses.Add(c1);
            courses.Add(c2);
            courses.Add(c3);
            Console.WriteLine("enter p/P to show the avarges above 60 or # to see the c# courses or all the courses that are not c# ");
            string st = ((string)Console.ReadLine());
            switch (st)
            {

                case "p":
                case "P":
                    filterDelget = course => course.CourseRepresnting.marks.Average() >= 60;
             
                    break;
                case "#":
                    filterDelget= course =>  course.CourseName.Equals ("c#") ;
                    break;
                default:
                    filterDelget = course => course.CourseRepresnting.marks.Contains(100);
                    break;
            }

            var q1Result = Q1(courses, filterDelget).ToList();
            var q1InvokeResult = courses.Except(q1Result).ToList();
            Console.WriteLine(courses[1].ShowGrade(0));
            Console.WriteLine(courses[2].ShowGrade(2));
            printQ1(q1Result, q1InvokeResult);
   
            Console.WriteLine();
            Q2(courses);
            Console.WriteLine();
            Console.ReadKey();


        }
        public static void Display2(IEnumerable<Course.Student> result) {
            Console.WriteLine("above 90");
            foreach (Course.Student element in result)
            {
                Console.WriteLine("{0}  , {1}", element.name,string.Join("  ", element.marks))  ;
                
            }
        }



        public static void Display(IEnumerable<Course> result)
        {
            
            foreach (Course element in result) Console.WriteLine("{0},   {1},     {2}", element.CourseName, element.CourseRepresnting.name,string.Join("  ",element.CourseRepresnting.marks)) ;
           
        }
        private static void printQ1(IEnumerable<Course> result, IEnumerable<Course> invertlist) {
            Console.WriteLine("Q1 result");
            Console.WriteLine("false");
            Console.WriteLine("_________________");
            Display(invertlist);
            Console.WriteLine();
            Console.WriteLine(true);
            Console.WriteLine("_________________");
            Display(result);
        }
        
       private static IEnumerable <T> Q1<T>( IEnumerable<T> courses,myDeleget<T> filterde)
        {
            return from item in courses where filterde(item) select item;
            
        }
        public static void Q2(List<Course> courses)
        {
            var s = from i in courses  from m in i.CourseRepresnting.marks where m >= 60 && i.CourseRepresnting.marks.Average() >= 90 select i.CourseRepresnting ;
            Display2(s);
        }
       
   
        }
    }


    
    

