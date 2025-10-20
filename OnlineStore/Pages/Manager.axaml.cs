using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OnlineStore.Models;
using System.Linq;

namespace OnlineStore;

public partial class Manager : UserControl
{
    public User SelectedUser { get; set; }
    public Manager(User user)
    {
        InitializeComponent();
        SelectedUser = user;
        DataContext = SelectedUser;
        Bindings();
    }

    private void Filter()
    {
        if (TBSearch == null || DGProduct == null) return;

        var searchText = TBSearch.Text?.ToLower() ?? string.Empty;
        var selectedCategory = CBFilter.SelectedItem as CategoryProduct;
        var searchPriceText = TBSearchPrice?.Text ?? string.Empty;

        var allProducts = App.db.Storages.ToList();

        if (!string.IsNullOrWhiteSpace(searchText))
        {
            allProducts = allProducts.Where(p => p.Product?.Name?.ToLower().Contains(searchText) == true).ToList();
        }

        if (selectedCategory != null)
        {
            allProducts = allProducts.Where(p => p.Product?.CategoryId == selectedCategory.Id).ToList();
        }

        if (!string.IsNullOrWhiteSpace(searchPriceText))
        {
            allProducts = allProducts.Where(p => p.Product?.Price != null && p.Product.Price.ToString().Contains(searchPriceText)).ToList();
        }

        DGProduct.ItemsSource = allProducts;
    }

    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        Filter();
    }
    private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        Filter();
    }

    private void Bindings()
    {
        DGClient.ItemsSource = App.db.Users.Where(p => p.RoleId == 3).ToList();
        DGProduct.ItemsSource = App.db.Storages.ToList();
        DGPaysClients.ItemsSource = App.db.Orders.ToList();
        CBFilter.ItemsSource = App.db.CategoryProducts.ToList();
        Filter();
    }


    private async void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (TIProduct.IsSelected)
        {
            var TransitionView = new AddEditProductManager(null, SelectedUser);
            var parent = this.VisualRoot as Window;
            await TransitionView.ShowDialog(parent);
            Bindings();
        }
    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (TIClients.IsSelected)
        {
            if (DGClient.SelectedItem is User DeleteClient)
            {
                App.db.Users.Remove(DeleteClient);
                App.db.SaveChanges();
                Bindings();
            }
        }
        if (TIProduct.IsSelected)
        {
            if (DGProduct.SelectedItem is Storage DeleteStorage)
            {
                App.db.Storages.Remove(DeleteStorage);
                App.db.SaveChanges();
                var DeleteProduct = App.db.Products.Where(p => p.Id == DeleteStorage.ProductId);
                foreach (var product in DeleteProduct)
                {
                    App.db.Products.Remove(product);
                }
                App.db.SaveChanges();
                Bindings();
            }
        }

        if (TIPaysClients.IsSelected)
        {
            if(DGPaysClients.SelectedItem is Basket DeleteBasket)
            {
                App.db.Baskets.Remove(DeleteBasket);
                App.db.SaveChanges();
                Bindings();
            }
        }
    }

    private async void DataGrid_DoubleTapped_1(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (DGClient.SelectedItem is User client)
        {
            var TransitionView1 = new ClientAddEdit(client);
            var parent = this.VisualRoot as Window;
            await TransitionView1.ShowDialog(parent);
            Bindings();
        }
    }

    private async void DataGrid_DoubleTapped_2(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (DGProduct.SelectedItem is Storage storage)
        {
            var TransitionView = new AddEditProductManager(storage, SelectedUser);
            var parent = this.VisualRoot as Window;
            await TransitionView.ShowDialog(parent);
            Bindings();
        }
    }

    private void TabItem_Tapped_3(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        BTAdd.Opacity = 0.0;
        BTRemove.Opacity = 1.0;
        TBSearch.Opacity = 0.0;
        TBSearchPrice.Opacity = 0.0;
        CBFilter.Opacity = 0.0;
    }

    private void TabItem_Tapped_5(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        BTAdd.Opacity = 1.0;
        BTRemove.Opacity = 1.0;
        TBSearch.Opacity = 1.0;
        TBSearchPrice.Opacity = 1.0;
        CBFilter.Opacity = 1.0;
    }

    private void TabItem_Tapped_6(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        BTAdd.Opacity = 0.0;
        BTRemove.Opacity = 1.0;
        TBSearch.Opacity = 0.0;
        TBSearchPrice.Opacity = 0.0;
        CBFilter.Opacity = 0.0;
    }

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MyContent.Content = new ManagerProfile(SelectedUser);
    }

    private void Button_Click_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MyContent.Content = new Main();
    }

    private async void DataGrid_DoubleTapped_7(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if(DGPaysClients.SelectedItem is Order order)
        {
            var TransitionView = new EditPaysClient(order);
            var parent = this.VisualRoot as Window;
            await TransitionView.ShowDialog(parent);
            Bindings();
        }
    }
}