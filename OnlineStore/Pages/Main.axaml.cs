using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using OnlineStore.Models;
using System;
using System.Linq;
using Tmds.DBus.Protocol;

namespace OnlineStore;

public partial class Main : UserControl
{
    public User user { get; set; }
    public Main()
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

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBEmail.Text) || string.IsNullOrWhiteSpace(TBPassword.Text) || !TBEmail.Text.Contains('@') || !TBEmail.Text.Contains('.'))
        {
            TBEmail.Text = "Email incorected";
            TBEmail.Foreground = new SolidColorBrush(Color.Parse("#800000"));
            TBPassword.Text = "Password incorected";
            TBPassword.Foreground = new SolidColorBrush(Color.Parse("#800000"));
            TBPassword.PasswordChar = '\0';
            return;   
        }
        else
        {
            user = App.db.Users.FirstOrDefault(p => p.Email.ToLower() == TBEmail.Text.ToLower() && p.Password == TBPassword.Text);

            if (user != null)
            {
                if (user.RoleId == 1)
                {
                    App.MainWindow.MyContent.Content = new Admin(user);
                }
                else if(user.RoleId == 2)
                {
                    App.MainWindow.MyContent.Content = new Manager(user);
                }
                else
                {
                    App.MainWindow.MyContent.Content = new Client(user);
                }
            }
            else
            {
                TBEmail.Text = "Email incorected";
                TBEmail.Foreground = new SolidColorBrush(Color.Parse("#800000"));
                TBPassword.Text = "Password incorected";
                TBPassword.Foreground = new SolidColorBrush(Color.Parse("#800000"));
                TBPassword.PasswordChar = '\0';
                return;
            }
        }
    }

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MyContent.Content = new Registration();
    }
}