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

    public partial class ShiftsForm : Form
    {
        public ShiftsForm()
        {
            InitializeComponent();

            Load += ShiftsForm_Load;
        }

        private void ShiftsForm_Load(object sender, EventArgs e)
        {
            // Очищаем DataGridView перед добавлением строк
            dataGridView1.Rows.Clear();

            // Очищаем столбцы
            dataGridView1.Columns.Clear();

            // Добавляем столбцы в DataGridView
            dataGridView1.Columns.Add("DateColumn", "Дата");
            dataGridView1.Columns.Add("StartTimeColumn", "Время начала");
            dataGridView1.Columns.Add("EndTimeColumn", "Время окончания");
            dataGridView1.Columns.Add("EmployeesColumn", "Сотрудники");

            // Заполняем DataGridView данными о сменах
            RefreshShiftsDataGridView();
        }

        private void RefreshShiftsDataGridView()
        {
            dataGridView1.Rows.Clear();

            // Заполняем DataGridView данными о сменах
            foreach (Shift shift in Program.shifts)
            {
                string employees = string.Join(", ", shift.Employees.Select(emp => emp.Username));
                dataGridView1.Rows.Add(shift.Date, shift.StartTime, shift.EndTime, employees);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddShiftForm addShiftForm = new AddShiftForm();
            addShiftForm.ShowDialog();

            // После закрытия формы обновляем DataGridView с сменами
            RefreshShiftsDataGridView();
        }
    }
}

