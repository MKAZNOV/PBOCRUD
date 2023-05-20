using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Prakpbo
{

    public partial class Form1 : Form
    {
        private NpgsqlConnection _conn;

        public Form1()
        {
            InitializeComponent();
            _conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=PraktikumPBO;User Id=postgres;Password=rahasia;");
            _conn.Open();
            LoadData();
        }

        private void LoadData()
        {
            // Koneksi dan pengambilan data dari database
            using (NpgsqlCommand comm = new NpgsqlCommand())
            {
                comm.Connection = _conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select * from akun";
                NpgsqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Kode untuk fungsi "create" di sini
            using (NpgsqlCommand comm = new NpgsqlCommand())
            {
                comm.Connection = _conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "INSERT INTO akun (nama, password) VALUES (@nama, @password)";
                comm.Parameters.AddWithValue("@nama", textBox1.Text);
                comm.Parameters.AddWithValue("@password", textBox2.Text);
                comm.ExecuteNonQuery();
            }

            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Kode untuk fungsi "update" di sini
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int akunId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["id"].Value);

                using (NpgsqlCommand comm = new NpgsqlCommand())
                {
                    comm.Connection = _conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "UPDATE akun SET nama = @nama, password = @password WHERE id = @id";
                    comm.Parameters.AddWithValue("@nama", textBox1.Text);
                    comm.Parameters.AddWithValue("@password", textBox2.Text);
                    comm.Parameters.AddWithValue("@id", akunId);
                    comm.ExecuteNonQuery();
                }

                LoadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kode untuk fungsi "read" di sini
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Kode untuk fungsi "delete" di sini
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int akunId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["id"].Value);

                using (NpgsqlCommand comm = new NpgsqlCommand())
                {
                    comm.Connection = _conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "DELETE FROM akun WHERE id = @id";
                    comm.Parameters.AddWithValue("@id", akunId);
                    comm.ExecuteNonQuery();
                }

                LoadData();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void select(object sender, EventArgs e)
        {

        }

        private void update(object sender, EventArgs e)
        {

        }

        private void delete(object sender, EventArgs e)
        {

        }
    }
}