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
using static UNICATALOGFINAL.studenti;
using System.Drawing.Drawing2D;

namespace UNICATALOGFINAL
{
   
    public partial class studenti : Form
    {
        public class univ
        {
            public string Facultate;
            public string Profil;
            public int An;
            public string Materie;

            public univ(string facultate, string profil, int an, string materie)
            {
                Facultate = facultate;
                Profil = profil;
                An = an;
                Materie = materie;
            }
        }
        private int x = 0;
        string facultate = "", profil = "";
        int an = 0;
        public studenti()
        {
            InitializeComponent();
        }

        private void studenti_Load(object sender, EventArgs e)

        {
          
            List<string> materiiList = new List<string>();
            
      
            SqlConnection conn1 = new SqlConnection("Data Source=DESKTOP-JE6LJQD;Initial Catalog=UNICATALOGFIN;Integrated Security=True");
            SqlCommand cmd1 = new SqlCommand("SELECT facultate,profil,an FROM studenti WHERE numar_mat = @User", conn1);
            cmd1.Parameters.AddWithValue("@User", user.numeUtilizator);
            conn1.Open();
            SqlDataReader reader = cmd1.ExecuteReader();

            if (reader.Read())
            {
                facultate = reader.GetString(0);
                profil = reader.GetString(1);
                an = reader.GetInt32(2);
            }

            reader.Close();
            conn1.Close();
            label1.Text = facultate;
            label2.Text = profil;
            label3.Text = an.ToString();
            
     
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JE6LJQD;Initial Catalog=UNICATALOGFIN;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT materi FROM univ where facultate=@facutate AND profil=@profil AND an=@an AND sem=@x ", conn);
            cmd.Parameters.AddWithValue("@facutate", facultate);
            cmd.Parameters.AddWithValue("@profil", profil);
            cmd.Parameters.AddWithValue("@an", an);
            cmd.Parameters.AddWithValue("@x", x);
            conn.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            SqlDataReader reader1 = sqlDataReader;
            while (reader1.Read())
            {
                string materie = reader1.GetString(0); 
                materiiList.Add(materie);
                listBox1.Items.Add(materie);
            }
            conn.Close();
            reader1.Close();
            




        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JE6LJQD;Initial Catalog=UNICATALOGFIN;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT materi FROM univ WHERE facultate=@facultate AND profil=@profil AND an=@an AND sem=@x ", conn);
            cmd.Parameters.AddWithValue("@facultate", facultate);
            cmd.Parameters.AddWithValue("@profil", profil);
            cmd.Parameters.AddWithValue("@an", an);
            cmd.Parameters.AddWithValue("@x", x);
            conn.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            listBox1.Items.Clear(); // Curăță lista înainte de a o popula din nou

            while (sqlDataReader.Read())
            {
                string materie = sqlDataReader.GetString(0);
                listBox1.Items.Add(materie);
            }

            conn.Close();
            sqlDataReader.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void sem1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { sem1.Checked = false; }
            if(sem1.Checked)
            {
                x = 1;
                listBox1_SelectedIndexChanged(sender, e);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(sem1.Checked) { radioButton2.Checked = false; }
            if(radioButton2.Checked)
            {
                x = 2;
                listBox1_SelectedIndexChanged(sender, e);
            }
        }
    }
}
