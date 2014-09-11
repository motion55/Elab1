using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Elab1
{
    public partial class Form1 : Form
    {
        SerialPort _serial_port = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (_serial_port == null)
            {
                try
                {
                    _serial_port = new SerialPort(PortComboBox.Text, 9600, Parity.None, 8, StopBits.One);
                    _serial_port.Open();
                    ConnectButton.Text = "Disconnect";
                }
                catch (Exception ex)
                {
                    _serial_port = null;
                    ConnectButton.Text = "Connect";
                    System.Console.WriteLine(ex.Message);
                    string error_text = "Unable to open serial port";
                    MessageBox.Show(error_text);
                }
            }
            else
            {
                _serial_port.Close();
                _serial_port = null;
                ConnectButton.Text = "Connect";
            }
        }

        void SendReply(string text)
        {
            if (_serial_port != null && _serial_port.IsOpen)
            {
                _serial_port.Write(text);
            }
        }

        private void AnalogRead_Click(object sender, EventArgs e)
        {
            SendReply("A\n");
        }

        private void LEDcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LEDcheckBox.Checked)
                SendReply("B1\n");
            else
                SendReply("B0\n");
        }
    }
}
