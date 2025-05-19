using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace пр8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
            private void RegisterButton_Click(object sender, RoutedEventArgs e)
            {
                // Сброс ошибок
                NameError.Visibility = Visibility.Collapsed;
                EmailError.Visibility = Visibility.Collapsed;
                PasswordError.Visibility = Visibility.Collapsed;

                bool isValid = true;

                // Валидация имени
                if (string.IsNullOrWhiteSpace(NameTextBox.Text))
                {
                    NameError.Text = "Имя не может быть пустым.";
                    NameError.Visibility = Visibility.Visible;
                    isValid = false;
                }

                // Валидация email
                if (string.IsNullOrWhiteSpace(EmailTextBox.Text) || !IsValidEmail(EmailTextBox.Text))
                {
                    EmailError.Text = "Введите корректный email.";
                    EmailError.Visibility = Visibility.Visible;
                    isValid = false;
                }

                // Валидация пароля
                if (PasswordBox.Password.Length < 6)
                {
                    PasswordError.Text = "Пароль должен содержать минимум 6 символов.";
                    PasswordError.Visibility = Visibility.Visible;
                    isValid = false;
                }

                // Если все данные валидны
                if (isValid)
                {
                    MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            private bool IsValidEmail(string email)
            {
                // Простой шаблон для валидации email
                string pattern = @"^[^@s]+@[^@s]+.[^@s]+$";
                return Regex.IsMatch(email, pattern);
            }
    }
}
