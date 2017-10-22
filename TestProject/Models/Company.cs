using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Company
    {
        private int id = 0;
        private int form_id = 0;
        private int size_id = 0;
        private string name = "Qulix";

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Form_id
        {
            get { return form_id; }
            set { form_id = value; }
        }

        public int Size_id
        {
            get { return size_id; }
            set { size_id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}