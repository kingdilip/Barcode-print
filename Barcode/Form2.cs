using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode
{
    public partial class Form2 : Form
    {
         SerialPort _serialPort;  
  
     private delegate void SetTextDeleg(string text);
     public Form2()
     {
         InitializeComponent();

     } 
  
     private void Form1_Load(object sender, EventArgs e)  
     {  
           _serialPort = new SerialPort("COM1", 19200, Parity.None, 8, StopBits.One);  
           _serialPort.Handshake = Handshake.None;  
           _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);  
           _serialPort.ReadTimeout = 500;  
           _serialPort.WriteTimeout = 500;  
           _serialPort.Open();  
     }  
        

        private void button1_Click(object sender, EventArgs e)
        {
            try  
           {  
                if(!_serialPort.IsOpen)  
                     _serialPort.Open();  
  
                _serialPort.Write("SI\r\n");  
           }  
           catch (Exception ex)  
           {  
                MessageBox.Show("Error opening/writing to serial port :: " + ex.Message, "Error!");  
           }  
        }
         void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)  
     {  
          Thread.Sleep(500);  
          string data = _serialPort.ReadLine();  
          this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });  
     }  
  
     private void si_DataReceived(string data)  
     {  
           textBox1.Text = data.Trim();  
     }  
    }
}
