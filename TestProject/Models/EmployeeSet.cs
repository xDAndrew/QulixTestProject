using System;

namespace TestProject.Models
{
    public class EmployeeSet
    {
        private List<Employee> list;
        private string query;

        public EmployeeSet(string query)
        {
            this.query = query;
            Update();
        }

        public void Update()
        {
            var contex = DBContext.GetInstance();
            var data = contex.MakeDataQuery(this.query);

            list = new List<Employee>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    var temp = new Employee();
                    temp.Id = (Int32)data["Id"];
                    temp.Name = (string)data["Name"];
                    temp.Surname = (string)data["Surname"];
                    temp.Lastname = (string)data["Lastname"];
                    temp.Date = (DateTime)data["Date"];
                    temp.Position_Id = (Int32)data["Position_id"];
                    temp.Company_Id = (Int32)data["Company_id"];
                    list.Add(temp);
                }
            }
            data.Close();
        }

        public Employee this[int index]
        {
            get { return list.GetItem(index); }
            set { list.SetItem(index, value); }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public Employee GetItemById(int id)
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