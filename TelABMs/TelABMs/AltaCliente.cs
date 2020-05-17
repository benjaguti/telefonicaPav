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
using TelABMs.Entidades;

namespace TelABMs
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            CargarCmbBarrio();
            CargarCmbTipoCliente();
            CargarGrilla();

        }

        private void CargarGrilla()
        {
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                cn.Open();
                String consulta = "SELECT * FROM Cliente";
                SqlCommand comando = new SqlCommand();
                comando.Parameters.Clear();
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                comando.Connection = cn;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                grillaCliente.DataSource = tabla;


            }
            catch (Exception)
            {
                MessageBox.Show("error al cargar grilla");
            }
            finally
            {
                cn.Close();
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtCalle.Text = "";
            txtNumero.Text = "";
            txtPiso.Text = "";
            cmbBarrio.Text = "";
            cmbTipoCliente.Text = "";
            txtCuit.Text = "";
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        private void CargarCmbBarrio()
        {


            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = "SELECT * FROM Barrio";


                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();

                cmd.Connection = cn;

                DataTable tabla = new DataTable();

                //creo esta sentencia Dataadapter para que ejecute y lo cargue a la tabla recien creada
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                cmbBarrio.DataSource = tabla;
                cmbBarrio.DisplayMember = "Nombre_Barrio";
                cmbBarrio.ValueMember = "Cod_Barrio";
                cmbBarrio.SelectedIndex = -1;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error inesperado");
            }
            finally
            {
                cn.Close();
            }

        }


        private void CargarCmbTipoCliente()
        {


            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();


                string consulta = "SELECT * FROM Tipo_Cliente";


                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();

                cmd.Connection = cn;

                DataTable tabla = new DataTable();

                //creo esta sentencia Dataadapter para que ejecute y lo cargue a la tabla recien creada
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                cmbTipoCliente.DataSource = tabla;
                cmbTipoCliente.DisplayMember = "Nombre";
                cmbTipoCliente.ValueMember = "Id_tipo_cliente";
                cmbTipoCliente.SelectedIndex = -1;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error inesperado");
            }
            finally
            {
                cn.Close();
            }

        }




        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            Clientes c = new Clientes();
            // se usa .Trim que elimina espacios
            c.NombreCliente = txtNombre.Text.Trim();
            c.CalleCliente = txtCalle.Text.Trim();
            c.NumeroCalleCliente = int.Parse(txtNumero.Text);
            c.PisoCliente = int.Parse(txtPiso.Text);
            c.CodBarrioCliente = (int)cmbBarrio.SelectedValue;
            c.TipoCliente = (int)cmbTipoCliente.SelectedValue;
            c.CuitCliente = txtCuit.Text.Trim();

            bool resultado = InsertarCliente(c);

            if (resultado)
            {
                MessageBox.Show("Cliente cargado con exito");
                LimpiarCampos();
                CargarCmbBarrio();
                CargarGrilla();

            }
            else
            {
                MessageBox.Show("error al cargar persona");
            }

        }

        private bool InsertarCliente(Clientes cli)
        {
            String cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"];
            SqlConnection cn = new SqlConnection(cadenaConexion);
            bool resultado = false;
            try
            {
                SqlCommand comando = new SqlCommand();
                String consulta = "INSERT INTO Cliente (Nombre_Razon_Social, Calle, Nro, Piso, Cod_Barrio, Id_Tipo_Cliente, CUIT) VALUES (@nombreRazonSocial,@calle,@nro,@piso,@codBarrio,@tipoCli,@cuit)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nombreRazonSocial", cli.NombreCliente);
                comando.Parameters.AddWithValue("@calle", cli.CalleCliente);
                comando.Parameters.AddWithValue("@nro", cli.NumeroCalleCliente);
                comando.Parameters.AddWithValue("@piso", cli.PisoCliente);
                comando.Parameters.AddWithValue("@codBarrio", cli.CodBarrioCliente);
                comando.Parameters.AddWithValue("@tipoCli", cli.TipoCliente);
                comando.Parameters.AddWithValue("@cuit", cli.CuitCliente);
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                cn.Open();
                comando.Connection = cn;
                comando.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void grillaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

