using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_10._1._2
{
    public class Client
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }

        public List<ModificationLog> ModificationLogs { get; private set; } = new List<ModificationLog>();

        
        public Client(string lastName, string firstName, string middleName, string phoneNumber, string passportSeries, string passportNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
        }

        public string GetClientInfo()
        {
            return $"ФИО: {LastName} {FirstName} {MiddleName}, Телефон: {PhoneNumber}, Паспорт: {PassportSeries} {PassportNumber}";
        }

        public void UpdateClientData(string propertyName, string newValue)
        {
            string oldValue = string.Empty;

            switch (propertyName.ToLower())
            {
                case "lastname":
                    oldValue = LastName;
                    LastName = newValue;
                    break;
                case "firstname":
                    oldValue = FirstName;
                    FirstName = newValue;
                    break;
                case "middlename":
                    oldValue = MiddleName;
                    MiddleName = newValue;
                    break;
                case "phonenumber":
                    oldValue = PhoneNumber;
                    PhoneNumber = newValue;
                    break;
                case "passportseries":
                    oldValue = PassportSeries;
                    PassportSeries = newValue;
                    break;
                case "passportnumber":
                    oldValue = PassportNumber;
                    PassportNumber = newValue;
                    break;
                default:
                    throw new ArgumentException("Неверное имя свойства");
            }

            ModificationLogs.Add(new ModificationLog
            {
                PropertyName = propertyName,
                OldValue = oldValue,
                NewValue = newValue,
                Timestamp = DateTime.Now
            });
        }
        public class ModificationLog
        {
            public string PropertyName { get; set; }
            public string OldValue { get; set; }
            public string NewValue { get; set; }
            public DateTime Timestamp { get; set; }
        }
    }
}
