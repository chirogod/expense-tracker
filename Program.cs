using expense_tracker;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Debe indicar la accion a realizar con expensas: \n \t-add --description <descripcion> --amount <monto> --month <mes> --category <categoria> \t-list \t-summary [--month <mes>] \t-delete --id <id>");
            return;
        }
        ExpenseManager expenseManager = new ExpenseManager();

        string action = args[0];

        try
        {
            switch (action)
            {
                case "add":
                    expenseManager.AddExpense(args);
                    break;
                case "list":
                    expenseManager.ListExpenses();
                    break;
                case "summary":
                    expenseManager.Summary(args);
                    break;
                case "delete":
                    expenseManager.Delete(args);
                    break;
                default:
                    Console.WriteLine($"Comando desconocido: {action}");
                    break;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}