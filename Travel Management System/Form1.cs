using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string name = "";
        string emal = "";
        string phone = "";
        string fclass = "";
        string trip = "";
        string dep = "";
        string arr = "";
        string date = "";
        string rtrndate = "";
        string rtrndatetime = "";
        string time = "";
        string pssngrs = "";
        decimal subtotal;
        decimal taxtotal;
        decimal total;
        string receipt = "";

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OpenDlg = new OpenFileDialog();
                OpenDlg.Filter = "Text Files(rtf) | *.rtf";

                if (OpenDlg.ShowDialog() == DialogResult.OK)
                {
                    ReceiptBox.LoadFile(OpenDlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            date = DateBox.Text;
            time = TimeBox.Text;
            rtrndate = "";
            rtrndatetime = "";
            name = $"{FName.Text} {LName.Text}";
            emal = emailbox.Text;
            phone = phoneNum.Text;
            int depnum = Departure.SelectedIndex;
            int arrnum = Arrival.SelectedIndex;
            subtotal = 0;
            taxtotal = 0;
            total = 0;
            try
            {
                if (depnum == 0)
                {
                    dep = Departure.Text;
                }
                else if (depnum == 1)
                {
                    dep = Departure.Text;
                }
                else if (depnum == 2)
                {
                    dep = Departure.Text;
                }
                else if (depnum == 3)
                {
                    dep = Departure.Text;
                }
                else if (depnum == 4)
                {
                    dep = Departure.Text;
                }

                if (arrnum == 0)
                {
                    arr = Arrival.Text;
                }
                else if (arrnum == 1)
                {
                    arr = Arrival.Text;
                }
                else if (arrnum == 2)
                {
                    arr = Arrival.Text;
                }
                else if (arrnum == 3)
                {
                    arr = Arrival.Text;
                }
                else if (arrnum == 4)
                {
                    arr = Arrival.Text;
                }

                if (standard.Checked)
                {
                    fclass = standard.Text;
                    subtotal += 100;
                }
                else if (economy.Checked)
                {
                    fclass = economy.Text;
                    subtotal += 180;
                }

                if (oway.Checked)
                {
                    trip = oway.Text;
                    subtotal += 25;
                    rtrndate = "";
                    rtrndatetime = "";
                }
                else if (rtrip.Checked)
                {
                    trip = rtrip.Text;
                    subtotal += 75;
                    rtrndate = ReturnDateBox.Text;
                    rtrndatetime = ReturnTimeBox.Text;
                }
                if (Adult.Checked)
                {
                    pssngrs += "Adult";
                    subtotal += 200;
                }
                if (Child.Checked)
                {
                    pssngrs += "Child";
                    subtotal += 100;
                }

                if (DateTime.Parse(date) >= DateTime.Parse(rtrndate))
                {
                    MessageBox.Show("The return date cannot be before or on the departure date.");
                    ReturnDateBox.Value = DateBox.Value.AddDays(1);
                    return;
                }

                taxtotal = subtotal * (5m/100m);
                total = subtotal + taxtotal;

                SubTotbox.Text = $"{subtotal.ToString("C")}";
                TaxTotBox.Text = $"{taxtotal.ToString("C")}";
                TotalBox.Text = $"{total.ToString("C")}";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FlightClass2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                receipt = $"*********Your Receipt********* " +
               "\r\n" +
               "\r\n" +
               $"Name : {name}" +
               "\r\n" +
               "\r\n" +
               $"Email : {emal}" +
               "\r\n" +
               "\r\n" +
               $"Phone Number : {phone}" +
               "\r\n" +
               "\r\n" +
               $"Flight Class : {fclass}" +
               "\r\n" +
               "\r\n" +
               $"Type of Trip : {trip}" +
               "\r\n" +
               "\r\n" +
               $"Departing from : {dep}" +
               "\r\n" +
               "\r\n" +
               $"Arriving at : {arr}" +
               "\r\n" +
               "\r\n" +
               $"Date of Departure : {date}" +
               "\r\n" +
               "\r\n" +
                $"Date of Return : {rtrndate}" +
               "\r\n" +
               "\r\n" +
               $"Departure Time : {time}" +
               "\r\n" +
               "\r\n" +
               $"Return Time : {rtrndatetime}" +
               "\r\n" +
               "\r\n" +
               $"Sub-Total : {subtotal}" +
               "\r\n" +
               "\r\n" +
               $"Taxes : {taxtotal}" +
               "\r\n" +
               "\r\n" +
               $"Total : {total}";

                ReceiptBox.Text = receipt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog SaveDlg = new SaveFileDialog();
                SaveDlg.Filter = "Text Files(rtf) | *.rtf";

                if (SaveDlg.ShowDialog() == DialogResult.OK)
                {
                    ReceiptBox.SaveFile(SaveDlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FName.Text = "";
            LName.Text = "";
            emailbox.Text = "";
            phoneNum.Text = "";
            standard.Checked = false;
            economy.Checked = false;
            oway.Checked = false;
            rtrip.Checked = false;
            Adult.Checked = false;
            Child.Checked = false;
            Departure.Text = "";
            Arrival.Text = "";
            SubTotbox.Text = "";
            TaxTotBox.Text = "";
            TotalBox.Text = "";
            DateBox.Text = "";
            TimeBox.Text = "";
            ReceiptBox.Text = "";

        }

        private void DateBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rtrip_CheckedChanged(object sender, EventArgs e)
        {

            if(rtrip.Checked)
            {
                ReturnDateBox.Enabled = true;
                ReturnTimeBox.Enabled = true;
            }
            else
            {
                ReturnDateBox.Enabled = false;
                ReturnTimeBox.Enabled = false;
            }
        }
    }
}
