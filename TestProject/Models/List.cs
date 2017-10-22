using System;
using System.Web;

namespace TestProject.Models
{
    public class List<T>
    {
        private class Item
        {
            public T data;
            public Item head = null;
            public Item tail = null;
        }

        private Item tail = null;
        private Item head = null;

        private int count = 0;
        public int Count
        {
            get { return count; }
        }

        public void Add(T data)
        {
            var newItem = new Item();
            newItem.data = data;

            if (this.tail == null)
            {
                this.tail = newItem;
                this.head = newItem;
            }
            else
            {
                newItem.head = this.tail;
                this.tail.tail = newItem;
                this.tail = newItem;
            }
            count++;
        }

        public T GetItem(int index)
        {
            Item item = null;
            for (int i = -1; i < index; i++ )
            {
                if (i == -1)
                {
                    item = head;
                }
                else
                {
                    item = item.tail;
                }
            }
            return item.data;
        }

        public void SetItem(int index, T data)
        {
            Item item = null;
            for (int i = -1; i < index; i++)
            {
                if (i == -1)
                {
                    item = head;
                }
                else
                {
                    item = item.tail;
                }
            }
            item.data = data;
        }
    }
}