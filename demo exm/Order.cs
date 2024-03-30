using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_exm
{
    public class MenuItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<MenuItem> Items { get; set; }
        public bool IsCompleted { get; set; }

        public MenuItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }


    public class Order
    {
        public List<MenuItem> Items { get; set; }
        public bool IsCompleted { get; set; }

        public Order(List<MenuItem> items)
        {
            Items = items;
            IsCompleted = false;
        }
    }


}
