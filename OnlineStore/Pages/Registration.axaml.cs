using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using OnlineStore.Models;
using System.Linq;

namespace OnlineStore;

public partial class Registration : UserControl
{
    public Registration()
    {
        InitializeComponent();
    }

    private void TextBox_GotFocus(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        if (TBEmail.Text == "Enter your email" || TBEmail.Text == "Email incorected")
        {
            TBEmail.Text = "";
            TBEmail.Foreground = new SolidColorBrush(Color.Parse("#7a86a2"));
        }
    }

    private void TextBox_LostFocus(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBEmail.Text))
        {
            TBEmail.Text = "Enter your email";
        }
    }

    private void TextBox_GotFocus_1(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        if (TBPassword.Text == "Enter your password" || TBPassword.Text == "Password incorected")
        {
            TBPassword.Text = "";
            TBPassword.PasswordChar = '*';
            TBPassword.Foreground = new SolidColorBrush(Color.Parse("#7a86a2"));
        }
    }

    private void TextBox_LostFocus_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBPassword.Text))
        {
            TBPassword.Text = "Enter your password";
            TBPassword.PasswordChar = '\0';
        }
    }

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBEmail.Text) || string.IsNullOrWhiteSpace(TBPassword.Text) || !TBEmail.Text.Contains('@') || !TBEmail.Text.Contains('.')
            || string.IsNullOrWhiteSpace(TBSurname.Text) || string.IsNullOrWhiteSpace(TBName.Text) || string.IsNullOrWhiteSpace(TBPatronymic.Text) || string.IsNullOrWhiteSpace(TBPhone.Text) || TBEmail.Text.Count() > 100 || TBPassword.Text.Count() > 100)
        {
            TBEmail.Text = "Email incorected";
            TBEmail.Foreground = new SolidColorBrush(Color.Parse("#800000"));
            TBPassword.Text = "Password incorected";
            TBPassword.Foreground = new SolidColorBrush(Color.Parse("#800000"));
            TBPassword.PasswordChar = '\0';
            TBSurname.Text = "Surname incorected";
            TBSurname.Foreground = new SolidColorBrush(Color.Parse("#800000"));
            TBName.Text = "Name incorected";
            TBName.Foreground = new SolidColorBrush(Color.Parse("#800000"));
            TBPatronymic.Text = "Patronymic incorected";
            TBPatronymic.Foreground = new SolidColorBrush(Color.Parse("#800000"));
            TBPhone.Text = "Phone incorected";
            TBPhone.Foreground = new SolidColorBrush(Color.Parse("#800000"));
            return;
        }
        else
        {
            var NewUser = new User()
            {
                Surname = TBSurname.Text,
                Name = TBName.Text,
                Patronymic = TBPatronymic.Text,
                Phone = TBPhone.Text,
                Balance = null,
                Email = TBEmail.Text,
                Password = TBPassword.Text,
                RoleId = 3,
                StreetId = null,
                House = null,
                Apartment = null
            };

            App.db.Users.Add(NewUser);
            App.db.SaveChanges();
            App.MainWindow.MyContent.Content = new Main();
        }
    }

    private void TextBox_GotFocus_2(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        if (TBSurname.Text == "Enter your surname" || TBSurname.Text == "Surname incorected")
        {
            TBSurname.Text = "";
            TBSurname.Foreground = new SolidColorBrush(Color.Parse("#7a86a2"));
        }
    }

    private void TextBox_LostFocus_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBSurname.Text))
        {
            TBSurname.Text = "Enter your surname";
        }
    }

    private void TextBox_GotFocus_3(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        if (TBName.Text == "Enter your name" || TBName.Text == "Name incorected")
        {
            TBName.Text = "";
            TBName.Foreground = new SolidColorBrush(Color.Parse("#7a86a2"));
        }
    }

    private void TextBox_LostFocus_5(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBName.Text))
        {
            TBName.Text = "Enter your name";
        }
    }

    private void TextBox_GotFocus_4(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        if (TBPhone.Text == "Enter your phone" || TBPhone.Text == "Phone incorected")
        {
            TBPhone.Text = "";
            TBPhone.Foreground = new SolidColorBrush(Color.Parse("#7a86a2"));
        }
    }

    private void TextBox_LostFocus_6(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBPhone.Text))
        {
            TBPhone.Text = "Enter your phone";
        }
    }

    private void TextBox_GotFocus_5(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        if (TBPatronymic.Text == "Enter your patronymic" || TBPatronymic.Text == "Patronymic incorected")
        {
            TBPatronymic.Text = "";
            TBPatronymic.Foreground = new SolidColorBrush(Color.Parse("#7a86a2"));
        }
    }

    private void TextBox_LostFocus_7(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBPatronymic.Text))
        {
            TBPatronymic.Text = "Enter your patronymic";
        }
    }

    private void Button_Click_8(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MyContent.Content = new Main();
    }
}