using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OnlineStore.Models;
using System;
using System.Linq;
using System.Net.Sockets;

namespace OnlineStore;

public partial class Client : UserControl
{
    public User SelectedUser { get; set; }
    public Client(User user)
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
        DGProduct.ItemsSource = App.db.Storages.ToList();
        LoadBasketData();
        LoadOrdersData();
        CBFilter.ItemsSource = App.db.CategoryProducts.ToList();
        Filter();
    }


    private async void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var basketItems = App.db.Baskets
            .Where(b => b.UserId == SelectedUser.Id && b.OrderId == null)
            .ToList();

        if (!basketItems.Any())
        {
            //MessageBox.Show("Корзина пуста");
            return;
        }

        var TotalSum = basketItems.Sum(p => p.CountProduct * p.Product.Price);

        if (SelectedUser.Balance < TotalSum) return;

        // Проверяем наличие товаров на складе
        foreach (var basketItem in basketItems)
        {
            var storage = App.db.Storages.FirstOrDefault(s => s.ProductId == basketItem.ProductId);
            if (storage == null || storage.Count < basketItem.CountProduct)
            {
                //MessageBox.Show($"Недостаточно товара: {basketItem.Product.Name}");
                return;
            }
        }

        // Создаем новый заказ
        var newOrder = new Order
        {
            Date = DateTime.Now,
            StatusId = 1 // Статус "В обработке"
        };

        App.db.Orders.Add(newOrder);
        App.db.SaveChanges();
        

        // Привязываем товары корзины к заказу и уменьшаем количество на складе
        foreach (var basketItem in basketItems)
        {
            basketItem.OrderId = newOrder.Id;

            // Уменьшаем количество на складе
            var storage = App.db.Storages.First(s => s.ProductId == basketItem.ProductId);
            storage.Count -= basketItem.CountProduct;
        }

        SelectedUser.Balance -= TotalSum;

        App.db.SaveChanges();
        LoadBasketData();
        LoadOrdersData();
    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        if (TIBasket.IsSelected)
        {
            if (DGPaysClients.SelectedItem is Basket DeleteBasket)
            {
                App.db.Baskets.Remove(DeleteBasket);
                App.db.SaveChanges();
                Bindings();
            }
        }
    }


    private void TabItem_Tapped_5(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        BTAdd.Opacity = 0.0;
        BTRemove.Opacity = 0.0;
        TBSearch.Opacity = 1.0;
        TBSearchPrice.Opacity = 1.0;
        CBFilter.Opacity = 1.0;
    }

    private void TabItem_Tapped_6(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        BTAdd.Opacity = 1.0;
        BTRemove.Opacity = 1.0;
        TBSearch.Opacity = 0.0;
        TBSearchPrice.Opacity = 0.0;
        CBFilter.Opacity = 0.0;
    }

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MyContent.Content = new ClientProfile(SelectedUser);
    }

    private void Button_Click_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.MainWindow.MyContent.Content = new Main();
    }

    private async void DataGrid_DoubleTapped_7(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        //if (DGPaysClients.SelectedItem is Basket basket)
        //{
        //    var TransitionView = new EditPaysClient(basket);
        //    var parent = this.VisualRoot as Window;
        //    await TransitionView.ShowDialog(parent);
        //    Bindings();
        //}
    }

    // Загрузка данных корзины (товары без заказа)
    private void LoadBasketData()
    {
        var basketItems = App.db.Baskets
            .Where(b => b.UserId == SelectedUser.Id && b.OrderId == null)
            .ToList();
        DGPaysClients.ItemsSource = basketItems;
    }

    // Загрузка данных заказов (товары с заказом)
    private void LoadOrdersData()
    {
        var orderItems = App.db.Baskets
            .Where(b => b.UserId == SelectedUser.Id && b.OrderId != null)
            .ToList();
        DGOrder.ItemsSource = orderItems;
    }

    private void Button_Click_5(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is Storage storage)
        {
            // Проверяем, есть ли товар на складе
            if (storage.Count <= 0)
            {
                //MessageBox.Show("Товара нет в наличии");
                return;
            }

            // Проверяем, есть ли уже этот товар в корзине
            var existingBasketItem = App.db.Baskets
                .FirstOrDefault(b => b.UserId == SelectedUser.Id &&
                                   b.ProductId == storage.ProductId &&
                                   b.OrderId == null);

            if (existingBasketItem != null)
            {
                // Увеличиваем количество, если есть на складе
                if (existingBasketItem.CountProduct < storage.Count)
                {
                    existingBasketItem.CountProduct += 1;
                }
                else
                {
                    //MessageBox.Show("Недостаточно товара на складе");
                    return;
                }
            }
            else
            {
                // Создаем новую запись в корзине
                var newBasketItem = new Basket
                {
                    UserId = SelectedUser.Id,
                    ProductId = storage.ProductId,
                    CountProduct = 1,
                    OrderId = null
                };
                App.db.Baskets.Add(newBasketItem);
            }

            App.db.SaveChanges();
            LoadBasketData();
            //MessageBox.Show("Товар добавлен в корзину");
        }
    }

    private void TabItem_Tapped_8(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        BTAdd.Opacity = 0.0;
        BTRemove.Opacity = 0.0;
        TBSearch.Opacity = 0.0;
        TBSearchPrice.Opacity = 0.0;
        CBFilter.Opacity = 0.0;
    }
}