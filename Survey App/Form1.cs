using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Survey_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //use a while loop to generate the months on the lstMonth
            int index = 1;
            while (index <= 12)
            {
                lstMonth.Items.Add(index);
                index++;
            }

            //use a do while loop to generates the days on the lstDay
            index = 1;
            do
            {
                lstDay.Items.Add(index);
                index++;
            } while (index <= 31);

            //use for loop to generate the years on the lstYear
            for(index = 2015; index <= 2025; index++)
            {
                lstYear.Items.Add(index);
            }

            return;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //use if statements to do data validation
            //check if txtName is empty
            if( txtName.Text.Trim() == string.Empty)
            {
                lblMessage.Text = "Name required";
                txtName.SelectAll();
                txtName.Focus();
            }
            //check if lstAge is not selected
            else if (lstAge.SelectedIndex == -1)
            {
                lblMessage.Text = "Please select an age range";
            }
            //check if lstMonth is not selected
            else if (lstMonth.SelectedIndex == -1)
            {
                lblMessage.Text = "Please select a month";
            }
            //check if lstDay is not selected
            else if (lstDay.SelectedIndex == -1)
            {
                lblMessage.Text = "Please select a day";
            }
            //check if lstYear is not selected
            else if (lstYear.SelectedIndex == -1)
            {
                lblMessage.Text = "Please select a year";
            }
            else
            {
                try
                {
                    /*
                    //create a Survey object 
                    Survey mySurvey = new Survey();
                    mySurvey.Name = txtName.Text;
                    mySurvey.Age = lstAge.SelectedItem.ToString();
                    */

                    int month = int.Parse(lstMonth.SelectedItem.ToString());
                    int day = int.Parse(lstDay.SelectedItem.ToString());
                    int year = int.Parse(lstYear.SelectedItem.ToString());
                    //create a new submissionDate object
                    DateTime submissionDate = new DateTime(year, month, day);

                    string title = string.Empty;
                    if(cboTitle.SelectedIndex != -1)
                        title = cboTitle.SelectedItem.ToString();
                    /*
                    //mySurvey.Title = title;
                    // update the SubmissionDate property with the submissionDate object   
                    //mySurvey.SubmissionDate = submissionDate;
                    */

                    Survey mySurvey = new Survey(lstAge.SelectedItem.ToString(), txtName.Text, submissionDate, title);

                    //display message on the message label
                    lblMessage.Text = mySurvey.ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    lblMessage.Text = "Invalid day " + ex.GetType().ToString();
                }
                /*catch (Exception ex)
                {
                    lblMessage.Text = "Invalid data: " + ex.GetType().ToString();
                }*/
            }

        }

        //event that closes the app
        private void btnExit_Click(object sender, EventArgs e)
        {
           Close();
        }


        //event that clear all data on the app elements
        private void btnClear_Click(object sender, EventArgs e)
        {
            cboTitle.SelectedIndex = -1;

            txtName.Clear();
            lstAge.ClearSelected();
            lstMonth.ClearSelected();
            lstDay.ClearSelected();
            lstYear.ClearSelected();

            lblMessage.ResetText();

            txtName.Focus();
        }

        
    }
}
