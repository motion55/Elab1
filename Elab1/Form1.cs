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

            GetSerialPorts();
        }

        private void GetSerialPorts()
        {
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;

            ArrayComPortsNames = SerialPort.GetPortNames();

            do {
                index += 1;
                PortComboBox.Items.Add(ArrayComPortsNames[index]);
            } while (!((ArrayComPortsNames[index] == ComPortName) ||
                       (index == ArrayComPortsNames.GetUpperBound(0))));

            Array.Sort(ArrayComPortsNames);

            //want to get first out
            if (index == ArrayComPortsNames.GetUpperBound(0))
            {
                ComPortName = ArrayComPortsNames[0];
            }
            PortComboBox.Text = ArrayComPortsNames[0];
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (_serial_port == null)
            {
                try
                {
                    _serial_port = new SerialPort(PortComboBox.Text);
                    _serial_port.DtrEnable = true;
                    _serial_port.RtsEnable = true;
                    _serial_port.BaudRate = 9600;
                    _serial_port.Parity = Parity.None;
                    _serial_port.StopBits = StopBits.One;
                    _serial_port.DataBits = 8;
                    _serial_port.Handshake = Handshake.None;
                    _serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    _serial_port.Open();
                    ConnectButton.Text = "Disconnect";
                    LEDcheckBox.Checked = true;
                    LEDcheckBox.Invalidate();
                    SendCommand("B1\r");
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
                LEDcheckBox.Checked = false;
                LEDcheckBox.Invalidate();
            }
        }

        delegate void SetTextCallback(string text);

        private void AnalogValText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.AnalogVal.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AnalogValText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.AnalogVal.Text = text;
            }
        }

        private void DataReceivedParser(string message)
        {
            char ch = message[0];
            string param = message.Substring(1);
            int numval = 0;
            try
            {   numval = Convert.ToInt16(param);}
            catch (FormatException e)
            { numval = 0; }
            catch (OverflowException e)
            { numval = 65535; }

            switch (Char.ToUpper(ch))
            {
                case 'A':
                    AnalogValText(numval.ToString());
                    break;
                case 'B':
                    break;
            }
        }

        string Arduino_reply;

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serial_port = (SerialPort)sender;
            string indata = serial_port.ReadExisting();
            foreach (char ch in indata)
            {
                if (ch=='\r'||ch=='\n')
                {
                    if (Arduino_reply.Length>0)
                    {
                        DataReceivedParser(Arduino_reply);
                        Console.WriteLine(Arduino_reply);
                        Arduino_reply = String.Empty;
                        break;
                    }
                }
                else
                {
                    Arduino_reply += ch;
                }
            }
        }

        void SendCommand(string text)
        {
            if (_serial_port != null && _serial_port.IsOpen)
            {
                _serial_port.Write(text);
            }
        }

        private void AnalogRead_Click(object sender, EventArgs e)
        {
            SendCommand("A\r");
        }

        private void LEDcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LEDcheckBox.Checked)
                SendCommand("B1\r");
            else
                SendCommand("B0\r");
        }
    }
}
