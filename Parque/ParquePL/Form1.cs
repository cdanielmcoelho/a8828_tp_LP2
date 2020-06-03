using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ParqueBO;
using ParqueBL;

namespace ParquePL
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Limpa Campos
        /// </summary>
        private void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            listBox1.Items.Clear();
        }
        /// <summary>
        /// Carregar campos do separador Listar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mt"></param>
        /// <param name="s"></param>
        /// <param name="d"></param>
        private void CarregaCampos(int id, string mt, Sector s, DateTime d)
        {
            textBox15.Text = id.ToString();
            textBox14.Text = mt;
            textBox6.Text = s.ToString();
            textBox13.Text = d.ToString();   
        }
    
        /// <summary>
        /// Carregar Carros
        /// </summary>
        private void CarregarCarrosLB()
        {
            listBox1.Items.Clear();
            var car = ParqueBL.Regras.GetCarros();
            if (car == null || car.Length == 0)
                return;

            foreach (var c in car)
                if (c != null)                  
                    listBox1.Items.Add(c);
            listBox1.DisplayMember = "DescricaoCarro";
        }
        /// <summary>
        /// Carrega DataGrid com ao array carros
        /// </summary>
        private void CarregarCarros()
        {
            dataGridView1.DataSource = Regras.GetCarros();
        }
        /// <summary>
        /// Carrega DataGrid com ao array carros Reserva
        /// </summary>
        private void CarregarCarrosR()
        {
            dataGridView1.DataSource = Regras.GetCarrosReserva();
            
        }
        /// <summary>
        /// Carrega Array Auxiliar para a DataGridView
        /// </summary>
        private void CarregarCarrosAux()
        {
            //int rowCount = dataGridView1.Rows.Count;
            //for (int i = 0; i < rowCount; i++)
            //{
            //    dataGridView1.Rows.RemoveAt(i);
            //    --rowCount;
            //}
           // dataGridView1.Rows.Clear();
           // dataGridView1.DataSource = null;
            dataGridView1.DataSource = Regras.GetCarrosAux();

        }
        /// <summary>
        /// Carregar Reservas
        /// </summary>
        private void CarregarCarrosReserva()
        {        
            listBox1.Items.Clear();
            var car = ParqueBL.Regras.GetCarrosReserva();
            if (car == null || car.Length == 0)
                return;
            foreach (var c in car)
                if (c != null)
                    listBox1.Items.Add(c);
            listBox1.DisplayMember = "DescricaoCarro";
        }

        /// <summary>
        /// Actualiza capacidade
        /// </summary>
        private void Capacidade()
        {
            int total, lugaresLivres, lugaresOcupados;
            Regras.ConsultaLugares(out total, out lugaresLivres, out lugaresOcupados);
            textBox5.Text = total.ToString();
            textBox3.Text = lugaresOcupados.ToString();
            textBox4.Text = lugaresLivres.ToString();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
            string filePath;
            string FileName = "ParqueDados.bin";
            filePath = AppDomain.CurrentDomain.BaseDirectory;
            var nParque = Enum.GetValues(typeof(Sector));
            foreach (var sect in nParque)
                comboBox1.Items.Add(sect.ToString());   
            // Abre o ficheiro caso exista
            Regras.GetDados(@filePath, FileName);
            Capacidade();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Adicionar Carro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {  
            try
            {
                int i = int.Parse(textBox1.Text);
                DateTime d = dateTimePicker1.Value;
                if (textBox2.Text == "")
                    throw new Exception("É necessario matricula...");
                var s = (Sector)Enum.Parse(typeof(Sector), comboBox1.SelectedItem.ToString());
                Carro c = new Carro(i, textBox2.Text, s, d);
                bool x = Regras.AddCarroBL(c);
                Capacidade();
                LimparCampos();
                CarregarCarros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Botão Sair
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        /// <summary>
        /// Listar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            CarregarCarrosLB();
            CarregarCarros();
           
        }

        
        /// <summary>
        /// Reserva 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                 int i = int.Parse(textBox1.Text);
                 DateTime d = dateTimePicker1.Value;
                 var s = (Sector)Enum.Parse(typeof(Sector), comboBox1.SelectedItem.ToString());
                 Carro c = new Carro(i, textBox2.Text, s, d);
                 bool x = Regras.AddReservaBL(c);
                 Capacidade();
                 LimparCampos();
            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }
        /// <summary>
        /// Remover Carro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                Carro c = Regras.GetCarroByMatricula2(textBox2.Text, out i);
                bool b = Regras.RemoveCarro(i);
                if (b == true)
                    MessageBox.Show("Registo Removido");
                Capacidade();
                CarregarCarros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Procurar Carro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
           int i;
           
           try
            {
                if (textBox14.Text == "")
                    throw new Exception("É necessario matricula...");
               Carro c = Regras.GetCarroByMatricula2(textBox14.Text, out i);
               listBox1.Items.Clear();
               listBox1.Items.Add(c);
               listBox1.DisplayMember = "DescricaoCarro";
               CarregaCampos(c.Id, c.Matricula, c.Set, c.DataEntrada);
               bool x = Regras.AddAuxBL(c);
               CarregarCarrosAux();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        /// <summary>
        /// Guardar dados em ficheiro binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath;
                string FileName = "ParqueDados.bin";
                filePath = AppDomain.CurrentDomain.BaseDirectory;
                // Salva os dados no ficheiro
                Regras.SaveDados(@filePath, FileName);
                MessageBox.Show("Ficheiro Guardado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CarregarCarrosReserva();
            CarregarCarrosR();
        }
        /// <summary>
        /// Actualiza Reservas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                Regras.ActualizarReservasBL();
                Capacidade();
                MessageBox.Show("Reservas Actualizadas...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
    }
}
