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
            string strcon = "Server=localhost;Database=Teste1;Trusted_Connection=True";
            SqlConnection conexao = new SqlConnection(strcon);
            try
            {
                SqlCommand cmd2 = new SqlCommand("dbo.sp_SELECAO", conexao);
                conexao.Open(); 
                cmd2.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable pessoa = new DataTable();
                da.Fill(pessoa);
                dataGridView1.DataSource = pessoa;
                dataGridView1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string strcon = "Server=localhost;Database=Teste1;Trusted_Connection=True";
            SqlConnection conexao = new SqlConnection(strcon);            
            try
            {
                string nome = "", sobrenome = "", sexo = "";
                nome = txtNome.Text;
                sobrenome = txtSobrenome.Text;
                sexo = txtSexo.Text;
                SqlCommand cmd = new SqlCommand("dbo.sp_INSERCAO", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@sobrenome", sobrenome);
                cmd.Parameters.AddWithValue("@sexo", sexo);
                SqlCommand cmd2 = new SqlCommand("dbo.sp_SELECAO", conexao);
                cmd2.CommandType = CommandType.StoredProcedure;
                conexao.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable pessoa = new DataTable();
                da.Fill(pessoa);
                dataGridView1.DataSource = pessoa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
