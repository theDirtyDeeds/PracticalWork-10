namespace PracticalWork_10._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("Иванов И.И.", "Отдел продаж");

            Client client = new Client("Иванов", "Иван", "Иванович", "+79991234567", "1234", "567890");

            Console.WriteLine("Фамииля: " + client.LastName);
            Console.WriteLine("Имя: " + client.FirstName);
            Console.WriteLine("Отчество: " + client.MiddleName);
            Console.WriteLine("Номер телефона: " + client.PhoneNumber);
            Console.WriteLine("Паспорт: " + client.GetPassportInfo());

            try 
            {
                client.PhoneNumber = "+79991234568";

                Console.WriteLine("Обновленный номер телефона: " + client.PhoneNumber);        
            }
            catch(ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nЛоги изменений:");
            foreach (var log in client.ModificationLogs)
            {
                Console.WriteLine(log);
            }

            Console.WriteLine(manager.GetConsultantInfo());
            manager.ShowClientInfo(client);

            Console.WriteLine("\nОбновленные данные клиента:");
            Console.WriteLine(client.GetClientInfo());
        }
    }
}
