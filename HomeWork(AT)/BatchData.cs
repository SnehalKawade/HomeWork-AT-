using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HomeWork_AT_
{
    public partial class BatchData : Form
    {
        FileStream fs;
        public BatchData()
        {
            InitializeComponent();
        }

        private void btnBinaryWriter_Click(object sender, EventArgs e)
        {
            try
            {
                int bid = Convert.ToInt32(txtBatchId.Text);
                string bname = txtBatchName.Text;
                string startdate=txtStartDate.Text;
                string enddate=txtEndDate.Text; 
                string location = txtLocation.Text;
                string trainername=txtTrainerName.Text;
                fs = new FileStream(@"E:\TestFolder\BatchFile.txt", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(bid);
                bw.Write(bname);
                bw.Write(startdate);
                bw.Write(enddate);
                bw.Write(location);
                bw.Write(trainername);
                bw.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"E:\TestFolder\BatchFile.txt", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                txtBatchId.Text = br.ReadInt32().ToString();
                txtBatchName.Text = br.ReadString();
                txtStartDate.Text=br.ReadString();
                txtEndDate.Text=br.ReadString();
                txtLocation.Text = br.ReadString();
                txtTrainerName.Text=br.ReadString();
                br.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
