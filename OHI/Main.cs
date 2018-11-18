using System.Windows.Forms;
using System.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace OHI
{
    public partial class Main : Form
    {
        LinkedQuestList _qs;

        public Main()
        {
            InitializeComponent();
        }


        //Добавляем на нашу TableLayout радиобатоны
        private void AddtlpMainRadio()
        {
            string[] quests = _qs.GetCur().Split(';');

            for (int i = 0; i <= quests.Length-1;i++)
            {
                if (string.IsNullOrEmpty(quests[i]))
                    break;
                RadioButton rb = new RadioButton();
                if ((i == _qs.GetSelectedItem()-1) && (_qs.GetSelectedItem() != 0))
                    rb.Checked = true;
                rb.CheckedChanged += new EventHandler(SetSelectedIndex);
                rb.AutoSize = true;
                rb.Text = quests[i];
                tlpMainRadio.Controls.Add(rb,0,i);
                tlpMainRadio.RowCount++;
            }
        }


        //Метод запоминает индекс радиобатона который выбрал пользователь 
        //и окрашивает кнопку с номером вопроса в зеленый цвет
        private void SetSelectedIndex(object sender, System.EventArgs e)
        {
            int i = 1;
            foreach(RadioButton myradbut in tlpMainRadio.Controls)
            {
                if (myradbut.Checked == true)
                {
                    _qs.SetSelectedItem(i);
                }
                i++;
            }

            foreach (QuestPanel btn in flpIconQuestion.Controls)
            {
                if (btn._index == _qs.GetCurIndex()+1)
                {
                    btn.button1.BackColor = Color.Green;
                }
            }
        }
        
        //Метод заполняет двусвязный список Quests.
        private void FillQuest()
        {
            var sqlconn = sqlconnection.GetDBConnection(ConfigurationManager.ConnectionStrings["MySqlCon"].ConnectionString);
            var myResult = MySqlData.MySqlExecuteData.SqlReturnDataset($"Select * from ohi", sqlconn);
            LinkedQuestList qs = new LinkedQuestList();
            if (!myResult.HasError)
            {
                if (myResult.ResultData.Rows.Count > 0)
                {
                    string data = "";
                    int iter;
                    //Проходимся по всем записям которые пришли из базы.
                    for (int i = 0; i < myResult.ResultData.Rows.Count - 1; i++)
                    {
                        iter = 0;
                        data = "";
                        //Группируем записи с одинаковым ID в переменную data добавляя разделить ';'
                        for (int j = 0; (int)myResult.ResultData.Rows[j + i][0] == (int)myResult.ResultData.Rows[i][0]; j++)
                        {
                            data += myResult.ResultData.Rows[j + i][2].ToString() + ";";
                            iter++;
                            try
                            {
                                //Тут супер костыль... У меня не получается сделать проверку на 
                                //существование следующего элемента в коллекции. Проверки на IsNullOrEmpty,
                                //на null - не работают.
                                //Поэтому ловлю ошибку выхода за пределы массива и выхожу из цикла
                                string kostyl = myResult.ResultData.Rows[j + 1 + i][0].ToString();
                            }
                            catch (System.IndexOutOfRangeException)
                            {
                                break;
                            }
                        }
                        qs.Add(data);
                        i += iter - 1;
                        if (i >= myResult.ResultData.Rows.Count - 1)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Отсутствует подключение к базе данных, повторите попытку позже");
                Application.Exit();
            }
            _qs = qs;
        }

        //Заполняем правую панель flowlayout пользовательскими контролами QuestPanel
        private void FillflpIconQuestion()
        {
            QuestPanel qp;
            for (int i = 0; i <= _qs.count-1; i++)
            {
                if (i == 0)
                {
                    qp = new QuestPanel(_qs.GetCur(), i + 1,_qs);
                }
                else
                {
                    qp = new QuestPanel(_qs.GetNext(), i + 1,_qs);

                }
                qp.button1.Click += new EventHandler(draw_cur_quest);
                flpIconQuestion.Controls.Add(qp);
            }
            _qs.SetCurByIndex(0);
        }

        //Метод очищает TableLayout от всех radiobutton и заполняет контейнер новыми переключателями
        private void clear_table_layout()
        {
            List<Control> listControls = tlpMainRadio.Controls.Cast<Control>().ToList();

            foreach (Control control in listControls)
            {
                tlpMainRadio.Controls.Remove(control);
                control.Dispose();
            }

            AddtlpMainRadio();
            IdQuest.Text = (_qs.GetCurIndex()+1).ToString();
        }

        //Событие при нажатии на один из контролов с номером вопроса
        private void draw_cur_quest(object sender, System.EventArgs e)
        {
            clear_table_layout();
        }


        private void Main_Load(object sender, System.EventArgs e)
        {
            FillQuest();
            FillflpIconQuestion();
            AddtlpMainRadio();
        }

        private void button1_Click(object sender, System.EventArgs e) => Application.Exit();

        
        private void btnPrev_Click(object sender, EventArgs e)
        {
            _qs.GetPrev();
            clear_table_layout();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _qs.GetNext();
            clear_table_layout();
        }


        //Вычисляем результат прохождения теста
        private void btnresult_Click(object sender, EventArgs e)
        {
            float HappyIndex = (float)_qs.GetHappyIndex();
            if (HappyIndex == -1.0)
            {
                MessageBox.Show("Ответьте на все вопросы");
                return;
            }
            HappyIndex = (HappyIndex / (_qs.count * 3))*100;
            if (HappyIndex >= 0 && HappyIndex <= 20)
                result.Text = "низкий показатель";
            else if (HappyIndex > 20 && HappyIndex <= 40)
                result.Text = "пониженный показатель";
            else if (HappyIndex > 40 && HappyIndex <= 60)
                result.Text = "средний  показатель";
            else if (HappyIndex > 60 && HappyIndex <= 80)
                result.Text = "повышенный  показатель";
            else if (HappyIndex > 80 && HappyIndex <= 100)
                result.Text = "высокий   показатель";
        }
    }
}
