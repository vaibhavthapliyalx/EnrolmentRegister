using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Enrolment_Register
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // On form load, (a) list box is populated with list of students from StudentDetails.txt
            // and (b) course name and course lecturer are populated from CourseDetails.txt
            
            string courseRec, studentRec;
            string[] studentRecArray, courseRecArray;
            
            StreamReader CourseFile, StudentFile;
            CourseFile = File.OpenText(@"C:\temp\CourseDetails.txt");       // Do not change these file locations
            StudentFile = File.OpenText(@"C:\temp\StudentDetails.txt");     // Do not change these file locations

            while ( CourseFile.EndOfStream == false)
            {
                courseRec = CourseFile.ReadLine();
                courseRecArray = courseRec.Split(',');
                e_Data.courseName = courseRecArray[0];
                e_Data.courseLecturer = courseRecArray[1];
            }
             

            while (StudentFile.EndOfStream == false)
            {
                studentRec = StudentFile.ReadLine();
                studentRecArray = studentRec.Split(',');
                Student s = new Student();
                s.name = studentRecArray[0];
                s.dob = studentRecArray[1];
                s.address = studentRecArray[2];
                s.gender = studentRecArray[3];
                e_Data.s_List.Add(s);
                e_Data.s_List.Capacity = 20;     // only 20 students can be added to the list
                // Create new student object and add data from studentRecArray to object

            }

            RefreshListBox();

            CourseFile.Close();
            StudentFile.Close();

        }

        private void RefreshListBox()
        {
            String line = "";
            lstStudents.Items.Clear();
            foreach (Student s in e_Data.s_List)
            {
                line = s.name + "," + s.dob + "," + s.address + "," + s.gender;
                lstStudents.Items.Add(line);
            }    
                                 // refresh listbox using each Student s in e_Data.s_List
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add ad = new Add();
            ad.ShowDialog();
            RefreshListBox();
            // create instance of the Add form class and display

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] det;
            string r, rn;
            if (lstStudents.SelectedIndex == -1)
            {
                MessageBox.Show("Please select student to delete");
            }
            else
            {
                r = lstStudents.SelectedItem.ToString();
                det = r.Split(',');
                rn = det[0];
          
                foreach (Student s in e_Data.s_List)
                {
                    if (s.name==rn)                                   // Iterate over each Student s in e_Data.s_List and 
                    {
                        e_Data.s_List.Remove(s);
                        break;
                    }
                }      // check if it matches the selected student.
            }
            RefreshListBox();  // refreshing listbox to update items in it
         }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter outputFile = new StreamWriter(@"C:\temp\StudentDetails.txt"))
            {
                foreach (Student s in e_Data.s_List)
                { 
                    string st = s.name + "," + s.dob + "," + s.address + "," + s.gender;
                    outputFile.WriteLine(st);
                }
            }


            // Write student details to file
            // Must be of format:
            // name,DOB,address,gender

            using (StreamWriter outputFile = new StreamWriter(@"C:\temp\CourseDetails.txt"))
            {
                
                    string st =e_Data.courseName +"," + e_Data.courseLecturer+","+ e_Data.s_List.Count.ToString()+","+e_Data.coursePCF+","+e_Data.coursePCM+","+ e_Data.coursePCO;
                    outputFile.WriteLine(st);
                }
            


            // Write course details to file
            // Mustbe of format:
            // courseName,courseLecturer,num_enrolled,percent_female,percent_male,percent_other

            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            int m=0, f=0, o=0;
            int count = 0;
            foreach(Student s in e_Data.s_List)
            {
                count++;
                if(s.gender== "Male")
                {
                    m++;
                }
                else if(s.gender== "Female")
                {
                    f++;
                }
                else if(s.gender== "Other")
                {
                    o++;
                }
                else
                {
                    break;
                }
            }
            
            e_Data.coursePCF = (f*100)/count;
            e_Data.coursePCM= (m*100)/count;
            e_Data.coursePCO= (o*100)/count;

            // for each Student s in e_Data.s_list, check gender, keep running total
            // then calculate percentages of each category

            lblOutput.Text = "Course: " + e_Data.courseName + System.Environment.NewLine +
                "Lecturer: " + e_Data.courseLecturer + System.Environment.NewLine +
                "Total Students: " + e_Data.s_List.Count.ToString() + System.Environment.NewLine +
                "Female % : " + e_Data.coursePCF.ToString("N2") + System.Environment.NewLine +
                "Male % : " + e_Data.coursePCM.ToString("N2") + System.Environment.NewLine +
                "Other % : " + e_Data.coursePCO.ToString("N2");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search sh = new Search();
            sh.ShowDialog();
                             // create instance of the Search form class and display
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}