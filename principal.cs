using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnCryptDecrypt
{
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {

            error.Clear();
            string escrito = textBox2.Text.Trim();
            string cripto = cript.Encriptar(escrito, true, textBox1.Text);
            textBox4.Visible = false;

            textBox3.Text = cripto;
            btnDecrypt.Enabled = true;

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string cripto = textBox3.Text.Trim();
            string result = cript.Descriptar(cripto, true, textBox1.Text);
            textBox4.Text = result;
            textBox4.Visible = true;

        }
    }
}