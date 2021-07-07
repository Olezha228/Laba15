using laba15.Classes;
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
    public partial class FormWorkWithFile : Form
    {
        //<summary> Свойста и поля </summary>
        #region

        string FilePath { get; set; }  // путь к нашему файлу

        public List<Borrower> list = new List<Borrower>();  // список должников

        BinaryFormatter bf = new BinaryFormatter();  // класс для сериализации и десериализации данных в двоичном формате

        CreditType crType = new CreditType(); // класс для передачи инф-ии из диалогого окна

        #endregion



        /// <summary>
        /// Конструктор
        /// </summary>
        public FormWorkWithFile(string filePath)
        {
            InitializeComponent();
            FilePath = filePath;

            FillList(); // заполняем список информацией из файла

            buttonBack.Click += (sender, e) =>
            {
                this.Owner.Show();
                this.Hide();
            };

            buttonPrintContent.Click += (sender, e) => 
            {
                FillList();
                FillTreeView();

                FileStream f1 = new FileStream(FilePath, FileMode.Open);
                FillTextBox(f1);
                f1.Close();
            };

            buttonAdd.Click += (sender, e) =>
            {
                AddDialog addDialog = new AddDialog(list, FilePath);
                addDialog.Owner = this;
                addDialog.Show();
                this.Enabled = false;
            };

            buttonDelete.Click += (sender, e) =>
            {
                FillList();

                DeleteSelected();

                FillBinFile();
                FillList();

                FillTreeView();

                /// заполняем текстбокс
                FileStream f1 = new FileStream(FilePath, FileMode.Open);
                FillTextBox(f1);
                f1.Close();

            };

            buttonCorrect.Click += (sender, e) =>
            {
                FillList();

                CorrectSelected();

                FillBinFile();
                FillList();

                FillTreeView();

                ///запись в текстбокс
                FileStream f1 = new FileStream(FilePath, FileMode.Open);
                FillTextBox(f1);
                f1.Close();
            };

            buttonSpecialType.Click += (sender, e) =>
            {
                SpecialTypeDialog specialDialog = new SpecialTypeDialog(crType, this);
                specialDialog.Owner = this;
                specialDialog.Show();
                this.Enabled = false;
            };

            buttonMaxCredit.Click += (sender, e) =>
            {
                GetStringOfMaxCredit();
            };


            this.Closing += (sender, e) => Application.Exit();
        }



        /// <summary>
        /// Логика
        /// </summary>
        #region

        private void FillTextBox(FileStream fs)
        {
            if (list.Count == 0)
            {
                richTextBox1.Text = "База данных пуста!";
            }
            else
            {
                richTextBox1.Text = "";
                for (int i = 0; i < list.Count; i++)
                {
                    Borrower brwr = (Borrower)bf.Deserialize(fs);
                    richTextBox1.Text += (i + 1).ToString() + ". " + brwr.ToString() + "\n";
                }
            }

            fs.Close();
        }

        private void FillTreeView()
        {
            FileStream fs = new FileStream(FilePath, FileMode.Open);

            treeView1.Nodes.Clear();

            if (list.Count == 0)
            {
                TreeNode treeNode = new TreeNode("База данных пуста!");
                richTextBox1.Text = "База данных пуста!";
                treeView1.Nodes.Add(treeNode);

                fs.Close();
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Borrower brwr = (Borrower)bf.Deserialize(fs);
                    TreeNode treeNode = new TreeNode(brwr.ToString() + "\n");
                    treeNode.Tag = brwr;
                    treeView1.Nodes.Add(treeNode);


                    for (int b = 0; b < brwr.CreditList.Count; b++)
                    {
                        TreeNode secondTreeNode = new TreeNode(brwr.CreditList[b].ToString());
                        secondTreeNode.Tag = brwr.CreditList[b];
                        treeView1.Nodes[i].Nodes.Add(secondTreeNode);

                    }

                    treeNode.ExpandAll();
                }

                fs.Close();
            }

        }

        private void FillBinFile()
        {
            File.WriteAllText(FilePath, "");

            FileStream fs = new FileStream(FilePath, FileMode.Create);
            foreach (var bor in list)
            {
                bf.Serialize(fs, bor);
            }
            fs.Close();
        }

        private void FillList()
        {
            FileStream fs = new FileStream(FilePath, FileMode.Open);
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
            finally {
                fs.Close();
            } 
        }

        private void GetStringOfMaxCredit()
        {
            string str = "";
            if (list.Count != 0)
            {
                var sumOfProps = new Func<Borrower, int>((Borrower v) =>
                {
                    return v.CreditList
                          .Sum(p => p.Sum);
                });

                int resultInt = list.Max(l => sumOfProps(l));

                var resultBorrower = list.First(l => sumOfProps(l) == resultInt);

                str = "Максимальный суммарный кредит:\n" + resultBorrower.ToString() + ": "
                                                                                        + resultInt.ToString();

                richTextBox1.Text = str;
            }
            else
            {
                str = "Список заимщиков пуст!";
                richTextBox1.Text = str;
            }

            MyWriteReadClass.WriteInTextFile(str);
        }

        private void DeleteSelected()
        {
            if (treeView1.SelectedNode != null)
            {
                bool isBorrower = true;
                Borrower brwr = new Borrower();
                Credit cred = new Credit();
                try
                {
                    brwr = (Borrower)treeView1.SelectedNode.Tag;
                    isBorrower = true;
                }
                catch
                {
                    cred = (Credit)treeView1.SelectedNode.Tag;
                    isBorrower = false;
                }

                if (isBorrower)
                {
                    DeleteBorrower(brwr);
                }
                else
                {
                    DeleteCredit(cred);
                }
            }
        }

        private void DeleteBorrower(Borrower brwr)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (brwr.Equals(list[i]))
                {
                    list.Remove(list[i]);
                    break;
                }
            }
        }

        private void DeleteCredit(Credit cred)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int k = 0; k < list[i].CreditList.Count; k++)
                {
                    if (cred.Equals(list[i].CreditList[k]))
                    {
                        list[i].CreditList.RemoveAt(k);
                        break;
                    }
                }
            }
        }

        private void CorrectSelected()
        {
            if (treeView1.SelectedNode != null)
            {
                bool isBorrower = true;
                Borrower brwr = new Borrower();
                Credit cred = new Credit();

                try
                {
                    brwr = (Borrower)treeView1.SelectedNode.Tag;
                    isBorrower = true;
                }
                catch
                {
                    cred = (Credit)treeView1.SelectedNode.Tag;
                    isBorrower = false;
                }

                if (isBorrower)
                {
                    CorrectBorrower(brwr);
                }
                else
                {
                    CorrectCredit(cred);
                }
            }
        }

        private void CorrectBorrower(Borrower brwr)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (brwr.Equals(list[i]))
                {
                    list[i].Name = ClassForRandom.Names[(new Random()).Next(0, ClassForRandom.Names.Length)]
                            + " " + ClassForRandom.Surnames[(new Random()).Next(0, ClassForRandom.Surnames.Length)];
                    break;
                }
            }
        }

        private void CorrectCredit(Credit cred)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int k = 0; k < list[i].CreditList.Count; k++)
                {
                    if (cred.Equals(list[i].CreditList[k]))
                    {
                        Random rnd = new Random();
                        list[i].CreditList[k].Sum = rnd.Next(1000, 10000000);
                        list[i].CreditList[k].Days = rnd.Next(10, 1000);
                        list[i].CreditList[k].TypeOfCredit = ClassForRandom.CreditTypes[rnd.Next(0, ClassForRandom.CreditTypes.Length)];
                        break;
                    }
                }
            }
        }

        #endregion
    }
}
