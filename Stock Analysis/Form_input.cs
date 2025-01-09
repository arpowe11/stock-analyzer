//
// Description: Historical stock data analyzer that lets a user upload a csv file of historical stock data to view it in a formated chart.
// Author: Alexander Powell
// Version: v1.2
// Dependencies: 
//


using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;
using ToolTip = System.Windows.Forms.ToolTip;

namespace Stock_Analysis
{
    public partial class Form_analyzer : Form
    {
        // Property to hold the file path for this form
        public string FilePath { get; set; }
        private ToolTip candlestickToolTip;


        /// <summary>
        /// Initializes a new instance of the Form_analyzer class.
        /// </summary>
        public Form_analyzer()
        {
            InitializeComponent();

            // Initialize the tooltip
            candlestickToolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 500,
                ReshowDelay = 100,
                ShowAlways = true
            };

            // Subscribe to the MouseMove event
            chart_Candlesticks.MouseMove += Chart_Candlesticks_MouseMove;
        }


        /// <summary>
        /// Handles the click event for the "Load Data" button,
        /// displaying the Open File dialog for selecting a CSV file.
        /// </summary>
        private void button_loadData_Click(object sender, EventArgs e)
        {
            // Show the file dialog to allow the user to select a CSV file
            openFileDialog_LoadStocks.ShowDialog();
        }

        /// <summary>
        /// Handles the FileOk event for the Open File dialog, which triggers
        /// after the user selects a file. Loads and filters candlestick data,
        /// then displays it in a new form.
        /// </summary>
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            // Get the selected files from the OpenFileDialog
            string[] selectedFiles = openFileDialog_LoadStocks.FileNames;

            // Ensure there's at least one file selected
            if (selectedFiles.Length == 0) return;

            // Display the data for the first file in the current form (base form)
            string firstFilePath = selectedFiles[0];
            this.FilePath = firstFilePath; // Set the file path to the form property
            displayData(firstFilePath);

