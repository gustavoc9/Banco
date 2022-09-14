using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_GC___SA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Data: " + DateTime.Now.ToString("dd/MM/yyyy");
            statusStrip1.Items[1].Text = "Hora: " + DateTime.Now.ToString("hh:mm:ss");
            statusStrip1.Items[2].Text = "Versão 2.0";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar?", "Confirme",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja limpar?", "Confirme",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            txtmeses.Clear();
            textBox7.Clear();
            lstreajuste.Items.Clear();
            pictureBox1.Image = Properties.Resources.add_user_female;
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            textBox6.Clear();
            textBox1.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                do
                {
                    MessageBox.Show("Favor selecione uma foto!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                while (openFileDialog1.ShowDialog() == DialogResult.Cancel);
            }
            pictureBox1.Load(openFileDialog1.FileName);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            txtmeses.Text = Convert.ToString(hscmeses.Value);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form2 Sobre = new Form2();
            Sobre.ShowDialog();
            Sobre.Dispose();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            double inicial, reajuste, juros;
            int meses, c;
            if (textBox4.Text == "")
            {
                MessageBox.Show("Favor digitar o valor da aplicação", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
            } 
            else if (txtmeses.Text == "")
            {
                MessageBox.Show("Favor digitar a qntd. de meses", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmeses.Focus();
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Favor digitar o juros", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Focus();
            }
                
            else
            {
                lstreajuste.Items.Clear();
                inicial = float.Parse(textBox4.Text);
                meses = int.Parse(txtmeses.Text);
                juros = float.Parse(textBox7.Text);
                reajuste = inicial;
                for (c = 1; c <= meses; c++)
                {
                    reajuste = reajuste + reajuste * juros / 100;
                    lstreajuste.Items.Add(Convert.ToString(c) + "°          " +
                        reajuste.ToString("R$ ###,##0.00"));
                }
            }  
        }
    }
}
