using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OnlineStore.Models;

namespace OnlineStore;

public partial class ManagerProfile : UserControl
{
    public User SelectedUser { get; set; }
    public ManagerProfile(User user)
    {
        InitializeComponent();
        SelectedUser = user;
        DataContext = SelectedUser;
    }
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MyContent.Content = new Manager(SelectedUser);
    }

    private async void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var TransitionView = new EditProfile(SelectedUser);
        var parent = this.VisualRoot as Window;
        await TransitionView.ShowDialog(parent);

        DataContext = null;
        DataContext = SelectedUser;
    }
}