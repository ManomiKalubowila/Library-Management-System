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

namespace ICT_18_826
{
    public partial class AddBook : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NMN\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True");
        public AddBook()
        {
            InitializeComponent();
        }


        //insert book
        private void SavebtnClick(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " " || textBox6.Text==" " || textBox7.Text==" ")
                {
                    MessageBox.Show("All fields should be filled");
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[book_details] VALUES( @ISBN,@bookname,@authorname,@publication_name,@purchased,@price,@quantity,@availableqty)", con);
                    cmd.Parameters.AddWithValue("@ISBN", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@bookname", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@authorname", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@publication_name", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@purchased", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@price", textBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@quantity", textBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@availableqty", textBox7.Text.Trim());


                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Inserted successfully");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (con.State == ConnectionState.Open)
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox6.Text = string.Empty;
                textBox7.Text = string.Empty;
             
                con.Close();
            }
        }

        //close form
        private void closebtn_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
