using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Benner.Enums;
using Benner.Classes;
namespace Benner
{
    public partial class frmCadastroExames : Form
    {
        [DllImport(@"CoParticipacao.dll")]

        public static extern Double Calcular([MarshalAs(UnmanagedType.R8)] Double Valor);

        public frmCadastroExames()
        {
            InitializeComponent();
            Controletxt(false);
            btnInserir.Enabled = true;
        }


        private void btnInserir_Click(object sender, EventArgs e)
        {

            Controletxt(true);
            LimparControles();
            btnInserir.Enabled = false;
            txtnome.Focus();

        }


        private void Controletxt(bool acao)

        {
            txtnome.Enabled = acao;
            txtidade.Enabled = acao;
            txtdatanasc.Enabled = acao;
            cboExame.Enabled = acao;
            txtcpf.Enabled = acao;
            txtdatarealizacao.Enabled = acao;
            btngravar.Enabled = acao;
            btnInserir.Enabled = acao;

        }

        private void LimparControles()
        {
            txtnome.Text = "";
            txtidade.Text = "";
            txtdatanasc.Text = "";
            cboExame.Text = "";
            txtcpf.Text = "";
            txtdatarealizacao.Text = "";
        }

        private void btngravar_Click(object sender, EventArgs e)
        {
            string nome = txtnome.Text.Trim();

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Preencha o nome");
                txtnome.Focus();
                return;

            }
            int.TryParse(txtidade.Text, out int idade);

            if (idade == 0)
            {
                MessageBox.Show("Preencha a idade");
                txtidade.Focus();
                return;

            }
            string cpf = txtcpf.Text.ToString();

            DateTime datanasc;
            try { datanasc = DateTime.Parse(txtdatanasc.Text); }
            catch
            {
                MessageBox.Show("Data de Nascimento Inválida ou em Branco");
                txtdatanasc.Focus();
                return;
            }

            DateTime datarealizacao;

            try { datarealizacao = DateTime.Parse(txtdatarealizacao.Text); }
            catch
            {
                MessageBox.Show("Data de Realização Inválida ou em Branco");
                txtdatarealizacao.Focus();
                return;
            }

            TiposExame tiposExame = Enum.Parse<TiposExame>(string.IsNullOrEmpty(cboExame.Text) ? "OUTROS" : cboExame.Text);

            if (cboExame.Text == "")
            {
                MessageBox.Show("Informe o tipo de Exame");
                cboExame.Focus();
                return;
            }
            Paciente paciente = new Paciente(nome, datanasc, idade, cpf);
            Exames exame = new Exames(ValorExame(), tiposExame.ToString(), datarealizacao);

            paciente.AdicionarExames(exame);

            Banco banco = new Banco();
            banco.Inserir(paciente);

            banco = null;
            Controletxt(false);
            LimparControles();
            btnInserir.Enabled = true;

        }

        private double ValorExame()
        {
            TiposExame tiposExame = Enum.Parse<TiposExame>(string.IsNullOrEmpty(cboExame.Text) ?
                    "OUTROS" : cboExame.Text);

            var exame = tiposExame;

            switch (exame.ToString())
            {
                case "SANGUE":
                    return 1001.00;
                    break;
                case "URINA":
                    return 500.00;
                    break;
                case "CARDIACO":
                    return 2500.00;
                    break;
                default:
                    return 5000.00;
                    break;
            }

        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
