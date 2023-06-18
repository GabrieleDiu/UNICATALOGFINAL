using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNICATALOGFINAL
{
   
    public partial class login : Form
    {
       
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string useractual = textBox2.Text.ToString();
           string password = textBox1.Text.ToString();
            string parola = string.Empty;
            string numarMatricol = string.Empty;
            int autorizare = 0;


            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JE6LJQD;Initial Catalog=UNICATALOGFIN;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT parola,numar_mat,autorizare FROM logare1 WHERE [user] = @User", conn);
            cmd.Parameters.AddWithValue("@User", useractual); 
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                parola = reader.GetString(0); 
                numarMatricol = reader.GetString(1);
                autorizare = reader.GetInt32(2);
                
            }

            reader.Close();
            
            conn.Close();
           
            
            if (password == parola)
            {
                if (autorizare == 1)
                {
                    user.numeUtilizator = numarMatricol;
                    studenti form1 = new studenti();
                    form1.Show();
                }
                if(autorizare==2)
                {
                    profesori form2=new profesori();
                    user.numeUtilizator = numarMatricol;
                    form2.Show();


                }
                if(autorizare==3)
                {
                    secretar form3= new secretar();
                    user.numeUtilizator = numarMatricol;
                    form3.Show();
                }
                
                

            }
            else
            {
               
            }
            
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
