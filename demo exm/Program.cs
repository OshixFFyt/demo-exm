using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_exm
{
    internal static class Program
    {

        public static List<User> users { get; } = new List<User>
    {
        new User("admin", "admin", UserType.Administrator),
        new User("waiter1", "waiter1pass", UserType.Waiter),
        new User("waiter2", "waiter2pass", UserType.Waiter),
        new User("chef1", "chef1pass", UserType.Chef),
        new User("chef2", "chef2pass", UserType.Chef)
    };


        // Метод для обновления списка сотрудников

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static List<Shift> shifts = new List<Shift>();
        [STAThread]
        static void Main()
        {

            Shift shift1 = new Shift(DateTime.Today, TimeSpan.Parse("08:00"), TimeSpan.Parse("16:00"));
            shift1.AddEmployee(users[1]); // Добавляем сотрудника к первой смене
            shift1.AddEmployee(users[3]); // Добавляем еще одного сотрудника к первой смене
            shifts.Add(shift1);

            Shift shift2 = new Shift(DateTime.Today, TimeSpan.Parse("16:00"), TimeSpan.Parse("00:00"));
            shift2.AddEmployee(users[2]); // Добавляем сотрудника ко второй смене
            shift2.AddEmployee(users[4]); // Добавляем еще одного сотрудника ко второй смене
            shifts.Add(shift2);



            // Запускаем форму входа, передавая список пользователей
            LoginForm loginForm = new LoginForm(users);
            Application.Run(loginForm);
        }
        public static List<Order> orders = new List<Order>
        {
        new Order(new List<MenuItem>
        {
         new MenuItem("Кофе", 2),
         new MenuItem("Чай", 1),
         new MenuItem("Пирог", 1)
         }),
        new Order(new List<MenuItem>
         {
         new MenuItem("Салат", 1),
         new MenuItem("Пицца", 2),
         new MenuItem("Лимонад", 3)
         }),
    
        };
        public static List<MenuItem> menu = new List<MenuItem>
        {
            new MenuItem("Кофе", 2),
            new MenuItem("Чай", 1),
            new MenuItem("Пирог", 1),
            // Добавьте больше пунктов, если необходимо
        };

    };


 }


