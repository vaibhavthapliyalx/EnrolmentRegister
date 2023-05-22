using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolment_Register
{
    static class e_Data
    { 
        // public static List structure for storing list of Students (Student objects)
        public static List<Student> s_List = new List<Student>();

        // Globals for storing course details
        public static string courseName, courseLecturer;
        public static double coursePCF, coursePCM, coursePCO;
    }
}
