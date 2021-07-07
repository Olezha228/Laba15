using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace laba15
{
    public partial class FormFiles : Form
    {
        string currentFileName = "";
        int handleRepeat = 0;

        public FormFiles(FormStart formStart)
        {
            InitializeComponent();
            formStart.Hide();

            chooseFileButton.Click += (sender, e) =>
            {
                bool moveNext = OpFileDial();

                if (moveNext)
                {
                    FormWorkWithFile form = new FormWorkWithFile(currentFileName);
                    form.Owner = this;
                    this.Hide();
                    form.Show();
                }
            };

            textBoxFileName.MouseDown += (sender, e) =>
            {
                textBoxFileName.Text = "";
                buttonAddFile.Enabled = true;
            };

            textBoxFileName.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (buttonAddFile.Enabled)
                        buttonAddClick(sender, e);
                }
                else
                    buttonAddFile.Enabled = true;
            };

            buttonAddFile.Click += (sender, e) =>
            {
                buttonAddClick(sender, e);
            };

            this.FormClosing += (sender, e) => Application.Exit();
        }

        #region
        private void Form_Files_Load(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
        
        private void buttonAddClick(object sender, EventArgs e)
        {
            FileStream fs1;
            try
            {
                if (File.Exists(@"D:\\laba15db\" + $"{textBoxFileName.Text}" + ".bin"))
                {
                    fs1 = File.Create(@"D:\\laba15db\" + $"{textBoxFileName.Text} - копия {++handleRepeat}" + ".bin");
                    MessageBox.Show("Создан файл: " + @"D:\\laba15db\" + $"{textBoxFileName.Text} - копия {handleRepeat}" + ".bin");
                    fs1.Close();
                }
                else
                {
                    fs1 = File.Create(@"D:\\laba15db\" + $"{textBoxFileName.Text}" + ".bin");
                    MessageBox.Show("Создан файл: " + @"D:\\laba15db\" + $"{textBoxFileName.Text}" + ".bin");
                    fs1.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Имя файла должно быть корректным!");
            }
            finally
            {
                textBoxFileName.Text = "(Введите название файла)";
                buttonAddFile.Enabled = false;
            }
        }
        #endregion


        // методы (бизнес-логика)

        private bool OpFileDial()
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "(*.bin)|*.bin";
            opfd.InitialDirectory = @"D:\\laba15db";

            if (opfd.ShowDialog(this) == DialogResult.OK)
            {
                currentFileName = opfd.FileName;
                return true;
            }
            return false;
        }
    }
}
