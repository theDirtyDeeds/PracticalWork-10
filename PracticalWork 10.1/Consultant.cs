using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticalWork_10._1
{
    public class Consultant
    {
        
        public string _name;
        private string _department;

        
        public Consultant(string name, string department)
        {
            _name = name;
            _department = department;
        }

       
        public string GetConsultantInfo()
        {
            return $"Консультант: {_name}, Отдел: {_department}";
        }
    }

    public class Manager : Consultant
    {
        public Manager(string name, string department) : base(name, department)
        {

        }
        public Client AddClient(string lastName, string firstName, string middleName, string phoneNumber, string passportSeries, string passportNumber)
        {
            return new Client(lastName, firstName, middleName, phoneNumber, passportSeries, passportNumber);
        }

        public void ShowClientInfo(Client client)
        {
            Console.WriteLine(client.GetClientInfo());
        }
        public void UpdateClient(Client client, string propertyName, string newValue)
        {
            client.UpdateClientData(propertyName, newValue, this);
        }
    }
 }
