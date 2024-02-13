using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Windows.Forms.VisualStyles;
using System.Net;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace A3._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            string query = "SELECT * FROM Account";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            string query = "SELECT * FROM user";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            string query = "SELECT * FROM Transaction_log WHERE date BETWEEN datetime('now', '-30 days') AND datetime('now', 'localtime');";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            string query = "SELECT user.First_name, user.Last_name, Account.New_amount FROM Account INNER JOIN user ON Account.Account_holder = user.user_id";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            con.Open();
            string query = "INSERT INTO user (Drivers_License, First_Name, Last_Name, DOB, Street, City, State, Zip) VALUES (@dl, @fn, @ln, @dob, @add, @ci, @st, @zip )";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@dl", textBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@fn", textBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@ln", textBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@dob", textBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@add", textBox5.Text.Trim());
            cmd.Parameters.AddWithValue("@ci", textBox6.Text.Trim());
            cmd.Parameters.AddWithValue("@st", textBox7.Text.Trim());
            cmd.Parameters.AddWithValue("@zip", textBox8.Text.Trim());
            cmd.ExecuteNonQuery();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            con.Open();
            string query = "INSERT INTO Account (New_amount, Old_amount, Account_holder) VALUES (@na, @oa, @ah )";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@na", textBox10.Text.Trim());
            cmd.Parameters.AddWithValue("@oa", textBox10.Text.Trim());
            cmd.Parameters.AddWithValue("@ah", textBox9.Text.Trim());
            cmd.ExecuteNonQuery();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            con.Open();
            string query = "UPDATE Account SET Old_amount = New_amount WHERE Id = @id";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox11.Text.Trim());
            cmd.ExecuteNonQuery();

            SQLiteConnection con2 = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            con2.Open();
            string query2 = "UPDATE Account SET New_amount = New_amount + @amount WHERE Id = @id";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@id", textBox11.Text.Trim());
            cmd2.Parameters.AddWithValue("@amount", textBox12.Text.Trim());
            cmd2.ExecuteNonQuery();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            string query = "SELECT * FROM Transaction_log";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            con.Open();
            string query = "UPDATE Account SET Old_amount = New_amount WHERE Id = @id";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox13.Text.Trim());
            cmd.ExecuteNonQuery();

            SQLiteConnection con2 = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            con2.Open();
            string query2 = "UPDATE Account SET New_amount = New_amount - @amount WHERE Id = @id";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@id", textBox13.Text.Trim());
            cmd2.Parameters.AddWithValue("@amount", textBox14.Text.Trim());
            cmd2.ExecuteNonQuery();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            con.Open();
            string query = "UPDATE Account SET Old_amount = New_amount WHERE Id = @id";
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox15.Text.Trim());
            cmd.ExecuteNonQuery();
            SQLiteConnection con2 = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            con2.Open();
            string query2 = "UPDATE Account SET Old_amount = New_amount WHERE Id = @id";
            SQLiteCommand cmd2 = new SQLiteCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@id", textBox17.Text.Trim());
            cmd2.ExecuteNonQuery();

            SQLiteConnection con3 = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            con3.Open();
            string query3 = "UPDATE Account SET New_amount = New_amount - @amount WHERE Id = @id";
            SQLiteCommand cmd3 = new SQLiteCommand(query3, con3);
            cmd3.Parameters.AddWithValue("@id", textBox15.Text.Trim());
            cmd3.Parameters.AddWithValue("@amount", textBox16.Text.Trim());
            cmd3.ExecuteNonQuery();

            SQLiteConnection con4 = new SQLiteConnection(@"data source=C:\sqlite\A3.1.db");
            con4.Open();
            string query4 = "UPDATE Account SET New_amount = New_amount + @amount WHERE Id = @id";
            SQLiteCommand cmd4 = new SQLiteCommand(query4, con4);
            cmd4.Parameters.AddWithValue("@id", textBox17.Text.Trim());
            cmd4.Parameters.AddWithValue("@amount", textBox16.Text.Trim());
            cmd4.ExecuteNonQuery();
        }
    }
}
