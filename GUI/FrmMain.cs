using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoFlux.GUI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void clienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clienteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ecoFluxDataSet);

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'eCOFLUX22DataSet.Clientes'. Você pode movê-la ou removê-la conforme necessário.
            this.clientesTableAdapter.Fill(this.eCOFLUX22DataSet.Clientes);
            // TODO: esta linha de código carrega dados na tabela 'ecoFluxDataSet.cliente'. Você pode movê-la ou removê-la conforme necessário.
            this.clienteTableAdapter.Fill(this.ecoFluxDataSet.cliente);

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            FormCadastro clicForm = new FormCadastro();
            clicForm.ShowDialog();
        }

        private void pesquisarToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.clientesTableAdapter.Pesquisar(this.eCOFLUX22DataSet.Clientes, documentoToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void pesquisarToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
