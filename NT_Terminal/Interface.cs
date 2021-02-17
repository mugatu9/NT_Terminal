using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NT_Terminal
{
    public partial class Interface : Form
    {
        SerialClass port = new SerialClass();
        

        public Interface()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(110);
            BaudRateBox.Text = "110";
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(300);
            BaudRateBox.Text = "300";
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(600);
            BaudRateBox.Text = "600";
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(1200);
            BaudRateBox.Text = "1200";
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(2400);
            BaudRateBox.Text = "2400";
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(4800);
            BaudRateBox.Text = "4800";
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(9600);
            BaudRateBox.Text = "9600";
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(14400);
            BaudRateBox.Text = "14400";
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(19200);
            BaudRateBox.Text = "19200";
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(38400);
            BaudRateBox.Text = "38400";
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(57600);
            BaudRateBox.Text = "57600";
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(115200);
            BaudRateBox.Text = "115200";
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(128000);
            BaudRateBox.Text = "128000";
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            port.SetBaudRate(256000);
            BaudRateBox.Text = "256000";
        }

        private void setCOMPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int comVal = 0;
            string promptValue = Prompt.ShowDialog("Enter an integer between 1 and 99", "Com Port");
            try
            {
                comVal = Int32.Parse(promptValue);
                if (comVal > 0 && comVal < 100)
                {
                    port.SetPort(Int32.Parse(promptValue));
                }
                else
                {
                    Notification.ShowDialog("Bad Entry. You must enter an integer beteen 1 and 99", "Error");
                }
            }
            catch (FormatException) {
                Notification.ShowDialog("Bad Entry. You must enter an integer beteen 1 and 99", "Error");
            }
            port.SetPort(comVal);
            ComLabel.Text = comVal.ToString();
        }

        private void viewAvailableCOMPortsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<String> openPorts = port.GetAvailablePorts();
            String ports = "";
            foreach (String s in openPorts) {
                ports += s + "  ";
            }
            Notification.ShowDialog(ports, "Open Ports");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                port.OpenPort();
                String command = CommandBox.Text;
                ResponseBox.Text = String.Empty;
                List<String> response = new List<String>();
                while (true)
                {
                    try
                    {
                        port.SendCommand(command);
                        Thread.Sleep(200);
                        response = port.ReadDataToList();
                        while (port.BytesToRead() != 0)
                        {
                            List<String> doubleCheckBuffer = new List<String>();
                            doubleCheckBuffer = port.ReadDataToList();
                            response.AddRange(doubleCheckBuffer);
                        }
                        break;
                    }
                    catch (TimeoutException)
                    {
                        ResponseBox.Text = "No data was received";
                        break;
                    }
                }

                foreach (String s in response)
                {
                    ResponseBox.Text += s + "\n";
                }
                port.ClosePort();
                CommandBox.Text = String.Empty;
            } catch(System.IO.IOException)
            {
                String errMessage = "There's been a problem connecting to your device. Please confirm your device is properly connected, and that the displayed COM port and Baud-Rate settings are accurate.";
                Notification.ShowDialog(errMessage, "Error");
            }
        }
    }
}
