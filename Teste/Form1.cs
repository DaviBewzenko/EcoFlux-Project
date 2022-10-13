using MySql.Data.MySqlClient;

namespace Teste
{
    public partial class Form1 : Form
    {
        string documento;
        string nome;
        string retorno;
        string buscar;
        private MySqlConnection Con;
        private string data_source = "server=localhost; database=EcoFlux; user id=root; password=root;";
        public Form1()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect=true;
            listView1.GridLines=true;

            listView1.Columns.Add("Nome", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Documento", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Retorno", 60, HorizontalAlignment.Left);
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
            try
            {



                Con = new MySqlConnection(data_source);
                string sql = "SELECT * " +
                    "FROM  info " +
                    "WHERE nome = '%nome%'; docoumento = '%documento%'; retorno = '%retorno%';";

                Con.Open();

                MySqlCommand comando = new MySqlCommand(sql, Con);

                MySqlDataReader reader = comando.ExecuteReader();

                listView1.Items.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                    };
                    var linha_listview = new ListViewItem(row);

                    listView1.Items.Add(linha_listview);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}