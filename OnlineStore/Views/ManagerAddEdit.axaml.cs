using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OnlineStore.Models;
using System.Linq;
using System.Xml.Linq;

namespace OnlineStore;

public partial class ManagerAddEdit : Window
{
    public User SelectedManager { get; set; }
    public ManagerAddEdit(User manager)
    {
        InitializeComponent();
        SelectedManager = manager;

        if (SelectedManager == null) return;
        DataContext = SelectedManager;
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBEmail.Text) || string.IsNullOrWhiteSpace(TBSurname.Text) || string.IsNullOrWhiteSpace(TBName.Text) || string.IsNullOrWhiteSpace(TBPassword.Text) || string.IsNullOrWhiteSpace(TBPatronymic.Text) || string.IsNullOrWhiteSpace(TBPhone.Text) || !TBEmail.Text.Contains('@') || !TBEmail.Text.Contains('.') || TBEmail.Text.Count() > 100 || TBPassword.Text.Count() > 100)
        {
            return;
        }
        else
        {
            if (SelectedManager != null)
            {
                if (!decimal.TryParse(TBBalance.Text, out decimal result)) return;
                
                
                App.db.Update(DataContext as User);
                
                
            }
            else
            {
                if (!decimal.TryParse(TBBalance.Text, out decimal result)) return;
                var NewUser = new User()
                {
                    Surname = TBSurname.Text,
                    Name = TBName.Text,
                    Patronymic = TBPatronymic.Text,
                    Email = TBEmail.Text,
                    Password = TBPassword.Text,
                    Phone = TBPhone.Text,
                    Balance = decimal.Parse(TBBalance.Text),
                    RoleId = 2
                };
                App.db.Users.Add(NewUser);
            }
            App.db.SaveChanges();
            this.Close();
        }
    }
}