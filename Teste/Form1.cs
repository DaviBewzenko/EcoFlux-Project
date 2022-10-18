using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Teste
{
    public partial class Form1 : Form
    {
        string buscar;
        private MySqlConnection Con;
        private string data_source = "server=localhost; database=EcoFlux; user id=root; password=root;";

        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();

        }

        private void CarregarDados()
        {
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Retorno", typeof(int));

            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {
            Form2 clicForm = new Form2();
            clicForm.ShowDialog();

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(Conn.StrCon))
                {
                    cn.Open();


                    var sqlQuery = "SELECT * FROM table";
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, cn)
                    {
                        using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }

            } catch (Exception ex)
            {
                ToolStripStatusLabel1.Text = "Falha";
                StatusStrip.Refresh();

                MessageBox.Show("Falha");
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conn.StrCon))
                {
                    cn.Open();


                    var sqlQuery = "SELECT * FROM table where Nome='" + txtBuscar.Text + "'";
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, cn)
                    {
                        using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }

            }
            catch (Exception ex)
            {
                ToolStripStatusLabel1.Text = "Falha";
                StatusStrip.Refresh();

                MessageBox.Show("Falha");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            SalvarCliente();
            this.Close(); 
        }

        private void SalvarCliente()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conn.StrCon))
                {
                    cn.Open();

                    var sql = "";

                    sql = "UPDATE tb_cliente (Nome, Documento, Retorno)Values(@Nome,@Documento,@Retorno)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        ToolStripStatusLabel1.Text = "Salvando o cliente.";
                        StatusStrip1.Refresh();

                        cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@Documento", txtDocumento.Text);
                        cmd.Parameters.AddWithValue("@Retorno", txtRetorno.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    }
}
            


