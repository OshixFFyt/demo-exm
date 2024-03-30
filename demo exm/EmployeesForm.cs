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
    public partial class EmployeesForm : Form
    {
        public EmployeesForm()
        {
            InitializeComponent();
            Load += EmployeesForm_Load;
        }
        private bool isFirstLoad = true;

        private void EmployeesForm_Load(object sender, EventArgs e)
        {

            if (isFirstLoad)
            {
                // Очищаем DataGridView перед добавлением строк
                dataGridView1.Rows.Clear();

                // Добавляем колонки в DataGridView
                dataGridView1.Columns.Add("UsernameColumn", "Username");
                dataGridView1.Columns.Add("TypeColumn", "Type");
                dataGridView1.Columns.Add("StatusColumn", "Status");

                // Заполняем DataGridView данными о сотрудниках
                foreach (User user in Program.users)
                {
                    string status = user.IsFired ? "уволен" : "работает"; // Определяем статус сотрудника
                    dataGridView1.Rows.Add(user.Username, user.Type.ToString(), status);
                }

                isFirstLoad = false;
            }

        }
        private void RefreshEmployeesDataGridView()
        {
            // Очищаем DataGridView перед обновлением
            dataGridView1.Rows.Clear();

            // Заполняем DataGridView данными о сотрудниках
            foreach (User user in Program.users)
            {
                string status = user.IsFired ? "уволен" : "работает"; // Определяем статус сотрудника
                dataGridView1.Rows.Add(user.Username, user.Type.ToString(), status);
            }
        }

        private void btnOpenAddEmployeeForm_Click(object sender, EventArgs e)
        {
            // Создаем и отображаем форму для добавления сотрудника
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.ShowDialog();

            // После закрытия формы обновляем DataGridView
            RefreshEmployeesDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Получаем имя пользователя, которого нужно уволить, из выделенной строки DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string usernameToFire = dataGridView1.SelectedRows[0].Cells["UsernameColumn"].Value.ToString();

                // Находим сотрудника в списке
                User employeeToFire = Program.users.Find(u => u.Username == usernameToFire);

                if (employeeToFire != null)
                {
                    // Устанавливаем статус "уволен"
                    employeeToFire.IsFired = true;

                    // Обновляем DataGridView
                    RefreshEmployeesDataGridView();
                    MessageBox.Show($"Сотрудник {usernameToFire} уволен", "Увольнение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Сотрудник {usernameToFire} не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для увольнения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
