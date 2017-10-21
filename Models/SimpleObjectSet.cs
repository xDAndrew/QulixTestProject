using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class SimpleObjectSet
    {
        private List<SimpleObject> list = new List<SimpleObject>();

        public SimpleObjectSet(string tableName)
        {
            var contex = DBContext.GetInstance();
            var data = contex.GetDataFromDB("SELECT * FROM " + tableName);

            if (data.HasRows)
            {
                while (data.Read())
                {
                    var temp = new SimpleObject();
                    temp.Id = data.GetInt32(0);
                    temp.Name = data.GetString(1);
                    list.Add(temp);
                }
            }
            data.Close();
        }

        public SimpleObject this[int index]
        {
            get { return list.GetItem(index); }
            set { list.SetItem(index, value); }
        }

        public int Count
        {
            get { return list.Count; }
        }
    }
}