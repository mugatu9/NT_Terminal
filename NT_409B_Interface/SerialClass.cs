using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Collections;

namespace NT_409B_Interface
{
    class SerialClass
    {
        public SerialPort _serialPort = new SerialPort();

        public SerialClass()
        {
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.ReadTimeout = 5;
            _serialPort.BaudRate = 19200;

        }

        public List<String> GetAvailablePorts()
        {
            List<String> ports = new List<String>();
            foreach (string s in SerialPort.GetPortNames())
            {
                ports.Add(s);
            }
            return ports;
        }

        public void SetBaudRate(int baud)
        {
            _serialPort.BaudRate = baud;
        }

        public void SetPort(int port) {
            _serialPort.PortName = "COM" + port;
        }

        public int BytesToRead() {
            return _serialPort.BytesToRead;
        }

        public void OpenPort()
        {
            _serialPort.Open();
        }

        public void ClosePort()
        {
            _serialPort.Close();
        }

        public void SendCommand(String command)
        {

            _serialPort.Write(command + "\r");
        }

        public List<String> ReadDataToList()
        {
            List<String> data = new List<string>();
            String temp;
            while (true)
            {
                try
                {
                    temp = _serialPort.ReadLine();
                    data.Add(temp);

                }
                catch (TimeoutException)
                {
                    break;
                }
            }
            return data;
        }

        public String[] ReadDataToArray()
        {
            char seperator = '~';
            String bucket = _serialPort.ReadLine();
            String recentValue = _serialPort.ReadLine();

            while (true)
            {
                bucket += seperator + recentValue;
                try
                {
                    recentValue = _serialPort.ReadLine();

                }
                catch (TimeoutException)
                {
                    break;
                }
            }
            return bucket.Split(seperator);
        }









    }
}
