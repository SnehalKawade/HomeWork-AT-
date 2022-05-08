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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text.Json;

namespace HomeWork_AT_
{
    public partial class BookData : Form
    {
        FileStream fs;
        public BookData()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBookID.Clear();
            txtBookName.Clear();
            txtAuthorName.Clear();
            txtBookPrice.Clear();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                book.BID= Convert.ToInt32(txtBookID.Text);
                book.BName = txtBookName.Text;
                book.AuthorName= txtAuthorName.Text;
                book.BPrice= Convert.ToInt32(txtBookPrice.Text);
                fs = new FileStream(@"E:\TestFolder\BookBinary", FileMode.Create, FileAccess.Write);
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(fs, book);
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

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                fs = new FileStream(@"E:\TestFolder\BookBinary", FileMode.Open, FileAccess.Read);
                BinaryFormatter binary = new BinaryFormatter();
                book = (Book)binary.Deserialize(fs);
                txtBookID.Text = book.BID.ToString();
                txtBookName.Text = book.BName;
                txtAuthorName.Text=book.AuthorName;
                txtBookPrice.Text = book.BPrice.ToString();
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

        private void btnSoapWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                book.BID = Convert.ToInt32(txtBookID.Text);
                book.BName = txtBookName.Text;
                book.AuthorName = txtAuthorName.Text;
                book.BPrice = Convert.ToInt32(txtBookPrice.Text);
                fs = new FileStream(@"E:\TestFolder\BookSoap", FileMode.Create, FileAccess.Write);
                SoapFormatter soap = new SoapFormatter();
                soap.Serialize(fs, book);
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

        private void btnSoapRead_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                fs = new FileStream(@"E:\TestFolder\BookSoap", FileMode.Open, FileAccess.Read);
                SoapFormatter soap = new SoapFormatter();
                book = (Book)soap.Deserialize(fs);
                txtBookID.Text = book.BID.ToString();
                txtBookName.Text = book.BName;
                txtAuthorName.Text = book.AuthorName;
                txtBookPrice.Text = book.BPrice.ToString();
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

        private void btnXMLWrite_Click(object sender, EventArgs e)
        {

            try
            {
                Book book = new Book();
                book.BID = Convert.ToInt32(txtBookID.Text);
                book.BName = txtBookName.Text;
                book.AuthorName = txtAuthorName.Text;
                book.BPrice = Convert.ToInt32(txtBookPrice.Text);
                fs = new FileStream(@"E:\TestFolder\BookXML", FileMode.Create, FileAccess.Write);
                XmlSerializer xml = new XmlSerializer(typeof(Book));
                xml.Serialize(fs, book);
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

        private void btnXMLRead_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                fs = new FileStream(@"E:\TestFolder\BookXML", FileMode.Open, FileAccess.Read);
                XmlSerializer xml = new XmlSerializer(typeof(Book));
                book = (Book)xml.Deserialize(fs);
                txtBookID.Text = book.BID.ToString();
                txtBookName.Text = book.BName;
                txtAuthorName.Text = book.AuthorName;
                txtBookPrice.Text = book.BPrice.ToString();
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

        private void btnJsonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                book.BID = Convert.ToInt32(txtBookID.Text);
                book.BName = txtBookName.Text;
                book.AuthorName = txtAuthorName.Text;
                book.BPrice = Convert.ToInt32(txtBookPrice.Text);
                fs = new FileStream(@"E:\TestFolder\BookJson", FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize(fs, book);
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

        private void btnJsonRead_Click(object sender, EventArgs e)
        {
            try
            {
                Book book=new Book();
                fs = new FileStream(@"E:\TestFolder\BookJson", FileMode.Open, FileAccess.Read);
                book = JsonSerializer.Deserialize<Book>(fs);
                txtBookID.Text = book.BID.ToString();
                txtBookName.Text = book.BName;
                txtAuthorName.Text = book.AuthorName;
                txtBookPrice.Text = book.BPrice.ToString();
                
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
