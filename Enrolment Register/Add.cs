using System;
using System.Globalization;
using System.Windows.Forms;

namespace Enrolment_Register
{
    public partial class Add : Form
    {

        public Add()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // .NET Directive for proper management of date strings
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime checkDate;
            try
            {
                // Check date format
                // An exception will be thrown if it's an invalid format.
                checkDate = DateTime.ParseExact(txtDOB.Text, "yyyyMMdd", provider);

                // Check for input values from text boxes on form
                if (txtName.Text == null || txtAddress.Text == null || txtDOB.Text == null || cboGender.Text == null) 
                {
                    MessageBox.Show("Record cannot be added unless all values supplied");
                }
                else if (cboGender.Text != "Male" && cboGender.Text != "Female" && cboGender.Text != "Other") // replace "true" with input validation checks
                {
                    MessageBox.Show("Error in Gender Value");
                }
                else
                {   if (e_Data.s_List.Count < 20)
                    {
                        e_Data.s_List.Add(new Student { name = txtName.Text, dob = txtDOB.Text, address = txtAddress.Text, gender = cboGender.Text });// Create new student object and add to s_List
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Upto 20 students only allowed in this list");
                        this.Close();
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Invalid date format in Student");
                this.Close();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