            // Loop through the remaining files and create a new form for each
            for (int i = 1; i < selectedFiles.Length; i++)
            {
                // Create a new form instance
                Form_analyzer display = new Form_analyzer();

                // Set the file path property for the new form
                display.FilePath = selectedFiles[i];

                // Pass the file path to the form's displayData method
                display.displayData(selectedFiles[i]);

                // Show the form
                display.Show();
            }
        }


        /// <summary>
        /// Loads, filters, and normalizes candlestick data from a CSV file and displays it on the chart.
        /// </summary>
        /// <param name="path">The file path of the CSV file containing the candlestick data.</param>
        public void displayData(string path)
        {
            // Load candlestick data from the selected CSV file
            List<aCandlestick> candlesticks = aCandlestickLoader.LoadFromCsv(path);

            // Get the selected start and end dates from the date pickers
            DateTime startDate = dateTimePicker_Startdate.Value;
            DateTime endDate = dateTimePicker_EndDate.Value;

            // Filter the candlesticks based on the selected date range
            var filteredCandleSticks = filterCandlesticks(candlesticks, startDate, endDate);
     
            // Bind the filtered candlestick list for data display
            BindingList<aCandlestick> boundList = new BindingList<aCandlestick>(filteredCandleSticks);

            // Bind the candlesticks
            chart_Candlesticks.DataSource = boundList;
            chart_Candlesticks.DataBind();

            // Normalize the data
            normalizeData(filteredCandleSticks);

            // Refresh the chart with the new data and display the form
            chart_Candlesticks.Show();
            chart_Candlesticks.Update();
        }


        /// <summary>
        /// Filters the list of candlesticks based on a specified date range.
        /// Only candlesticks with dates within the start and end dates are included.
        /// </summary>
        /// <param name="candlesticks">The list of candlesticks to filter.</param>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>A list of candlesticks within the specified date range.</returns>
        public static List<aCandlestick> filterCandlesticks(List<aCandlestick> candlesticks, DateTime startDate, DateTime endDate)
        {
            // Initialize a new list to store the filtered candlesticks
            var filteredCandlesticks = new List<aCandlestick>();

            // Iterate over each candlestick to check if it falls within the date range
            foreach (var candlestick in candlesticks)
            {
                // Add candlestick to the filtered list if it falls within the date range
                if (candlestick.Date >= startDate && candlestick.Date <= endDate)
                {
                    filteredCandlesticks.Add(candlestick);
                }

                // Break out of the loop if the candlestick date exceeds the end date
                if (candlestick.Date >= endDate)
                {
                    break;
                }
            }

            // Return the list of filtered candlesticks
            return filteredCandlesticks;
        }


        /// <summary>
        /// Normalizes the candlestick data by finding the lowest low and the highest high from the list of candlesticks.
        /// </summary>
        /// <param name="candlesticks">A list of <see cref="aCandlestick"/> objects to be analyzed.</param>
        /// <returns>
        /// A tuple containing the minimum low value (minLow) and the maximum high value (maxHigh).
        /// These values represent the range of data for normalization, which can be used for chart axis adjustments.
        /// </returns>
        /// <remarks>
        /// If the provided list of candlesticks is empty, the method returns (0, 0).
        /// The method assumes that the candlesticks contain valid 'Low' and 'High' values that can be used for finding the range.
        /// </remarks>
        public void normalizeData(List<aCandlestick> candlesticks)
        {

            // Find the lowest low and highest high from the candlesticks
            double minLow = (int)candlesticks.Min(c => c.Low);
            double maxHigh = (int)candlesticks.Max(c => c.High);

            chart_Candlesticks.ChartAreas[0].AxisY.Minimum = minLow;
            chart_Candlesticks.ChartAreas[0].AxisY.Maximum = maxHigh;
            chart_Candlesticks.ChartAreas[0].AxisY.Interval = 25;
            chart_Candlesticks.Legends.Clear();

        }

        
        /// <summary>
        /// Handles the Load event of the form. 
        /// This method is triggered when the form is loaded, typically used to initialize settings or load necessary data.
        /// </summary>
        /// <param name="sender">The source of the event, typically the form that is loading.</param>
        /// <param name="e">The event arguments containing data for the event.</param>
        private void Form_analyzer_Load(object sender, EventArgs e)
        {
            // Empty method, can be used to initialize or load any required data when the form is loaded.
        }


        /// <summary>
        /// Handles the Click event of the "Update" button.
        /// This method reloads the candlestick data from the selected CSV file and refreshes the display on the chart.
        /// </summary>
        private void button_Update_Click(object sender, EventArgs e)
        {
            // Use the FilePath property of the form to reload data for the current file
            if (string.IsNullOrEmpty(this.FilePath))
            {
                MessageBox.Show("No file path set for this form.");
                return;
            }

            // Reload data for the current form
            displayData(this.FilePath);
        }


        /// <summary>
        /// Handles the hover event of the candlesticks to show the details of each candlestick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chart_Candlesticks_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                // Use HitTest to determine what is under the cursor
                var hitTestResult = chart_Candlesticks.HitTest(e.X, e.Y);


                if (hitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    // Identify the series being hovered over
                    string seriesName = hitTestResult.Series?.Name;

                    if (seriesName == "Series_Candlesticks")
                    {
                        // Get the data point for candlesticks
                        var dataPoint = hitTestResult.Series.Points[hitTestResult.PointIndex];

                        // Retrieve the X value and convert it to a DateTime
                        double xValue = dataPoint.XValue;
                        DateTime date = DateTime.FromOADate(xValue); // Convert the OLE Automation Date to a DateTime object

                        // Assuming the candlestick details are stored in custom properties or Y-values
                        double open = dataPoint.YValues[0];
                        double high = dataPoint.YValues[1];
                        double low = dataPoint.YValues[2];
                        double close = dataPoint.YValues[3];


                        // Create the tooltip content
                        string toolTipContent = $"-Candlestick Information-\nDate: {date}\nOpen: ${open}\nHigh: ${high}\nLow: ${low}\nClose: ${close}";

                        // Show the tooltip near the cursor
                        candlestickToolTip.Show(toolTipContent, chart_Candlesticks, e.X + 10, e.Y + 10);
                    }
                    else if (seriesName == "Series_Volume")
                    {
                        // Get the data point for volume
                        var dataPoint = hitTestResult.Series.Points[hitTestResult.PointIndex];

                        // Retrieve the X value and convert it to a DateTime
                        double xValue = dataPoint.XValue;
                        DateTime date = DateTime.FromOADate(xValue); // Convert the OLE Automation Date to a DateTime object

                        // Assuming the volume is stored in the first Y-value
                        double volume = dataPoint.YValues[0];

                        // Create the tooltip content
                        string toolTipContent = $"-Volume Information-\nDate: {date}\nVolume: {volume}";

                        // Show the tooltip near the cursor
                        candlestickToolTip.Show(toolTipContent, chart_Candlesticks, e.X + 10, e.Y + 10);
                    }
                }
                else
                {
                    // Hide the tooltip if not hovering over a data point
                    candlestickToolTip.Hide(chart_Candlesticks);
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());
            }
        }


    }  // End class Form_analyzer
}  // End namespace
