using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UNICATALOGFINAL
{
    public partial class profesori : Form
    {
        string facultate = "IESC";
        public profesori()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void profesori_Load(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   UpdateComboBox3();

        }
        private void UpdateComboBox3()
        {
            comboBox3.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JE6LJQD;Initial Catalog=UNICATALOGFIN;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT materi FROM univ WHERE facultate=@facultate AND profil=@profil AND an=@an AND prof=@user", conn);
            cmd.Parameters.AddWithValue("@facultate", facultate);
            cmd.Parameters.AddWithValue("@profil", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@an", comboBox2.Text);
            cmd.Parameters.AddWithValue("@user", user.numeUtilizator);
            conn.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                comboBox3.Items.Add(sqlDataReader["materi"].ToString());
            }

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string facultate = "";
            string profil = "";
            int an = 0;
            listBox1.Items.Clear();
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JE6LJQD;Initial Catalog=UNICATALOGFIN;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("SELECT facultate, profil, an FROM univ WHERE materi=@materie", conn);
                cmd.Parameters.AddWithValue("@materie", comboBox3.Text);
                conn.Open();

                using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        facultate = sqlDataReader.GetString(0);
                        profil = sqlDataReader.GetString(1);
                        an = sqlDataReader.GetInt32(2);
                    }
                }
            }

            using (SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-JE6LJQD;Initial Catalog=UNICATALOGFIN;Integrated Security=True"))
            {
                SqlCommand cmd2 = new SqlCommand("SELECT nume, prenume FROM studenti WHERE facultate=@facultate AND profil=@profil AND an=@an", conn2);
                cmd2.Parameters.AddWithValue("@facultate", facultate);
                cmd2.Parameters.AddWithValue("@profil", profil);
                cmd2.Parameters.AddWithValue("@an", an);
                conn2.Open();

                using (SqlDataReader sqlDataReader2 = cmd2.ExecuteReader())
                {
                    while (sqlDataReader2.Read())
                    {
                        string nume = sqlDataReader2.GetString(0);
                        string prenume = sqlDataReader2.GetString(1);
                        listBox1.Items.Add(nume + "                 " + prenume);

                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBox3();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComboBox3();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JE6LJQD;Initial Catalog=UNICATALOGFIN;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("select MAT from univ where materi=@materi", conn);
                cmd.Parameters.AddWithValue("@materi", comboBox3.SelectedItem.ToString());
                conn.Open();
            }
        }
    }
}
