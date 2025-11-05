using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expense_tracker
{
    public class ExpenseManager
    {
        FileManager fm = new FileManager();
        List<Expense> expenses = new List<Expense>();
        
        public void AddExpense(string[] args)
        {
            Expense expense = new Expense();
            LoadExpenses();
            int newId = 0;
            foreach(var e in expenses)
            {
                if(e.Id > newId)
                {
                    newId = e.Id;
                }
            }
            
            expense.Id = newId + 1;
            for(int i = 1 ; i < args.Length; i++)
            {
                if (args[i] == "--description")
                {
                    if(args[i + 1].StartsWith("--") || args[i + 1].Trim() == "")
                    {
                        throw new ArgumentException("La descripcion no puede estar vacia.");
                    }
                    expense.Description = args[i + 1];
                }
                else if (args[i] == "--amount")
                {
                    expense.Amount = Convert.ToDecimal(args[i + 1]);
                }
                else if (args[i] == "--month")
                {
                    if (i + 1 >= args.Length)
                    {
                        throw new ArgumentException("Falta el valor del mes después de --month.");
                    }

                    int monthValue;
                    string monthInput = args[i + 1];

                    if (int.TryParse(monthInput, out monthValue))
                    {
                        if (monthValue >= 1 && monthValue <= 12)
                        {
                            expense.Month = monthValue;
                        }
                        else
                        {
                            throw new ArgumentException($"El mes '{monthInput}' debe estar entre 1 y 12.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException($"El valor '{monthInput}' no es un número entero válido para el mes.");
                    }
                }
                else if (args[i] == "--category")
                {
                    if (i + 1 >= args.Length)
                    {
                        throw new ArgumentException("Falta el valor dela categoria despues de --category.");
                    }

                    int categoryValue;
                    string categoryInput = args[i + 1];

                    if (int.TryParse(categoryInput, out categoryValue))
                    {
                        if (categoryValue >= 1 && categoryValue <= 12)
                        {
                            expense.Category = categoryValue;
                        }
                        else
                        {
                            throw new ArgumentException($"El mes '{categoryInput}' debe estar entre 1 y 12.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException($"El valor '{categoryInput}' no es un número entero válido para el mes.");
                    }
                }
            }

            fm.AddExpenseToFile(expense);
        }

        public void ListExpenses()
        {
            LoadExpenses();
            Console.WriteLine("Id | Description | Amount | Month | Category");
            foreach (var expense in expenses)
            {
                
                Console.WriteLine($"{expense.Id} | {expense.Description} | {expense.Amount} | {expense.Month} | {expense.Category} ");
            }
        }

        public void Summary(string[] args)
        {
            LoadExpenses();
            decimal summary = 0;
            if(args.Length == 1)
            {
                foreach (var expense in expenses)
                {
                    summary += expense.Amount;
                }
            }
            else
            {
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i] == "--month")
                    {
                        int month = Convert.ToInt32(args[i + 1]);
                        foreach (var expense in expenses)
                        {
                            if(month < 1 || month > 12)
                            {
                                throw new ArgumentException("El mes debe estar entre 1 y 12.");
                                return;
                            }
                            if (expense.Month == month)
                            {
                                summary += expense.Amount;
                            }
                        }
                    }

                }
            }
            Console.WriteLine($"Total expensas: {summary}");

        }
        
        public void Delete(string[] args)
        {
            LoadExpenses();
            int idToDelete = 0;

            for (int i = 1; i < args.Length; i++)
            {
                if (args[i] == "--id")
                {

                    if (i + 1 < args.Length && int.TryParse(args[i + 1], out int idValue))
                    {
                        idToDelete = idValue;
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("Debe proporcionar un ID entero válido después de '--id'.");
                    }
                }
            }
            if(idToDelete <= 0)
            {
                Console.WriteLine("No se pudo eliminar, los ids son positivos.");
                return;
            }
            foreach (var expense in expenses)
            {
                if(expense.Id == idToDelete)
                {
                    expenses.Remove(expense);
                    break;
                }
            }

            fm.DeleteExpenseFromFile(idToDelete);

        }

        public void LoadExpenses()
        {
            fm.LoadExpensesFromFile(expenses);
        }
    }
}
