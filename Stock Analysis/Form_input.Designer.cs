namespace Stock_Analysis
{
    partial class Form_analyzer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            openFileDialog_LoadStocks = new OpenFileDialog();
            button_loadData = new Button();
            dateTimePicker_Startdate = new DateTimePicker();
            dateTimePicker_EndDate = new DateTimePicker();
            label_StartDate = new Label();
            label_EndDate = new Label();
            chart_Candlesticks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            button_Update = new Button();
            ((System.ComponentModel.ISupportInitialize)chart_Candlesticks).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog_LoadStocks
            // 
            openFileDialog_LoadStocks.FileName = "openFileDialog_LoadStocks";
            openFileDialog_LoadStocks.Multiselect = true;
            openFileDialog_LoadStocks.FileOk += openFileDialog_FileOk;
            // 
            // button_loadData
            // 
            button_loadData.Location = new Point(439, 590);
            button_loadData.Name = "button_loadData";
            button_loadData.Size = new Size(287, 33);
            button_loadData.TabIndex = 0;
            button_loadData.Text = "Load Stock(s)";
            button_loadData.UseVisualStyleBackColor = true;
            button_loadData.Click += button_loadData_Click;
            // 
            // dateTimePicker_Startdate
            // 
            dateTimePicker_Startdate.Location = new Point(44, 600);
            dateTimePicker_Startdate.Name = "dateTimePicker_Startdate";
            dateTimePicker_Startdate.Size = new Size(200, 23);
            dateTimePicker_Startdate.TabIndex = 1;
            dateTimePicker_Startdate.Value = new DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            dateTimePicker_EndDate.Location = new Point(1029, 600);
            dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            dateTimePicker_EndDate.Size = new Size(200, 23);
            dateTimePicker_EndDate.TabIndex = 2;
            // 
            // label_StartDate
            // 
            label_StartDate.AutoSize = true;
            label_StartDate.Location = new Point(90, 582);
            label_StartDate.Name = "label_StartDate";
            label_StartDate.Size = new Size(94, 15);
            label_StartDate.TabIndex = 3;
            label_StartDate.Text = "Pick A Start Date";
            // 
            // label_EndDate
            // 
            label_EndDate.AutoSize = true;
            label_EndDate.Location = new Point(1081, 582);
            label_EndDate.Name = "label_EndDate";
            label_EndDate.Size = new Size(97, 15);
            label_EndDate.TabIndex = 4;
            label_EndDate.Text = "Pick An End Date";
            // 
            // chart_Candlesticks
            // 
            chartArea1.AlignWithChartArea = "ChartArea_Volume";
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_Volume";
            chart_Candlesticks.ChartAreas.Add(chartArea1);
            chart_Candlesticks.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            chart_Candlesticks.Legends.Add(legend1);
            chart_Candlesticks.Location = new Point(44, 12);
            chart_Candlesticks.Name = "chart_Candlesticks";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceUpColor=Lime, PriceDownColor=Red";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series_Candlesticks";
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "High,Low,Open,Close";
            series1.YValuesPerPoint = 6;
            series2.ChartArea = "ChartArea_Volume";
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Series_Volume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "Volume";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            chart_Candlesticks.Series.Add(series1);
            chart_Candlesticks.Series.Add(series2);
            chart_Candlesticks.Size = new Size(1344, 497);
            chart_Candlesticks.TabIndex = 5;
            chart_Candlesticks.Text = "chart_Candlesticks";
            chart_Candlesticks.Visible = false;
            // 
            // button_Update
            // 
            button_Update.Location = new Point(827, 600);
            button_Update.Name = "button_Update";
            button_Update.Size = new Size(75, 23);
            button_Update.TabIndex = 6;
            button_Update.Text = "Update";
            button_Update.UseVisualStyleBackColor = true;
            button_Update.Click += button_Update_Click;
            button_Update.MouseMove += Chart_Candlesticks_MouseMove;
            // 
            // Form_analyzer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 635);
            Controls.Add(button_Update);
            Controls.Add(chart_Candlesticks);
            Controls.Add(label_EndDate);
            Controls.Add(label_StartDate);
            Controls.Add(dateTimePicker_EndDate);
            Controls.Add(dateTimePicker_Startdate);
            Controls.Add(button_loadData);
            Name = "Form_analyzer";
            Text = "Stock Analyzer";
            Load += Form_analyzer_Load;
            ((System.ComponentModel.ISupportInitialize)chart_Candlesticks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog_LoadStocks;
        private Button button_loadData;
        private DateTimePicker dateTimePicker_Startdate;
        private DateTimePicker dateTimePicker_EndDate;
        private Label label_StartDate;
        private Label label_EndDate;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart_Candlesticks;
        private Button button_Update;
    }
}