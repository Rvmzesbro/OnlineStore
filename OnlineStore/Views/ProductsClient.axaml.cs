using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OnlineStore.Models;
using System.Collections.Generic;

namespace OnlineStore;

public partial class ProductsClient : Window
{
    public List<Basket> SelectedProduct = new List<Basket>();
    public ProductsClient(List<Basket> products)
    {
        InitializeComponent();
        SelectedProduct = products;
        LBProducts.ItemsSource = products;
    }
}