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
    public partial class CorrectDialog : Form
    {
        public CorrectDialog()
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

            this.Closing += (sender, e) =>
            {
                Owner.Enabled = true;
                this.Hide();
            };
        }
    }
}
