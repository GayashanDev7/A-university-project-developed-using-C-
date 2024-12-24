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
using System.Data.Common;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace School_Management_System
{
    public partial class Form4 : Form
    {
        
        public Form4()
        {
            InitializeComponent();
        }
        public SqlConnection conn;
        public SqlDataAdapter adapter;
        public DataSet ds= new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("");
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Table_str(st_id,st_n,st_add,st_age,st_ge)VALUES(@st_id,@st_n,@st_add,@st_age,@st_ge)",conn);
            cmd.Parameters.AddWithValue("@st_id",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@st_n", (textBox2.Text));
            cmd.Parameters.AddWithValue("@st_add", (textBox3.Text));
            cmd.Parameters.AddWithValue("@st_age", (textBox4.Text));
            cmd.Parameters.AddWithValue("@st_ge",(comboBox1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("data seved");




        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("");
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Table_str SET st_n=@st_n,st_add=@st_add,st_age=@st_age,st_ge=@st_ge WHERE st_id=@st_id", conn);
            cmd.Parameters.AddWithValue("@st_id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@st_n", (textBox2.Text));
            cmd.Parameters.AddWithValue("@st_add", (textBox3.Text));
            cmd.Parameters.AddWithValue("@st_age", (textBox4.Text));
            cmd.Parameters.AddWithValue("@st_ge", (comboBox1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("data update");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("");
            conn.Open();

            int st_id;
            st_id = Convert.ToInt32(textBox1.Text);
            SqlCommand cmd = new SqlCommand("DELETE  WHERE st_id=@st_id", conn);
            cmd = new SqlCommand("delete from Table_str  where st_id=@st_id", conn);
            cmd.Parameters.AddWithValue("st_id", st_id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Deleted Successfully", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            adapter = new SqlDataAdapter("select * from Table_str",conn);
            adapter.Fill(ds, "Table_str");
            conn.Close();
            dataGridView1.DataSource = ds;
            adapter.Fill(ds, "Table_str");
            dataGridView1.DataMember = "Table_str";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 fm5 = new Form5();
            fm5.Show();
            this.Hide();

        }
    }
}
