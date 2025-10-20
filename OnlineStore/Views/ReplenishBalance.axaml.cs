using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OnlineStore.Models;
using System.Xml.Linq;

namespace OnlineStore;

public partial class ReplenishBalance : Window
{
    public User SelectedUser { get; set; }
    public ReplenishBalance(User user)
    {
        InitializeComponent();
        SelectedUser = user;
        DataContext = SelectedUser;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBBalance.Text))
        {
            return;
        }
        else
        {
            if (!decimal.TryParse(TBBalance.Text, out decimal result)) return;
            if (SelectedUser != null)
            {
                if(DataContext is User user)
                {
                    user.Balance += result;
                    App.db.Users.Update(user);
                }
            }
            App.db.SaveChanges();
            this.Close();
        }
    }
}