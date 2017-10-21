using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Employee
    {
        private int id = 0;
        private string name = "Андрей";
        private string surname = "Иванов";
        private string lastname = "Дмитриевич";
        private DateTime date = DateTime.Now;
        private int position_id = 0;
        private int company_id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Position_Id
        {
            get { return position_id; }
            set { position_id = value; }
        }

        public int Company_Id
        {
            get { return company_id; }
            set { company_id = value; }
        }

        public string NameView
        {
            get { return this.surname + " " + this.name + " " + this.lastname; }
        }
    }
}