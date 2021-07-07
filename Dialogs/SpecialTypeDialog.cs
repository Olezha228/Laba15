using laba15.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba15
{
    public partial class SpecialTypeDialog : Form
    {
        CreditType crType;
        FormWorkWithFile fatherForm; 

        public SpecialTypeDialog(CreditType crType, FormWorkWithFile fromFileForm)
        {
            InitializeComponent();

            this.crType = crType;
            this.fatherForm = fromFileForm;

            buttonCancel.Click += (sender, e) =>
            {
                Owner.Enabled = true;
                this.Hide();
                this.Owner.Show();
            };

            buttonOK.Click += (sender, e) =>
            {
                CheckAll();

                WriteInTextBox();

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

        /// <summary>
        /// Логика
        /// </summary>

        private void WriteInTextBox()
        {
            if (crType.TypeName != "")
            {
                string str = SpecialTypeGetString(crType.TypeName);
                fatherForm.richTextBox1.Text = str;

                MyWriteReadClass.WriteInTextFile(str);
            }
            else
            {
                fatherForm.richTextBox1.Text = "Тип кредита не был выбран.";
            }
        }

        private void CheckAll()
        {
            CheckButton(buttonBanking);
            CheckButton(buttonCommercial);
            CheckButton(buttonConsumptive);
            CheckButton(buttonInterstate);
        }

        private void CheckButton(RadioButton radio)
        {
            if (radio.Checked)
                crType.TypeName = radio.Text.ToLower();
        }

        private string SpecialTypeGetString(string type)
        {
            var das = LINQlist(type);

            string str = "";
            if (das.Count() != 0)
            {
                str = "Заимщики, имеющие в кредитах тип " + type + ":\n";
                foreach (var a in das)
                    str += a + "\n";
            }
            else
                str = "Заимщиков с таким типом кредита не найдено!";

            return str;
        }

        private IEnumerable<string> LINQlist(string type)
        {
            var das = (from bor in fatherForm.list
                       from cred in bor.CreditList
                       where cred.TypeOfCredit == type
                       select bor.ToString());

            das = das.Distinct().ToList(); // избегаем дублирования

            return das;
        }

        
    }
}
