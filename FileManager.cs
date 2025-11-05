using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expense_tracker
{
    public class FileManager
    {
        string path = @"C:\Users\augus\source\repos\expense-tracker\prueba.csv";

        public void AddExpenseToFile(Expense expense)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"{expense.Id},{expense.Description}, {expense.Amount}, {expense.Month}, {expense.Category}");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"{expense.Id},{expense.Description}, {expense.Amount}, {expense.Month}, {expense.Category}");
                }
            }
        }

        public void DeleteExpenseFromFile(int id)
        {
            var lines = File.ReadAllLines(path);
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var line in lines)
                {
                    if (Convert.ToInt32(line.Split(',')[0]) != id)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }

        public void LoadExpensesFromFile(List<Expense> lst)
        {
            if (!File.Exists(path))
            {
                return;
            }

            string cadena = string.Empty;
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    cadena = s;
                    lst.Add(new Expense
                    {
                        Id = Convert.ToInt32(cadena.Split(',')[0]),
                        Description = cadena.Split(',')[1],
                        Amount = Convert.ToDecimal(cadena.Split(',')[2]),
                        Month = Convert.ToInt32(cadena.Split(',')[3]),
                        Category = Convert.ToInt32(cadena.Split(',')[4])
                    });
                }
            }
        }
    }
}
