using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OnlineStore;

public partial class EditPaysClient : Window
{
    public List<Basket> products = new List<Basket>();
    public Order SelectedOrder { get; set; }
    public EditPaysClient(Order order)
    {
        InitializeComponent();
        SelectedOrder = order;
        DataContext = SelectedOrder;
        products = SelectedOrder.Baskets.Where(p => p.OrderId == order.Id).ToList();
        Bindings();
    }

    private void Bindings()
    {
        CBProduct.ItemsSource = App.db.Products.ToList();
        CBStatus.ItemsSource = App.db.Statuses.ToList();
        DGProducts.ItemsSource = products;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (CBStatus.SelectedItem == null || string.IsNullOrWhiteSpace(TBCountProduct.Text) || CBProduct.SelectedItem == null) return;
       
        else
        {
            if (SelectedOrder != null)
            {
                App.db.Update(DataContext as Basket);
            }
            App.db.SaveChanges();
            this.Close();
        }
    }

    private async void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var TransitionView = new ProductsClient(products);
        var parent = this.VisualRoot as Window;
        await TransitionView.ShowDialog(parent);
    }
}