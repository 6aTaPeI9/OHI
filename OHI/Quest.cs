using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHI
{
    //Класс содержащий всю информацию о вопросах находящихся 
    //под одним индексом в базе
    public class Quest
    {
        public Quest(string data)
        {
            Data = data;
            SelectedIndex = -1;
        }

        public string Data { get; set; }
        public int Index { get; set; }
        public Quest Previous { get; set; }
        public Quest Next { get; set; }
        public int SelectedIndex { get; set; }
    }

    //Класс для работы с классом Quest
    public class LinkedQuestList
    {
        Quest last; //Последний элемент
        Quest first; //Первый элемент
        Quest curent; //Текущий элемент который видит пользователь
        public int count = 0; //Количество вопросов

        //Добавляем элемент в класс Quest
        public void Add(string data)
        {
            Quest node = new Quest(data);

            if (curent == null)
            {
                node.Next = null;
                node.Previous = null;
                node.Index = count;
                curent = node;
                last = node;
                first = node;

            }
            else
            {
                last.Next = node;
                node.Previous = last;
                node.Index = count;
                last = node;
            }
            count++;
        }

        //Получаем данные предидущего элемента и переключаем текущий
        public string GetPrev()
        {
            if (curent.Previous != null)
            {
                curent = curent.Previous;
                return curent.Data;
            }
            else
            {
                return "None";
            }
        }

        //Получаем данные следующего элемента и переключаем текущий
        public string GetNext()
        {
            if (curent.Next != null)
            {
                curent = curent.Next;
                return curent.Data;
            }
            else
            {
                return "None";
            }
        }

        //Получаем данные текущего элемента
        public string GetCur()
        {
            if (curent != null)
                return curent.Data;
            else
                return "None";
        }

        //Устанавливает элемент текущим по индексу.
        public void SetCurByIndex(int index)
        {
            if (index > count)
                return;

            Quest iter = first;
            for (int i = 1; i < this.count; i++)
            {
                if (iter.Index == index)
                {
                    curent = iter;
                }
                else
                    iter = iter.Next;
            }
        }

        //Получаем сумму ответов пользователя.
        public int GetHappyIndex()
        {
            int HappyIndex = 0;
            Quest iter;
            iter = first;
            for(int i = 0; i <= this.count-1; i++)
            {
                if (iter.SelectedIndex == -1)
                    return -1;
                HappyIndex += iter.SelectedIndex - 1;
                iter = iter.Next;
            }
            return HappyIndex;
        }

        public int GetCurIndex()
        {
            return curent.Index;
        }

        public void SetSelectedItem(int index)
        {
            curent.SelectedIndex = index;
        }

        public int GetSelectedItem()
        {
            return curent.SelectedIndex;
        }
    }
}
