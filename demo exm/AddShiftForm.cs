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
    public partial class AddShiftForm : Form
    {
        public AddShiftForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем введенные данные о смене
            DateTime date = dateTimePickerDate.Value;
            TimeSpan startTime = TimeSpan.Parse(textBoxStartTime.Text);
            TimeSpan endTime = TimeSpan.Parse(textBoxEndTime.Text);

            // Получаем выбранных сотрудников из ListBox
            List<User> selectedEmployees = new List<User>();
            foreach (object item in listBoxEmployees.SelectedItems)
            {
                string username = item.ToString();
                User user = Program.users.Find(u => u.Username == username);
                if (user != null)
                {
                    selectedEmployees.Add(user);
                }
            }

            // Проверяем, что выбрано ровно два сотрудника
            if (selectedEmployees.Count != 2)
            {
                MessageBox.Show("Пожалуйста, выберите двух сотрудников для смены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Создаем новую смену с выбранными сотрудниками и добавляем ее в список смен
            Shift newShift = new Shift(date, startTime, endTime);
            foreach (User employee in selectedEmployees)
            {
                newShift.AddEmployee(employee);
            }
            Program.shifts.Add(newShift);

            // Закрываем форму создания смены
            this.Close();
        }


            private void AddShiftForm_Load(object sender, EventArgs e)
        {
            // Очистите ListBox перед добавлением новых элементов (если это нужно)
            listBoxEmployees.Items.Clear();

            // Добавьте имена всех сотрудников из списка users в ListBox
            foreach (User user in Program.users)
            {
                listBoxEmployees.Items.Add(user.Username);
            }
        }
    }
}
