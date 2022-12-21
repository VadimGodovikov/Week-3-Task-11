using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog11form
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		class RegularEx
		{

			public RegularEx(string pattern, string txt)
			{
				r = new Regex(pattern.ToLower());
				text = txt;
			}

			// поля

			private Regex r;
			private string text;

			public bool Exist(TextBox textBox) // содержит ли текст фрагменты, соответствующие шаблону поля;
			{
				if (r.IsMatch(text.ToLower()))
				{
					textBox.Text += "Содержит" + Environment.NewLine;
					return r.IsMatch(text);
				}
				else
				{
					textBox.Text += "Не Содержит" + Environment.NewLine;
					return false;
				}
			}

			public void ShowMatches(TextBox textBox) // •	вывести на экран все фрагменты текста, соответствующие шаблону поля;
			{
				MatchCollection m = r.Matches(text.ToLower());
				foreach (Match x in m)
				{
					textBox.Text += $"{x.Value} ";
				}

			}

			public string DeleteMatches(TextBox textBox) // •	удалить из текста все фрагменты, соответствующие шаблону поля;
			{
				MatchCollection m = r.Matches(text.ToLower());
				string s = text.ToLower();
				foreach (Match x in m)
				{
					int i = s.IndexOf(x.Value);
					int l = x.Value.Length;
					s = s.Remove(i, l);
					text = text.Remove(i, l);

				}
				textBox.Text += s;
				return s;
			}

			public Regex R // •	св-во позволяющее установить или получить регулярное выражение, хранящееся в соответствующем поле класса (доступно для чтения и записи)
			{
				get { return r; }
				set { r = value; }
			}

			public string Text // •	св-во позволяющее установить или получить строковое поле класса (доступно для чтения и записи)
			{
				get { return text; }
				set { text = value; }
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			resultBox.Text = "Результат работы программы: " + Environment.NewLine;
			try
			{
				string text = textBox1.Text;
				if (text == string.Empty)
				{
					MessageBox.Show("Ошибка: строка не должна быть пустая");
					return;
				}
				string rex = textBox2.Text;
				RegularEx A = new RegularEx(rex, text);
				Regex reg = new Regex(rex);
				A.Text = text;
				A.R = reg;
				resultBox.Text += "Содержит ли текст шаблон: " + Environment.NewLine;
				A.Exist(resultBox);
				resultBox.Text += "Вывод текста, который содержит в себе шаблон: " + Environment.NewLine;
				A.ShowMatches(resultBox);
				resultBox.Text += "\r\nУдаление из текста все фрагменты, соответствующие шаблону поля" + Environment.NewLine;
				resultBox.Text += "Исходный текст: " + Environment.NewLine;
				A.Text = A.DeleteMatches(resultBox);

			}
			catch
			{
				Console.WriteLine("Ошибка работы программы");
				return;
			}
		}
	}
}
