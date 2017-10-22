using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class CompanySet
    {
        private List<Company> list;
        private string query;

        public CompanySet(string query)
        {
            this.query = query;
            Update();
        }

        public void Update()
        {
            var contex = DBContext.GetInstance();
            var data = contex.MakeDataQuery(this.query);

            list = new List<Company>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    var temp = new Company();
                    temp.Id = data.GetInt32(0);
                    temp.Form_id = data.GetInt32(1);
                    temp.Size_id = data.GetInt32(2);
                    temp.Name = data.GetString(3);
                    list.Add(temp);
                }
            }
            data.Close();
        }

        public Company this[int index]
        {
            get { return list.GetItem(index); }
            set { list.SetItem(index, value); }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public Company GetItemById(int id)
        {
            for (int i = 0; i < Count; i++)
            {
                if (list.GetItem(i).Id == id)
                    return list.GetItem(i);
            }
            return null;
        }
    }
}