using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using OnlineStore.Models;
using System;
using System.IO;
using System.Linq;

namespace OnlineStore;

public partial class ProductAddEdit : Window
{
    public Storage SelectedStorage { get; set; }
    private byte[]? SelectedImage;
    public ProductAddEdit(Storage storage)
    {
        InitializeComponent();
        Bindings();
        SelectedStorage = storage;

        if (SelectedStorage == null) return;

        DataContext = SelectedStorage;

        if (SelectedStorage.Product?.Image != null)
        {
            LoadImageFromByteArray(SelectedStorage.Product.Image);
        }
    }

    private void Bindings()
    {
        CBCategory.ItemsSource = App.db.CategoryProducts.ToList();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //if (string.IsNullOrWhiteSpace(TBName.Text) || string.IsNullOrWhiteSpace(TBDescription.Text) || string.IsNullOrWhiteSpace(TBPrice.Text) || string.IsNullOrWhiteSpace(TBCount.Text) || CBCategory.SelectedItem == null)
        //{
        //    return;
        //}
        //else
        //{
        //    if (SelectedStorage != null)
        //    {
        //        if (!decimal.TryParse(TBPrice.Text, out decimal result)) return;
        //        if (!decimal.TryParse(TBCount.Text, out decimal result1)) return;

        //        App.db.Update(DataContext as Storage);
        //    }
        //    else
        //    {
        //        if (!decimal.TryParse(TBPrice.Text, out decimal result)) return;
        //        if (!decimal.TryParse(TBCount.Text, out decimal result1)) return;

        //        var NewProduct = new Product()
        //        {
        //            Name = TBName.Text,
        //            Description = TBDescription.Text,
        //            Price = int.Parse(TBPrice.Text),
        //            CategoryId = CBCategory.SelectedIndex + 1
        //        };
        //        App.db.Products.Add(NewProduct);
        //        App.db.SaveChanges();

        //        var NewStorage = new Storage()
        //        {
        //            ProductId = NewProduct.Id,
        //            Count = decimal.Parse(TBCount.Text),
        //        };
        //        App.db.Storages.Add(NewStorage);

        //    }
        //    App.db.SaveChanges();
        //    this.Close();
        //}

        if (string.IsNullOrWhiteSpace(TBName.Text) ||
            string.IsNullOrWhiteSpace(TBDescription.Text) ||
            string.IsNullOrWhiteSpace(TBPrice.Text) ||
            string.IsNullOrWhiteSpace(TBCount.Text) ||
            CBCategory.SelectedItem == null)
        {
            //MessageBox.Show(this, "Please fill all fields", "Error");
            return;
        }

        try
        {
            if (SelectedStorage != null)
            {
                // Редактирование существующего продукта
                if (!decimal.TryParse(TBPrice.Text, out decimal priceResult))
                {
                    //MessageBox.Show(this, "Invalid price format", "Error");
                    return;
                }
                if (!decimal.TryParse(TBCount.Text, out decimal countResult))
                {
                    //MessageBox.Show(this, "Invalid count format", "Error");
                    return;
                }

                // Обновляем данные
                var storage = DataContext as Storage;
                if (storage != null)
                {
                    storage.Product.Name = TBName.Text;
                    storage.Product.Description = TBDescription.Text;
                    storage.Product.Price = priceResult;
                    storage.Product.CategoryId = CBCategory.SelectedIndex + 1;
                    storage.Count = countResult;

                    // Сохраняем изображение
                    if (SelectedImage != null)
                    {
                        storage.Product.Image = SelectedImage;
                    }

                    App.db.Update(storage);
                }
            }
            else
            {
                // Создание нового продукта
                if (!decimal.TryParse(TBPrice.Text, out decimal priceResult))
                {
                    //MessageBox.Show(this, "Invalid price format", "Error");
                    return;
                }
                if (!decimal.TryParse(TBCount.Text, out decimal countResult))
                {
                    //MessageBox.Show(this, "Invalid count format", "Error");
                    return;
                }

                var selectedCategory = CBCategory.SelectedItem as CategoryProduct;
                if (selectedCategory == null)
                {
                    //MessageBox.Show(this, "Please select a category", "Error");
                    return;
                }

                var newProduct = new Product()
                {
                    Name = TBName.Text,
                    Description = TBDescription.Text,
                    Price = priceResult,
                    CategoryId = selectedCategory.Id,
                    Image = SelectedImage // Сохраняем изображение
                };

                App.db.Products.Add(newProduct);
                App.db.SaveChanges();

                var newStorage = new Storage()
                {
                    ProductId = newProduct.Id,
                    Count = countResult,
                };
                App.db.Storages.Add(newStorage);
            }

            App.db.SaveChanges();
            this.Close();
        }
        catch (Exception ex)
        {
            //MessageBox.Show(this, "Error saving product: " + ex.Message, "Error");
        }
    }

    


    private void LoadImageFromByteArray(byte[] imageData)
    {
        try
        {
            using var memoryStream = new MemoryStream(imageData);
            ImagePreview.Source = new Avalonia.Media.Imaging.Bitmap(memoryStream);
        }
        catch (Exception ex)
        {
            
        }
    }

    private async void BTLoadImage_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            // Получаем TopLevel для доступа к StorageProvider
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel == null) return;

            // Настройка фильтров файлов
            var fileTypes = new FilePickerFileType[]
            {
                new("Image Files")
                {
                    Patterns = new[] { "*.png", "*.jpg", "*.jpeg", "*.bmp", "*.gif" },
                    MimeTypes = new[] { "image/png", "image/jpeg", "image/bmp", "image/gif" }
                }
            };

            // Открытие диалога выбора файла
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Select product image",
                AllowMultiple = false,
                FileTypeFilter = fileTypes
            });

            if (files.Count > 0 && files[0] is IStorageFile file)
            {
                // Читаем файл в byte[]
                await using var stream = await file.OpenReadAsync();
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                SelectedImage = memoryStream.ToArray();

                // Показываем изображение в превью
                LoadImageFromByteArray(SelectedImage);

                // Показываем кнопку очистки
                BTClearImage.IsVisible = true;
                TBNoImage.IsVisible = false;
            }
        }
        catch (Exception ex)
        {
            
        }

    }

    private void BTClearImage_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SelectedImage = null;
        ImagePreview.Source = null;
        BTClearImage.IsVisible = false;
        TBNoImage.IsVisible = true;
    }
}