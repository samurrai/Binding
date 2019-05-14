using Binding.DataAccess;
using Binding.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Binding
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Item> _items;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            using (var context = new ShopContext())
            {
                _items = new ObservableCollection<Item>(context.Items.ToList());
                itemsDataGrid.ItemsSource = _items;
            }
        }

        private async void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            SetLoading(true);
            var item = new Item
            {
                Name = nameTextBox.Text,
                Price = int.Parse(priceTextBox.Text),
                Description = new TextRange(descriptionRichTextBox.Document.ContentStart, descriptionRichTextBox.Document.ContentEnd).Text
            };

            using (var context = new ShopContext())
            {
                context.Items.Add(item);
                _items.Add(item);

                await context.SaveChangesAsync();
            }
            SetLoading(false);
        }

        private void SetLoading(bool isLoading)
        {
            if (isLoading)
            {
                progressBar.Visibility = Visibility.Visible;
                statusTextBlock.Text = "Пожалуйста подождите...";
            }
            else
            {
                progressBar.Visibility = Visibility.Collapsed;
                statusTextBlock.Text = "Готово";
            }
        }

        private void ChangeFirstRowButtonClick(object sender, RoutedEventArgs e)
        {
            var item = _items[0];
            item.Name = "Супер мега товар 3000";
        }
    }
}
