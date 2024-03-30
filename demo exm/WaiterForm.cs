using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static demo_exm.WaiterForm;

namespace demo_exm
{
    public partial class WaiterForm : Form
    {
        public WaiterForm()
        {
            InitializeComponent();
        }
        private List<Order> orders = new List<Order>();
        public class Order
        {
            public string Table { get; set; }
            public int NumberOfPeople { get; set; }
            public List<MenuItem> Items { get; set; }
            public bool IsCompleted { get; set; }

            // Конструктор, принимающий столик, количество людей и список выбранных пунктов меню
            public Order(string table, int numberOfPeople, List<MenuItem> items)
            {
                Table = table;
                NumberOfPeople = numberOfPeople;
                Items = items;
                IsCompleted = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Собираем информацию о заказе
            string table = txtTable.Text;
            int numberOfPeople = (int)numericUpDownNumberOfPeople.Value;

            List<MenuItem> items = new List<MenuItem>();
            foreach (int selectedIndex in listBoxItems.SelectedIndices)
            {
                MenuItem selectedItem = Program.menu[selectedIndex];
                items.Add(selectedItem);
            }

            // Создаем новый заказ
            Order newOrder = new Order(table, numberOfPeople, items);

            // Очищаем элементы управления
            txtTable.Text = "";
            numericUpDownNumberOfPeople.Value = 1;
            listBoxItems.ClearSelected();

            // Добавляем строку в DataGridView для отображения нового заказа
            string foodItems = string.Join(", ", newOrder.Items.Select(item => item.Name));
            string drinkItems = string.Join(", ", newOrder.Items.Select(item => item.Name));
            dataGridView1.Rows.Add(newOrder.Table, newOrder.NumberOfPeople, foodItems, drinkItems, "Принят");

            MessageBox.Show("Заказ успешно создан", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void UpdateOrdersDataGridView()
        {

            dataGridView1.Rows.Clear(); // Очищаем существующие строки

            // Добавляем каждый заказ из списка orders в DataGridView
            foreach (Order order in orders)
            {
                string foodItems = string.Join(", ", order.Items.Select(item => item.Name));
                string drinkItems = string.Join(", ", order.Items.Select(item => item.Name));
                dataGridView1.Rows.Add(order.Table, order.NumberOfPeople, foodItems, drinkItems, order.IsCompleted ? "Оплачен" : "Принят");
            }
        }

        private void WaiterForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Table", "Столик");
            dataGridView1.Columns.Add("NumberOfPeople", "Количество людей");
            dataGridView1.Columns.Add("Food", "Еда");
            dataGridView1.Columns.Add("Drinks", "Напитки");
            dataGridView1.Columns.Add("Status", "Статус");
            foreach (MenuItem item in Program.menu)
            {
                listBoxItems.Items.Add(item.Name); // Добавляем только названия блюд и напитков
            }

            // Отображаем существующие заказы в DataGridView при загрузке формы
            UpdateOrdersDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли выбранная строка
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем данные выбранной строки
                string table = dataGridView1.SelectedRows[0].Cells["Table"].Value.ToString();
                int numberOfPeople = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["NumberOfPeople"].Value);

                // Ищем заказ с такими же данными в списке заказов
                Order selectedOrder = orders.FirstOrDefault(order => order.Table == table && order.NumberOfPeople == numberOfPeople);

                // Проверяем, найден ли заказ
                if (selectedOrder != null)
                {
                    // Изменяем статус заказа на "Оплачен"
                    selectedOrder.IsCompleted = true;

                    // Обновляем DataGridView, чтобы отобразить изменения
                    UpdateOrdersDataGridView();
                }
                else
                {
                    MessageBox.Show("Не удалось найти выбранный заказ в списке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для оплаты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



