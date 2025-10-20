using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using OnlineStore.Models;
using System;
using System.ComponentModel;

namespace OnlineStore;

public partial class AdminProfile : UserControl
{
    public User SelectedUser { get; set; }
    public AdminProfile(User user)
    {
        InitializeComponent();
        SelectedUser = user;
        DataContext = SelectedUser;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MyContent.Content = new Admin(SelectedUser);
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