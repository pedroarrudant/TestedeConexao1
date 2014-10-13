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


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string strcon = "Server=localhost;Database=Teste1;Trusted_Connection=True";
                SqlConnection conexao = new SqlConnection(strcon);
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM TbAppTeste", conexao);
                conexao.Open(); 
                cmd2.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable pessoa = new DataTable();
                da.Fill(pessoa);
                dataGridView1.DataSource = pessoa;
                dataGridView1.Enabled = false;
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = "", sobrenome = "", sexo = "";
                string strcon = "Server=localhost;Database=Teste1;Trusted_Connection=True";
                SqlConnection conexao = new SqlConnection(strcon);
                nome = txtNome.Text;
                sobrenome = txtSobrenome.Text;
                sexo = txtSexo.Text;
                SqlCommand cmd = new SqlCommand("INSERT INTO TbAppTeste Values (@nome, @sobrenome, @sexo)", conexao);
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM TbAppTeste", conexao);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@sobrenome", sobrenome);
                cmd.Parameters.AddWithValue("@sexo", sexo);
                conexao.Open();
                cmd.ExecuteNonQuery();
                cmd2.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable pessoa = new DataTable();
                da.Fill(pessoa);
                dataGridView1.DataSource = pessoa;
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
        }
    }
}
