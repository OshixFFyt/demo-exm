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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        private void FireEmployee(string username)
        {
            // Найдите сотрудника в списке пользователей и удалите его
            User employee = Program.users.Find(u => u.Username == username);
            if (employee != null)
            {
                Program.users.Remove(employee);
                MessageBox.Show($"Сотрудник {username} уволен", "Увольнение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Сотрудник {username} не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            EmployeesForm employeesForm = new EmployeesForm();
            employeesForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShiftsForm shiftsForm = new ShiftsForm();
            shiftsForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.Show();
        }
    }
}
