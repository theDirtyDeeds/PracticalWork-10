using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_10._1
{
    public class Client
    {
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private string _phoneNumber;
        private string _passportSeries;
        private string _passportNumber;

        public List<ModificationLog> ModificationLogs { get; private set; } = new List<ModificationLog>();

        public Client(string lastName, string firstName, string middleName, string phoneNumber, string passportSeries, string passportNumber)
        {
            _lastName = lastName;
            _firstName = firstName;
            _middleName = middleName;
            _phoneNumber = phoneNumber;
            _passportSeries = passportSeries;
            _passportNumber = passportNumber;
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public string FirstName
        {
            get { return _firstName; }
        }
        public string MiddleName
        {
            get { return _middleName; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _phoneNumber = value;
                }
                else
                {
                    throw new ArgumentException("Номер телефона не может быть пустым.");
                }
            }
        }
        public string GetClientInfo()
        {
            return $"ФИО: {_lastName} {_firstName} {_middleName}, Телефон: {_phoneNumber}, Паспорт: {HidePassport()}";
        }
        private string HidePassport()
        {
            return $"{_passportSeries} **-**";
        }

        public string GetPassportInfo()
        {
            if (!string.IsNullOrEmpty(_passportSeries) || !string.IsNullOrEmpty(_passportNumber))
            {
                return "**********";
            }
            return string.Empty;
        }
        public void UpdateClientData(string propertyName, string newValue, Consultant consultant)
        {
            string oldValue = string.Empty;

            switch (propertyName.ToLower())
            {
                case "lastname":
                    oldValue = _lastName;
                    _lastName = newValue;
                    break;
                case "firstname":
                    oldValue = _firstName;
                    _firstName = newValue;
                    break;
                case "middlename":
                    oldValue = _middleName;
                    _middleName = newValue;
                    break;
                case "phonenumber":
                    oldValue = _phoneNumber;
                    _phoneNumber = newValue;
                    break;
                case "passportseries":
                    oldValue = _passportSeries;
                    _passportSeries = newValue;
                    break;
                case "passportnumber":
                    oldValue = _passportNumber;
                    _passportNumber = newValue;
                    break;
                default:
                    Console.WriteLine("Недопустимое имя свойства");
                    return;
            }
            ModificationLogs.Add(new ModificationLog(DateTime.Now, propertyName, oldValue, newValue, consultant._name));
        }
        public class ModificationLog
        {
            public DateTime ModificationDate { get; }
            public string PropertyChanged { get; }
            public string OldValue { get; }
            public string NewValue { get; }
            public string ChangedBy { get; }

            public ModificationLog(DateTime modificationDate, string propertyChanged, string oldValue, string newValue, string changedBy)
            {
                ModificationDate = modificationDate;
                PropertyChanged = propertyChanged;
                OldValue = oldValue;
                NewValue = newValue;
                ChangedBy = changedBy;
            }

            public override string ToString()
            {
                return $"Дата: {ModificationDate}, Измененное поле: {PropertyChanged}, Старое значение: {OldValue}, Новое значение: {NewValue}, Изменено: {ChangedBy}";
            }
        }
    }
}
