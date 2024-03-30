using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_exm
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("ItemColumn", "Наименование");
            dataGridView1.Columns.Add("QuantityColumn", "Количество");
            dataGridView1.Columns.Add("CompletedColumn", "Выполнен"); // Новый столбец для отображения статуса выполнения заказа

            // Заполнение DataGridView предустановленными заказами из списка orders
            foreach (Order order in Program.orders)
            {
                foreach (MenuItem item in order.Items)
                {
                    dataGridView1.Rows.Add(item.Name, item.Quantity, order.IsCompleted ? "Да" : "Нет"); // Отображаем "Да" или "Нет" в зависимости от статуса выполнения заказа
                }
            }
        }
    }
}
