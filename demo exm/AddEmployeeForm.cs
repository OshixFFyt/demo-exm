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
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
        }
       
        

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            UserType userType = (UserType)cmbUserType.SelectedIndex; // Предполагается, что тип пользователя выбирается из выпадающего списка

            // Создаем нового сотрудника
            User newEmployee = new User(username, password, userType);

            // Добавляем сотрудника в список
            Program.users.Add(newEmployee);

            // Закрываем форму
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

