using System;
using System.Windows.Forms;

namespace Enrolment_Register
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool found=false;
            String nm="", db = "", addr = "", gen = "";
            foreach(Student s in e_Data.s_List)
            {
                if(s.name==txtName.Text)
                {
                    found = true;
                    nm = s.name;
                    db = s.dob;
                    addr = s.address;
                    gen = s.gender;
                    break;
                }
            }
            if(found == true)
            { 
                lblOutput.Text = "Name:" + nm + System.Environment.NewLine + "DOB:" + db + System.Environment.NewLine + "Address:" + addr + System.Environment.NewLine + "Gender:" + gen;
            }
            else
            {
                lblOutput.Text = "Sorry, we couldn't find any student with that name";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
