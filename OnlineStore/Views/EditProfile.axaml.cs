using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OnlineStore.Models;
using System.Linq;

namespace OnlineStore;

public partial class EditProfile : Window
{
    public User SelectedUser { get; set; }
    public EditProfile(User user)
    {
        InitializeComponent();
        SelectedUser = user;
        DataContext = SelectedUser;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBEmail.Text) || string.IsNullOrWhiteSpace(TBSurname.Text) || string.IsNullOrWhiteSpace(TBName.Text) || string.IsNullOrWhiteSpace(TBPassword.Text) || string.IsNullOrWhiteSpace(TBPatronymic.Text) || string.IsNullOrWhiteSpace(TBPhone.Text) || !TBEmail.Text.Contains('@') || !TBEmail.Text.Contains('.') || TBEmail.Text.Count() > 100 || TBPassword.Text.Count() > 100)
        {
            return;
        }
        else
        {
            if (SelectedUser != null)
            {
                App.db.Update(DataContext as User);
            }
            App.db.SaveChanges();
            this.Close();
        }
    }
}