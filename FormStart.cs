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
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();

            button_start.Click += ButtonStartClick;
        }

        private void ButtonStartClick(object sender, EventArgs e)
        {
            FormFiles formFiles = new FormFiles(this);
            formFiles.Show();
        }

        private void FormStartLoad(object sender, EventArgs e)
        {

        }
    }
}
