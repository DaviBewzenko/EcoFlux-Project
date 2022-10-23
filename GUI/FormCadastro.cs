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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EcoFlux.GUI
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-I19LFF4; integrated security=SSPI; initial catalog=ECOFLUX22");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dt;

        private void FormCadastro_Load(object sender, EventArgs e)
        {
            cn.Open();
        }

        private void registrarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string strSQL = "Select Documento from dbo.Clientes where Documento = " + docBox2.Text;
                cmd.Connection = cn;
                cmd.CommandText = strSQL;
                dt = cmd.ExecuteReader();
                if (dt.HasRows)
                {
                    MessageBox.Show("Documento ja cadastrado");
                }
                else
                {
                    if (!dt.IsClosed) { dt.Close(); }
                    strSQL = "insert into dbo.Clientes(Nome,Documento,Retorno)values(@nome,@documento,@retorno)";

                    cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = nameBox1.Text;
                    cmd.Parameters.Add("@documento", SqlDbType.VarChar).Value = docBox2.Text;
                    cmd.Parameters.Add("@retorno", SqlDbType.VarChar).Value = retBox3.Text;

                    cmd.Connection = cn;
                    cmd.CommandText = strSQL;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dados Inseridos");


                    cmd.Parameters.Clear();
                    cn.Close();


                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                cn.Close();

            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            FrmMain clicForm = new FrmMain();
            clicForm.ShowDialog();
        }

        private void atualizarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Close();
                cn.Open();
                string strUp = $"update dbo.Clientes set Retorno = '{retBox3.Text}' WHERE Documento = '{docBox2.Text}'";
                SqlCommand cmdUp = new SqlCommand(strUp, cn);
                cmdUp.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                cn.Close();

            }
        }
    }
}

