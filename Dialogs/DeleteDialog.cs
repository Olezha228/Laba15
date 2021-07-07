using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba15
{
    public partial class DeleteDialog : Form
    {
        public DeleteDialog()
        {
            InitializeComponent();

            buttonCancel.Click += (sender, e) =>
            {
                Owner.Enabled = true;
                this.Hide();
                this.Owner.Show();
            };

            buttonOK.Click += (sender, e) =>
            {
                Owner.Enabled = true;



                this.Hide();
                this.Owner.Show();
            };

            textBox1.KeyPress += (sender, e) =>
            {
                if ((!Char.IsDigit(e.KeyChar) && (e.KeyChar != 8)) || (textBox1.Text.Length >= 4) && (e.KeyChar != 8))
                {
                    e.Handled = true;
                }
            };

            this.Closing += (sender, e) =>
            {
                Owner.Enabled = true;
                this.Hide();
            };
        }

        // methods

    }
}
