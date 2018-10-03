using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    class Conexion
    {

        SqlConnection conector;

        public void Conectar()
        {
            conector = new SqlConnection("Data Source = MENDOZA; Initial Catalog = Prueba; Integrated Security = True");
            conector.Open();
        }

        public void Desconectar()
        {
            conector.Close();
        }

        public void SQL(String consulta)
        {
            SqlCommand comando = new SqlCommand(consulta,conector);

            int filas = comando.ExecuteNonQuery();

            if (filas > 0)
            {
                MessageBox.Show("Base de datos modificada", "Exito", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Base de datos sin modificar", "Sin exito", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        public void SQLBsqueda(String consulta)
        {
            SqlCommand comando = new SqlCommand(consulta, conector);
            comando.ExecuteNonQuery();
            
        }


        public void Grid(DataGridView datagrid, String consulta)
        {
            this.Conectar();
            System.Data.DataSet datos = new System.Data.DataSet();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta,conector);
            adaptador.Fill(datos, "Pasante");
            datagrid.DataSource = datos;
            datagrid.DataMember = "Pasante";
            this.Desconectar();
        }



    }
}
