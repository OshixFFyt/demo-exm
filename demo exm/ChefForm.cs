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
    public partial class ChefForm : Form
    {
        public ChefForm()
        {
            InitializeComponent();
            Load += ChefForm_Load;
        }

        private void ChefForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            // Добавьте столбцы для отображения заказов
            dataGridView1.Columns.Add("ItemColumn", "Наименование");
            dataGridView1.Columns.Add("QuantityColumn", "Количество");
            dataGridView1.Columns.Add("StatusColumn", "Статус");

            // Загрузите заказы для повара из списка orders
            foreach (Order order in Program.orders)
            {
                // Проверьте, что заказ еще не готов
                if (!order.IsCompleted)
                {
                    foreach (MenuItem item in order.Items)
                    {
                        // Добавьте только те заказы, которые еще не готовы
                        dataGridView1.Rows.Add(item.Name, item.Quantity, "Готовится");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получите выбранный заказ из DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Измените статус выбранного заказа на "Готов"
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[rowIndex].Cells["StatusColumn"].Value = "Готов";

                // Обновите статус заказа в списке Program.orders
                // (вам нужно определить, как связать строки DataGridView с объектами заказов в Program.orders)
            }
            else
            {
                MessageBox.Show("Выберите заказ для изменения статуса", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

