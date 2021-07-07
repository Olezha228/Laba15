using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba15
{
    public partial class AddDialog : Form
    {
        /// <summary>
        /// поля класса
        /// </summary>
        #region
        List<Borrower> list = new List<Borrower>();

        int count = 0;

        BinaryFormatter bf = new BinaryFormatter();

        string path;
        #endregion

        public AddDialog(List<Borrower> list, string FilePath)
        {
            InitializeComponent();
            this.list = list;
            this.path = FilePath;

            buttonCancel.Click += (sender, e) =>
            {
                Owner.Enabled = true;
                this.Hide();
                this.Owner.Show();
            };

            buttonOK.Click += (sender, e) =>
            {
                OKClicked(sender, e);
            };

            textBoxBorrowers.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    OKClicked(sender, e);
                }
                if ((!Char.IsDigit(e.KeyChar) && (e.KeyChar != 8)) || (textBoxBorrowers.Text.Length >=4) && (e.KeyChar != 8))
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


        // обработчики событий

        private void OKClicked(object sender, EventArgs e)
        {
            Owner.Enabled = true;
            if (textBoxBorrowers.Text.Length == 0)
                count = 0;
            else
                count = Convert.ToInt32(textBoxBorrowers.Text);

            FileStream fs = new FileStream(path, FileMode.Append);
            AddBorrowers(fs);
            fs.Close();

            this.Hide();
            this.Owner.Show();
        }

        // methods
        private void AddBorrowers(FileStream fs)
        {
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                Borrower brwr = new Borrower();
                brwr.Name = ClassForRandom.Names[rnd.Next(0, ClassForRandom.Names.Length)]
                                        + " " + ClassForRandom.Surnames[rnd.Next(0, ClassForRandom.Surnames.Length)];

                int k = rnd.Next(1, 5);
                for (int h = 0; h < k; h++)
                {
                    brwr.Add(new Credit(rnd.Next(1000, 10000000), rnd.Next(10, 1000),
                    ClassForRandom.CreditTypes[rnd.Next(0, ClassForRandom.CreditTypes.Length)]));
                }

                bf.Serialize(fs, brwr);
            }
            fs.Close();

            FillList(new FileStream(path, FileMode.Append));
        }

        private void FillList(FileStream fs)
        {
            list = new List<Borrower>();
            try
            {
                while (true)
                {
                    Borrower brwr = (Borrower)bf.Deserialize(fs);
                    list.Add(brwr);
                }
            }
            catch (Exception ex)
            {

            }
            fs.Close();
        }
    }
}
