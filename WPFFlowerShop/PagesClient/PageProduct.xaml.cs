using System;
using System.Collections.Generic;
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
using WPFFlowerShop.ApplicationData;

namespace WPFFlowerShop.PagesClient
{
    /// <summary>
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
}


public partial class PageProduct : Page
{
    public PageProduct()
    {
        InitializeComponent();
        ReloadData();
        SortListView();
        FilterListView();
    }
    private void SortListView()
    {
        cbsort.Items.Add("-Без сортировки-");
        cbsort.Items.Add("Стоимость по возрастанию");
        cbsort.Items.Add("Стоимость по убыванию");

        cbsort.SelectedIndex = 0;
    }

    private void FilterListView()
    {
        cbsort.Items.Add("-Все производители-");
        foreach (var manufacturer in AppConnect.model0DB.Suppliers)
        {
            cbfiltr.Items.Add(manufacturer.Name);
        }

        cbfiltr.SelectedIndex = 0;
    }
    Products[] SortFilterProducts()
    {
        List<Products> products = AppConnect.model0DB.Products.ToList();
        var CounterData = products;
        if (tbpoisk.Text != null)
        {
            products = products.Where(x => x.Name.ToLower().Contains(tbpoisk.Text.ToLower())).ToList();

            switch (cbsort.SelectedIndex)
            {
                case 1:
                    products = products.OrderBy(x => x.Price).ToList();
                    break;
                case 2:
                    products = products.OrderByDescending(x => x.Price).ToList();
                    break;
            }
        }

        if (cbfiltr.SelectedIndex > 0)
        {
            products = products.Where(x => x.Suppliers.Name == cbfiltr.SelectedItem.ToString()).ToList();
        }

        if (products.Count != 0)
        {
            ProductsCounter.Content = "Показано товаров: " + products.Count + " из " + CounterData.Count;
        }
        else
        {
            ProductsCounter.Content = "Не найдено";
        }

        return products.ToArray();
    }
    private void ReloadData()
    {
        ListProduct.ItemsSource = Entities.GetContext().Products.ToList();

    }
    private void MenuClientUpdate_Click(object sender, RoutedEventArgs e)
    {

    }

    private void MenuClientBack_Click(object sender, RoutedEventArgs e)
    {
        AppFrame.frameMain.GoBack();
    }

    private void tbpoisk_KeyUp(object sender, KeyEventArgs e)
    {
        ListProduct.ItemsSource = SortFilterProducts();
    }

    private void cbsort_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListProduct.ItemsSource = SortFilterProducts();
    }

    private void cbfiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListProduct.ItemsSource = SortFilterProducts();
    }
}


}
