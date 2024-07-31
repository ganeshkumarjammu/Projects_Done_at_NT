using System;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Wing
{
    public partial class Wing : Form
    {
        private bool isReading = false;
        private StringBuilder csvData = new StringBuilder();
        private int dataCount = 0; // To keep track of the row numbers
        string[] sData = new string[0];
        public Wing()
        {
            InitializeComponent();
        }

        private void scanBT_Click(object sender, EventArgs e)
        {
            PortCB.Text = "";
            PortCB.Items.Clear();
            String[] ports = SerialPort.GetPortNames();
            PortCB.Items.AddRange(ports);
            Console.WriteLine("Ports scanned and updated.");
        }

        private void connectBT_Click(object sender, EventArgs e)
        {
            if (ConnectPort())
            {
                connectBT.Enabled = false;
                disconnectBT.Enabled = true;
                PortCB.Enabled = false;
                Baudrate.Enabled = false;
                isReading = true;
                Console.WriteLine("Connected to port.");
            }
        }

        public bool ConnectPort()
        {
            try
            {
                if (!string.IsNullOrEmpty(PortCB.Text) && !string.IsNullOrEmpty(Baudrate.Text))
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    serialPort1.PortName = PortCB.Text;
                    serialPort1.BaudRate = Int32.Parse(Baudrate.Text);
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                    serialPort1.Open();
                    return true;
                }
                else
                {
                    MessageBox.Show("Please select a port and baud rate.", "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return false;
        }

        private void disconnectBT_Click(object sender, EventArgs e)
        {
            DisconnectPort();
            Console.WriteLine($"Incoming Text: {incomingTB.Text}");
            SaveDataToCSV();
            connectBT.Enabled = true;
            disconnectBT.Enabled = false;
            PortCB.Enabled = true;
            Baudrate.Enabled = true;
            incomingTB.Text = "";
        }

        private void SaveDataToCSV()
        {
            string operatorName = tboxOperator.Text;
            string articleNumber = tbArticle.Text;

            if (string.IsNullOrEmpty(operatorName) || string.IsNullOrEmpty(articleNumber))
            {
                MessageBox.Show("Please enter the operator name and article number.", "Error", MessageBoxButtons.OK);
                return;
            }

            InitializeCSV(operatorName, articleNumber);

            string dir = string.IsNullOrEmpty(tbFolder.Text) ? @"C:\Users\jammu\OneDrive\Desktop\CS\" : tbFolder.Text;  // folder location
            string baseFileName = string.IsNullOrEmpty(tbFile.Text) ? "WingFinlog" : tbFile.Text;
            string fileExtension = ".csv";
            string newFileName = GetUniqueFileName(dir, baseFileName, fileExtension);
            string newFilePath = Path.Combine(dir, newFileName);

            // Print the CSV data to the console before saving it
            Console.WriteLine("CSV Data:\n" + csvData.ToString());

            try
            {
                File.WriteAllText(newFilePath, csvData.ToString());
                Console.WriteLine($"CSV file created: {newFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving CSV file: {ex.Message}");
            }
        }

        private void InitializeCSV(string operatorName, string articleNumber)
        {
            csvData.Clear();
            csvData.AppendLine($"Operator Name,{operatorName}");
            csvData.AppendLine($"Article No,{articleNumber}");
            csvData.AppendLine();
            csvData.AppendLine("S No,Initial Angle,Final Angle,Unfold Time(ms)");
            int count = 0;
            foreach (string data in sData)
            {
                csvData.AppendLine($"{count}"+","+data);
                count++;
            }
        }

        static string GetUniqueFileName(string folderPath, string baseFileName, string fileExtension)
        {
            string fileName = baseFileName + fileExtension;
            int counter = 1;

            while (File.Exists(Path.Combine(folderPath, fileName)))
            {
                fileName = $"{baseFileName}{counter}{fileExtension}";
                counter++;
            }

            return fileName;
        }

        private void DisconnectPort()
        {
            isReading = false;
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.DataReceived -= serialPort1_DataReceived;
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (isReading)
            {
                try
                {
                    string dump = serialPort1.ReadLine();
                    this.Invoke(new Action(() => ProcessData(dump)));
                }
                catch (TimeoutException) { }
                catch (IOException) { }
                catch (InvalidOperationException) { }
            }
        }

        private void ProcessData(string data)
        {
            incomingTB.AppendText(data + Environment.NewLine);
            incomingTB.ScrollToCaret();

            // Use Regex to extract and format the data for CSV
            Match match = Regex.Match(data, @"Initial Angle: (\d+) deg ,Final Angle: (\d+) deg ,Unfold Time: (\d+) ms");
            if (match.Success)
            {
                string initialAngle = match.Groups[1].Value;
                string finalAngle = match.Groups[2].Value;
                string unfoldTime = match.Groups[3].Value;

                dataCount++;
                Array.Resize(ref sData, sData.Length + 1);
                sData[sData.Length - 1] = initialAngle + "," + finalAngle + "," + unfoldTime;
                //csvData.AppendLine(initialAngle+","+finalAngle+","+unfoldTime);
                // Print each line added to CSV data to the console
                Console.WriteLine(initialAngle + "," + finalAngle + "," + unfoldTime);
            }
        }

        private void clearBT_Click(object sender, EventArgs e)
        {
            incomingTB.Text = "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DisconnectPort();
            base.OnFormClosing(e);
        }

        private void Wing_Load(object sender, EventArgs e)
        {
            // Loading ports by default
            PortCB.Text = "";
            PortCB.Items.Clear();
            String[] ports = SerialPort.GetPortNames();
            PortCB.Items.AddRange(ports);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbFolder.Text = folder.SelectedPath;
            }
        }
    }
}
