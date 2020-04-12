using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using ParseEnrollmentCSV.Models;

namespace ParseEnrollmentCSV
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Add the columns to the table by setting the data source to an empty list of the object it will hold
            gvResults.DataSource = new List<Enrollee>();

            //Allow the columns to fill the width of the window
            gvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Handler for the parse button. Maps the csv to a list of enrollees and sets the gvResults data source to it. 
        /// </summary>
        private void btnParse_Click(object sender, EventArgs e)
        {
            var filePath = txtCsvFilePath.Text;

            //Check if filePath is null
            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show(@"Please provide a valid file path!");
                return;
            }
            
            //Check to make sure our extension is good
            if (!File.Exists(filePath) || Path.GetExtension(filePath).ToLower() != ".csv")
            {
                MessageBox.Show(@"A valid CSV file was not found at the path provided! Please check the file location and file extension and try again!");
                return;
            }

            //Parse the CSV into a list of enrollees
            var enrollees = ParseCSVFile(filePath);

            //Check if we were able to get any enrollees out of the chosen file
            if (enrollees.Count < 1)
            {
                MessageBox.Show("Unable to parse any enrollees from the provided CSV. Please check the data in the file and try again!");
                return;
            }

            //Sort the list by last name and first name ascending
            enrollees = enrollees.OrderBy(s => s.LastName).ThenBy(s => s.FirstName).ToList();

            //Check for duplicates determined by Insurance Company and User ID and keep the highest 'version' of each 
            enrollees = 
                (from enrollee in enrollees
                group enrollee by (enrollee.InsuranceCompany, enrollee.UserId) into groupedEnrollees
                let maxPriority = groupedEnrollees.Max(enrollee => enrollee.Version) 
                from element in groupedEnrollees
                where element.Version == maxPriority
                select element).Distinct().ToList();

            //Finally let's set our data source.
            gvResults.DataSource = enrollees;
        }

        /// <summary>
        /// This method reads through each row of the CSV and each into an enrollee
        /// </summary>
        /// <returns>all of the enrollees that were able to be parsed</returns>
        private List<Enrollee> ParseCSVFile(string filePath, string delimiter = ",")
        {
            var enrolleeList = new List<Enrollee>();
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(delimiter);
                while (!parser.EndOfData)
                {
                    List<string> errorStrings = new List<string>();

                    //Get our row of data
                    string[] fields = parser.ReadFields();
                    
                    try
                    {
                        //Our dataset should be five columns wide. Throw an error and move on if the row is missing something. 
                        if (fields.Length != 5)
                            throw new IndexOutOfRangeException("Row contains incomplete data");
                        
                        //Add the data to our list
                        enrolleeList.Add(new Enrollee
                        {
                            UserId = fields[0],
                            FirstName = fields[1],
                            LastName = fields[2],
                            Version = int.Parse(fields[3]),
                            InsuranceCompany = fields[4]
                        });
                    }
                    catch (Exception ex)
                    {
                        errorStrings.Add($"Problem parsing row: {fields} Error: {ex.Message}");
                        //TODO: Log error of each failed row
                        continue;
                    }
                }
            }

            return enrolleeList;
        }

        /// <summary>
        /// Handler to fire off the open file dialog
        /// </summary>
        private void btnFileSearch_Click(object sender, EventArgs e)
        {
            var ofDialog = new OpenFileDialog()
            {
                DefaultExt = "csv",
                Filter = @"csv files (*.csv)|*.csv",
                Title = @"Browsing for a CSV file...",
                InitialDirectory = "%desktop%",
                CheckFileExists = true,
                CheckPathExists = true
            };

            ofDialog.ShowDialog();

            if (!string.IsNullOrWhiteSpace(ofDialog.FileName))
                txtCsvFilePath.Text = ofDialog.FileName;
        }
    }
}
