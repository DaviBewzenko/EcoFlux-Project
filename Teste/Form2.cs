using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


namespace Teste
{
    public partial class Form2 : Form
    {
        string nome;
        string documento;
        string retorno;
        private MySqlConnection Con;
        private string data_source = "server=localhost; database=EcoFlux; user id=root; password=root;";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                Con = new MySqlConnection(data_source);
                Con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nome = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            documento = textBox2.Text;
        }
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            retorno = textBox3.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void Registrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Con = new MySqlConnection(data_source);
                string sql = "INSERT INTO info(nome, documento, retorno)" +
                    "VALUES ('" + nome + "','" + documento + "','" + retorno + "')";

                MySqlCommand comando = new MySqlCommand(sql, Con);

                Con.Open();

                comando.ExecuteReader();

                MessageBox.Show("Dados inseridos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
          

        }

    }
}
