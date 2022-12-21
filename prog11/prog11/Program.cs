using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog10._1
{
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

		public bool Exist() // содержит ли текст фрагменты, соответствующие шаблону поля;
		{
			if (r.IsMatch(text.ToLower()))
			{
				Console.WriteLine("Содержит");
				return r.IsMatch(text);
			}
			else
			{
				Console.WriteLine("Не содержит");
				return false;
			}
		}

		public void ShowMatches() // •	вывести на экран все фрагменты текста, соответствующие шаблону поля;
		{
			MatchCollection m = r.Matches(text.ToLower());
			foreach (Match x in m)
			{
				Console.Write(x.Value + " ");
			}

		}

		public string DeleteMatches() // •	удалить из текста все фрагменты, соответствующие шаблону поля;
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
			Console.WriteLine(text);
			return text;
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

	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				txt1: Console.WriteLine("Введите любой текст как с символами/словами, так и с цифрами: ");
				string text = Console.ReadLine();
				if(text == string.Empty)
				{
					Console.WriteLine("Ошибка ввода данных");
					goto txt1;
				}
				Console.Write("Введите шаблон поля регулярного выражения: ");
				string rex = Console.ReadLine();

				RegularEx A = new RegularEx(rex, text);
				Console.WriteLine("Содержит ли текс шаблон: ");
				A.Exist();
				Console.WriteLine("Вывод шаблона: ");
				A.ShowMatches();
				Console.WriteLine("\nУдаление из текста все фрагменты, соответствующие шаблону поля");
				Console.WriteLine("Исходный текст: ");
				A.Text = A.DeleteMatches();
				Console.WriteLine("Введите новую строку: ");
				A.Text = Console.ReadLine();
				Console.WriteLine("Введите новый шаблон: ");
				string rx = Console.ReadLine();
				Regex reg = new Regex(rx);
				A.R = reg;
				Console.WriteLine("Содержит ли текс шаблон: ");
				A.Exist();
				Console.WriteLine("Вывод шаблона: ");
				A.ShowMatches();
				Console.WriteLine("\nУдаление из текста все фрагменты, соответствующие шаблону поля");
				Console.WriteLine("Исходный текст: ");
				A.Text = A.DeleteMatches();

				Console.WriteLine();
			}
			catch
			{
				Console.WriteLine("Ошибка работы программы");
				return;
			}

		}
	}
}
