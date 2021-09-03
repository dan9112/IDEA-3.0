using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDEA_3._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            checkBox.CheckedChanged += checkBox_CheckedChanged;
            textBox7.TextChanged += textBox7_TextChanged;
            textBox1.TextChanged += textBox1_TextChanged;
        }
        private bool show = false;//не выводить
        private bool operation = false;//Шифрование
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                operation = false;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                operation = true;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked != true) show = false;
            else show = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            char s;
            string t = "";
            if (textBox1.Text != "") textBox1.Text = "";
            for (int i = 0; i < 4; i++)
            {
                int x = rnd.Next(1, 65535);
                s = (char)x;
                t += s.ToString();
            }
            textBox1.Text = t;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            char s;
            string t = "";
            if (textBox7.Text != "") textBox7.Text = "";
            for (int i = 0; i < 8; i++)
            {
                int x = rnd.Next(1, 65535);
                s = (char)x;
                t += s.ToString();
            }
            textBox7.Text = t;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            checkBox.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная программа разработана для шифрования и дешифрования алгоритмом IDEA слова, состоящего из не более, чем 4 символов, ключом, состоящим из 8 символов.\n\n1. Заполните окно 'Слово' одним или более символами, но не более четырех.\n    Можно сгенерировать случайное слово нажатием кнопки 'Случайное слово'.\n2. Заполните окно 'Ключ шифрования' восемью символами.\n    Можно сгенерировать случайный ключ нажатием кнопки 'Случайный ключ'.\n3. Выберите режим работы программы. По умолчанию установлен режим 'Шифрование'.\n4. Выберите демонстрацию работы алгоритма в случае необходимости. При выборе данного пункта после выполнения работы программы в отдельном окне будут показаны промежуточные значения слова и подключи в виде таблицы\n5. Нажмите кнопку 'Выполнить' для получения результата. Полученное слово будет представлено в окне 'Результат'.\nДля удобства под каждой строкой символов представлены окна с кодом каждого символа.\n\nКнопка 'Очистка окон' возвращает все элементы к первоначальномуначальному виду.\nКнопка 'Справка' открывает информационное окно.\nКнопка 'Выход' закрывает программу.", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) MessageBox.Show("Вы не ввели слово!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox1.Text.Length > 4) MessageBox.Show("Слово не может быть длиннее 4 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox7.Text.Length != 8) MessageBox.Show("Ключ шифрования должен содержать ровно 8 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                List<int> s = new List<int>();//Слово
                s.Add(Convert.ToInt32(textBox2.Text, 16));
                s.Add(Convert.ToInt32(textBox3.Text, 16));
                s.Add(Convert.ToInt32(textBox4.Text, 16));
                s.Add(Convert.ToInt32(textBox5.Text, 16));

                List<int> Key = new List<int>();//128-битный ключ
                Key.Add(Convert.ToInt32(textBox8.Text, 16));
                Key.Add(Convert.ToInt32(textBox9.Text, 16));
                Key.Add(Convert.ToInt32(textBox10.Text, 16));
                Key.Add(Convert.ToInt32(textBox11.Text, 16));
                Key.Add(Convert.ToInt32(textBox12.Text, 16));
                Key.Add(Convert.ToInt32(textBox13.Text, 16));
                Key.Add(Convert.ToInt32(textBox14.Text, 16));
                Key.Add(Convert.ToInt32(textBox15.Text, 16));

                Show(IDEA.Algorithm(s, Key, operation));
            }
        }
        private void Show(List<int> a)
        {
            if (a.Count > 0)
            {
                if (a[0] >= 0)
                {
                    for (int i = 36; i < 40; i++)
                    {
                        if (a[i] / 4096 != 0) groupBox4.Controls["textBox" + (i - 20).ToString()].Text = Convert.ToString(a[i], 16);
                        else
                        {
                            groupBox4.Controls["textBox" + (i - 20).ToString()].Text = "0";
                            if (a[i] / 256 != 0) groupBox4.Controls["textBox" + (i - 20).ToString()].Text += Convert.ToString(a[i], 16);
                            else
                            {
                                groupBox4.Controls["textBox" + (i - 20).ToString()].Text += "0";
                                if (a[i] / 16 != 0) groupBox4.Controls["textBox" + (i - 20).ToString()].Text += Convert.ToString(a[i], 16);
                                else groupBox4.Controls["textBox" + (i - 20).ToString()].Text += "0" + Convert.ToString(a[i], 16);
                            }
                        }
                    }
                    if (textBox6.Text != "") textBox6.Text = "";
                    textBox6.Text += (char)Convert.ToInt32(textBox16.Text, 16);
                    textBox6.Text += (char)Convert.ToInt32(textBox17.Text, 16);
                    textBox6.Text += (char)Convert.ToInt32(textBox18.Text, 16);
                    textBox6.Text += (char)Convert.ToInt32(textBox19.Text, 16);
                    if (show == true) TW(a);
                }
                else MessageBox.Show("В процеесе генерации подключей получены некорректные значения! Дешифрование с заданным ключом невозможно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Lists.K.Clear();
        }
        private void TW(List<int> a)
        {
            Form2 f = new Form2(a, Lists.K);
            /*Form2.Table(a, Lists.K);*/
            f.ShowDialog();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.TextLength != 8) textBox7.ForeColor = System.Drawing.Color.Red;
            else textBox7.ForeColor = System.Drawing.Color.Black;
            textBox8.Text = "0000";
            textBox9.Text = "0000";
            textBox10.Text = "0000";
            textBox11.Text = "0000";
            textBox12.Text = "0000";
            textBox13.Text = "0000";
            textBox14.Text = "0000";
            textBox15.Text = "0000";
            for (int i = textBox7.TextLength - 1; i >= 0; i--)
            {
                int x = (int)textBox7.Text[i];
                string s = Convert.ToString(x, 16);
                if (s.Length == 4) groupBox2.Controls["textBox" + (i + 16 - textBox7.TextLength).ToString()].Text = s;
                else
                {
                    s = "0" + s;
                    if (s.Length == 4) groupBox2.Controls["textBox" + (i + 16 - textBox7.TextLength).ToString()].Text = s;
                    else
                    {
                        s = "0" + s;
                        if (s.Length == 4) groupBox2.Controls["textBox" + (i + 16 - textBox7.TextLength).ToString()].Text = s;
                        else groupBox2.Controls["textBox" + (i + 16 - textBox7.TextLength).ToString()].Text = "0" + s;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength <= 4) textBox1.ForeColor = System.Drawing.Color.Black;
            textBox2.Text = "0000";
            textBox3.Text = "0000";
            textBox4.Text = "0000";
            textBox5.Text = "0000";
            for (int i = textBox1.TextLength - 1; i >= 0; i--)
            {
                int x = (int)textBox1.Text[i];
                string s = Convert.ToString(x, 16);
                if (s.Length == 4) groupBox1.Controls["textBox" + (i + 6 - textBox1.TextLength).ToString()].Text = s;
                else
                {
                    s = "0" + s;
                    if (s.Length == 4) groupBox1.Controls["textBox" + (i + 6 - textBox1.TextLength).ToString()].Text = s;
                    else
                    {
                        s = "0" + s;
                        if (s.Length == 4) groupBox1.Controls["textBox" + (i + 6 - textBox1.TextLength).ToString()].Text = s;
                        else groupBox1.Controls["textBox" + (i + 6 - textBox1.TextLength).ToString()].Text = "0" + s;
                    }
                }
            }
        }
    }
    class Lists
    {
        public static List<int> K = new List<int>();//Подключи
        public static bool In(List<int> Key)//Генерация подключей шифрования
        {
            bool flag = true;
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    K.Add(Key[i]);
                    if (Key[i] == 0 && (i == 0 || i == 3)) flag = false;
                }
                Key = Count.ShiftL(Key, 25);
            }
            for (int i = 0; i < 4; i++)
            {
                if (Key[i] == 0 && (i == 0 || i == 3)) flag = false;
                K.Add(Key[i]);
            }
            if (flag == false)
            {
                var result = MessageBox.Show("Получены некорректные подключи! Полученное зашифрованное слово невозможно будет дешифровать! Рекомендуется сменить ключ шифрования! Продолжить процесс шифрования?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return (false);
            }
            return (true);
        }
        public static bool Out(List<int> Key)//Генерация подключей дешифрования
        {
            Key = Count.ShiftL(Key, 22);
            if (Key[0] == 0 || Key[3] == 0) return (false);
            K.Add(Count.MInv(Key[0]));
            K.Add(Count.AdInv(Key[1]));
            K.Add(Count.AdInv(Key[2]));
            K.Add(Count.MInv(Key[3]));
            for (int i = 0; i < 2; i++)
            {
                Key = Count.ShiftR(Key);
                if (Key[2] == 0 || Key[5] == 0) return (false);
                K.Add(Key[6]);
                K.Add(Key[7]);
                K.Add(Count.MInv(Key[2]));
                K.Add(Count.AdInv(Key[4]));
                K.Add(Count.AdInv(Key[3]));
                K.Add(Count.MInv(Key[5]));
                K.Add(Key[0]);
                K.Add(Key[1]);

                Key = Count.ShiftR(Key);
                if (Key[4] == 0 || Key[7] == 0 || Key[1] == 0) return (false);
                K.Add(Count.MInv(Key[4]));
                K.Add(Count.AdInv(Key[6]));
                K.Add(Count.AdInv(Key[5]));
                K.Add(Count.MInv(Key[7]));
                K.Add(Key[2]);
                K.Add(Key[3]);
                K.Add(Count.AdInv(Key[0]));
                K.Add(Count.MInv(Key[1]));

                Key = Count.ShiftR(Key);
                if (Key[6] == 0 || Key[0] == 0 || Key[3] == 0) return (false);
                K.Insert(K.Count - 2, Count.MInv(Key[6]));
                K.Insert(K.Count - 1, Count.AdInv(Key[7]));
                K.Add(Key[4]);
                K.Add(Key[5]);
                K.Add(Count.MInv(Key[0]));
                if (i == 0)
                {
                    K.Add(Count.AdInv(Key[2]));
                    K.Add(Count.AdInv(Key[1]));
                }
                else
                {
                    K.Add(Count.AdInv(Key[1]));
                    K.Add(Count.AdInv(Key[2]));
                }
                K.Add(Count.MInv(Key[3]));
            }
            return (true);
        }
    }
    class Count//Класс вспомогательных математических операций
    {

        public static int UP(int a, int b, bool c)//умножение по модулю 2^16 +1
        {
            if (c == true && b == 0) b = 65536;
            return (Convert.ToInt32(Math.BigMul(a, b) % 65537));
        }
        public static int SP(int a, int b)//сложение по модулю 2^16
        {
            return ((a + b) % 65536);
        }

        public static int MInv(int i)//мультипликативная инверсия
        {
            if (i == 1) return (i);
            else return ((65537 - (65537 / i) * MInv(65537 % i) % 65537) % 65537);
        }
        public static int AdInv(int a)//аддитивная инверсия
        {
            return (65536 - a);
        }
        public static List<int> ShiftL(List<int> a, int y)//сдвиг на "y" позиций влево
        {
            a = X_10_to_2(a);
            List<int> b = new List<int>();
            for (int i = 0; i < a.Count - y; i++) b.Add(a[i + y]);
            for (int i = 0; i < y; i++) b.Add(a[i]);
            return (X_2_to_10(b));
        }
        public static List<int> ShiftR(List<int> a)//сдвиг на 25 позиций вправо
        {
            a = X_10_to_2(a);
            List<int> b = new List<int>();
            for (int i = a.Count - 25; i < a.Count; i++) b.Add(a[i]);
            for (int i = 0; i < a.Count - 25; i++) b.Add(a[i]);
            return (X_2_to_10(b));
        }
        private static List<int> X_10_to_2(List<int> a)//перевод в 2 систему счисления
        {
            List<int> bin = new List<int>();
            for (int i = 0; i < a.Count; i++)
            {
                for (int k = 4; k > 0; k--)
                {
                    int z = a[i] % Convert.ToInt32(Math.Pow(16, k));
                    z /= Convert.ToInt32(Math.Pow(16, k - 1));
                    switch (z % 16)
                    {
                        case 0:
                            {
                                bin.Add(0);
                                bin.Add(0);
                                bin.Add(0);
                                bin.Add(0);
                                break;
                            }
                        case 1:
                            {
                                bin.Add(0);
                                bin.Add(0);
                                bin.Add(0);
                                bin.Add(1);
                                break;
                            }
                        case 2:
                            {
                                bin.Add(0);
                                bin.Add(0);
                                bin.Add(1);
                                bin.Add(0);
                                break;
                            }
                        case 3:
                            {
                                bin.Add(0);
                                bin.Add(0);
                                bin.Add(1);
                                bin.Add(1);
                                break;
                            }
                        case 4:
                            {
                                bin.Add(0);
                                bin.Add(1);
                                bin.Add(0);
                                bin.Add(0);
                                break;
                            }
                        case 5:
                            {
                                bin.Add(0);
                                bin.Add(1);
                                bin.Add(0);
                                bin.Add(1);
                                break;
                            }
                        case 6:
                            {
                                bin.Add(0);
                                bin.Add(1);
                                bin.Add(1);
                                bin.Add(0);
                                break;
                            }
                        case 7:
                            {
                                bin.Add(0);
                                bin.Add(1);
                                bin.Add(1);
                                bin.Add(1);
                                break;
                            }
                        case 8:
                            {
                                bin.Add(1);
                                bin.Add(0);
                                bin.Add(0);
                                bin.Add(0);
                                break;
                            }
                        case 9:
                            {
                                bin.Add(1);
                                bin.Add(0);
                                bin.Add(0);
                                bin.Add(1);
                                break;
                            }
                        case 10:
                            {
                                bin.Add(1);
                                bin.Add(0);
                                bin.Add(1);
                                bin.Add(0);
                                break;
                            }
                        case 11:
                            {
                                bin.Add(1);
                                bin.Add(0);
                                bin.Add(1);
                                bin.Add(1);
                                break;
                            }
                        case 12:
                            {
                                bin.Add(1);
                                bin.Add(1);
                                bin.Add(0);
                                bin.Add(0);
                                break;
                            }
                        case 13:
                            {
                                bin.Add(1);
                                bin.Add(1);
                                bin.Add(0);
                                bin.Add(1);
                                break;
                            }
                        case 14:
                            {
                                bin.Add(1);
                                bin.Add(1);
                                bin.Add(1);
                                bin.Add(0);
                                break;
                            }
                        case 15:
                            {
                                bin.Add(1);
                                bin.Add(1);
                                bin.Add(1);
                                bin.Add(1);
                                break;
                            }
                    }
                    z = 0;
                }
            }
            return (bin);
        }
        private static List<int> X_2_to_10(List<int> a)//перевод из 2 системы счисления
        {
            List<int> b = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                int c = 0;
                for (int j = 15; j >= 0; j--)
                {
                    c += Convert.ToInt32(Math.Pow(2, j)) * a[15 - j + i * 16];
                }
                b.Add(c);
            }
            return (b);
        }
    }
    class IDEA
    {
        public static List<int> Algorithm(List<int> s, List<int> Key, bool operation)
        {
            List<int> p = new List<int>();
            if (operation == false && Lists.In(Key) == false) return (p);
            if (operation != false && Lists.Out(Key) == false)
            {
                p.Add(-1);
                return (p);
            }
            for (int i = 0; i < 4; i++) p.Add(s[i]);
            bool g = true;
            for (int i = 0; i < 8; i++)
            {
                int A = Count.UP(p[p.Count - 4], Lists.K[0 + i * 6], g);
                int B = Count.SP(p[p.Count - 3], Lists.K[1 + i * 6]);
                int C = Count.SP(p[p.Count - 2], Lists.K[2 + i * 6]);
                int D = Count.UP(p[p.Count - 1], Lists.K[3 + i * 6], g);
                int E = A ^ C;
                int F = B ^ D;
                p.Add(A ^ Count.UP(Count.SP(F, Count.UP(E, Lists.K[4 + i * 6], g)), Lists.K[5 + i * 6], g));
                p.Add(C ^ Count.UP(Count.SP(F, Count.UP(E, Lists.K[4 + i * 6], g)), Lists.K[5 + i * 6], g));
                p.Add(B ^ Count.SP(Count.UP(E, Lists.K[4 + i * 6], g), Count.UP(Count.SP(F, Count.UP(E, Lists.K[4 + i * 6], g)), Lists.K[5 + i * 6], g)));
                p.Add(D ^ Count.SP(Count.UP(E, Lists.K[4 + i * 6], g), Count.UP(Count.SP(F, Count.UP(E, Lists.K[4 + i * 6], g)), Lists.K[5 + i * 6], g)));
            }
            g = false;
            p.Add(Count.UP(p[p.Count - 4], Lists.K[48], g));
            int h = p[p.Count - 4];
            p.Add(Count.SP(p[p.Count - 3], Lists.K[49]));
            p.Add(Count.SP(h, Lists.K[50]));
            p.Add(Count.UP(p[p.Count - 4], Lists.K[51], g));
            return (p);
        }
    }
}
