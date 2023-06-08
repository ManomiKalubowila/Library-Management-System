using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ICT_18_826
{
    public partial class AddStudent : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NMN\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True");
        String imgLocation;
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            /*if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();*/
        }

        private void submitbtnclick(object sender, EventArgs e)
        {
            try
            {
                if (textSN.Text == " " || textEN.Text == " " || textDep.Text == " " || textAY.Text == " " || textCN.Text == " " || textEA.Text == " " || pictureBox1.Image == null)
                {
                    MessageBox.Show("All fields should be filled");
                }
                else
                {
                    byte[] images = null;
                    FileStream Stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(Stream);
                    images = brs.ReadBytes((int)Stream.Length);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[student_info] VALUES( @studentname,@enrollno,@department,@year,@contactno,@email,@Image)", con);
                    cmd.Parameters.AddWithValue("@studentname", textSN.Text.Trim());
                    cmd.Parameters.AddWithValue("@enrollno", textEN.Text.Trim());
                    cmd.Parameters.AddWithValue("@department", textDep.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", (textAY.Text.Trim()));
                    cmd.Parameters.AddWithValue("@contactno", (textCN.Text.Trim()));
                    cmd.Parameters.AddWithValue("@email", (textEA.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Image", images);

                   
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Inserted successfully");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (con.State == ConnectionState.Open)
            {
                textSN.Text = string.Empty;
                textEN.Text = string.Empty;
                textDep.Text = string.Empty;
                textAY.Text = string.Empty;
                textCN.Text = string.Empty;
                textEA.Text = string.Empty;
                //pictureBox1.Image = string.null;
                con.Close();
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.png; *.jpg; *.jpeg;.*.gif;)| *.jpg; *.jpeg;.*.gif; *.png";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                imgLocation = opnfd.FileName.ToString();
                //giving image location path to picture box
                pictureBox1.ImageLocation = imgLocation;
            }
        }

      

        private void closebtn_click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
