using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prueba
{
    public partial class Formulario : Form
    {
        Conexion conexion = new Conexion();
        int Id;


        public Formulario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'pruebaDataSet.Pasante' Puede moverla o quitarla según sea necesario.
            this.pasanteTableAdapter.Fill(this.pruebaDataSet.Pasante);
            this.UpdateGrid();
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Conectar();
                int edad = int.Parse(textBox4.Text);
                decimal salario = decimal.Parse(textBox5.Text);
                if (edad < 18)
                {
                    MessageBox.Show("Edad debe ser mayor a 18", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (
                    salario <= 0)
                {
                    MessageBox.Show("Salario debe ser mayor a 0","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    String consulta = "Insert into Pasante (Carnet,Nombres,Apellidos,Edad,Salario) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + "," + textBox5.Text + ");";
                    conexion.SQL(consulta);
                    this.UpdateGrid();
                    conexion.Desconectar();
                    this.Limpiar();
                }

            }

            catch (Exception)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Campos sin llenar,complete el formulario antes de agregar nuevo pasante", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else {
                    MessageBox.Show("Duplicidad de carnet,inserte un nuevo pasante", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Limpiar();
                }
            }
            
        }

        public void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        public void UpdateGrid()
        {
            conexion.Grid(this.dataGridView1, "Select * from Pasante");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            String consulta = "Delete from Pasante where Id=" + Id + ";";
            conexion.SQL(consulta);
            this.UpdateGrid();
            conexion.Desconectar();
            this.Limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Conectar();
                String consulta = "update Pasante set Carnet='" + textBox1.Text + "',Nombres='" + textBox2.Text + "',Apellidos='" + textBox3.Text + "',Edad=" + textBox4.Text + ",Salario=" + textBox5.Text + "where Id=" + Id + ";";
                conexion.SQL(consulta);
                this.UpdateGrid();
                conexion.Desconectar();
                this.Limpiar();
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione fila con datos","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                Id = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Fila seleccionada sin datos","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Limpiar();
            }
           /* Id = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();*/
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox6.Text == "")
            {
                this.UpdateGrid();
            }
               
            else{
                conexion.Conectar();
                String consulta = "Select * from Pasante where Carnet='" + textBox6.Text + "';";
                conexion.SQLBsqueda(consulta);
                conexion.Grid(this.dataGridView1, consulta);
                conexion.Desconectar();
                this.Limpiar();
            }
            


        }
    }
}
