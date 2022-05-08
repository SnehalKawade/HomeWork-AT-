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
    public partial class ProductData : Form
    {
        FileStream fs;
        public ProductData()
        {
            InitializeComponent();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtProductPrice.Clear();
            txtCategoryName.Clear();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Product product=new Product();
                product.PID= Convert.ToInt32(txtProductId.Text);
                product.PName = txtProductName.Text;
                product.Price = Convert.ToInt32(txtProductPrice.Text);
                product.CategoryName= txtCategoryName.Text;
                fs = new FileStream(@"E:\TestFolder\ProductBinary", FileMode.Create, FileAccess.Write);
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(fs, product);
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
                Product product = new Product();
                fs = new FileStream(@"E:\TestFolder\ProductBinary", FileMode.Open, FileAccess.Read);
                BinaryFormatter binary = new BinaryFormatter();
                product=(Product)binary.Deserialize(fs);
                txtProductId.Text = product.PID.ToString();
                txtProductName.Text = product.PName;
                txtProductPrice.Text=product.Price.ToString();
                txtCategoryName.Text = product.CategoryName;          
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
                Product product = new Product();
                product.PID = Convert.ToInt32(txtProductId.Text);
                product.PName = txtProductName.Text;
                product.Price = Convert.ToInt32(txtProductPrice.Text);
                product.CategoryName = txtCategoryName.Text;
                fs = new FileStream(@"E:\TestFolder\ProductSoap", FileMode.Create, FileAccess.Write);
                SoapFormatter soap=new SoapFormatter();
                soap.Serialize(fs, product);
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
                Product product = new Product();
                fs = new FileStream(@"E:\TestFolder\ProductSoap", FileMode.Open, FileAccess.Read);
                SoapFormatter soap = new SoapFormatter();
                product = (Product)soap.Deserialize(fs);
                txtProductId.Text = product.PID.ToString();
                txtProductName.Text = product.PName;
                txtProductPrice.Text = product.Price.ToString();
                txtCategoryName.Text = product.CategoryName;
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
                Product product = new Product();
                product.PID = Convert.ToInt32(txtProductId.Text);
                product.PName = txtProductName.Text;
                product.Price = Convert.ToInt32(txtProductPrice.Text);
                product.CategoryName = txtCategoryName.Text;
                fs = new FileStream(@"E:\TestFolder\ProductXML", FileMode.Create, FileAccess.Write);
                XmlSerializer xml = new XmlSerializer(typeof(Product));
                xml.Serialize(fs, product);
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
                Product product = new Product();
                fs = new FileStream(@"E:\TestFolder\ProductXML", FileMode.Open, FileAccess.Read);
                XmlSerializer xml = new XmlSerializer(typeof(Product));
                product= (Product)xml.Deserialize(fs);
                txtProductId.Text = product.PID.ToString();
                txtProductName.Text = product.PName;
                txtProductPrice.Text = product.Price.ToString();
                txtCategoryName.Text = product.CategoryName;

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
                Product product = new Product();
                product.PID = Convert.ToInt32(txtProductId.Text);
                product.PName = txtProductName.Text;
                product.Price = Convert.ToInt32(txtProductPrice.Text);
                product.CategoryName = txtCategoryName.Text;
                fs = new FileStream(@"E:\TestFolder\ProductJson", FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize(fs, product);
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
                Product product = new Product();
                fs = new FileStream(@"E:\TestFolder\ProductJson", FileMode.Open, FileAccess.Read);
                product = JsonSerializer.Deserialize<Product>(fs);
                txtProductId.Text = product.PID.ToString();
                txtProductName.Text = product.PName;
                txtProductPrice.Text = product.Price.ToString();
                txtCategoryName.Text = product.CategoryName;
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
