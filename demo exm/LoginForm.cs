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
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }
        
        private List<User> users;

        public LoginForm(List<User> users)
        {
            InitializeComponent();
            this.users = users;
            this.users = users;
            txtPassword.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Проверяем введенные учетные данные
            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    // Пользователь найден, открываем соответствующее окно
                    switch (user.Type)
                    {
                        case UserType.Administrator:
                            AdminForm adminForm = new AdminForm();
                            adminForm.Show();
                            break;
                        case UserType.Waiter:
                            WaiterForm waiterForm = new WaiterForm();
                            waiterForm.Show();
                            break;
                        case UserType.Chef:
                            ChefForm chefForm = new ChefForm();
                            chefForm.Show();
                            break;
                    }

                    // Закрываем форму входа
                    this.Hide();
                    return;
                }
            }

            // Если пользователь не найден, выводим сообщение об ошибке
            MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}


