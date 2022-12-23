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

namespace WPFFlowerShop.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageAdministrator.xaml
    /// </summary>
    public partial class PageAdministrator : Page
    {
        public PageAdministrator()
        {
            InitializeComponent();
            ReloadData();
            SortProducts();
            FilterProducts();

        }
        Products[] ReloadFilterAndSortingProduts()
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

            return products.ToArray();
        }

        private void ReloadData()
        {
            ListViewProducts.ItemsSource = Entities.GetContext().Products.ToList();
            ListViewUsers.ItemsSource = Entities.GetContext().Staff.ToList();
        }

        private void SortProducts()
        {
            cbsort.Items.Add("-Без сортировки-");
            cbsort.Items.Add("Стоимость по возрастанию");
            cbsort.Items.Add("Стоимость по убыванию");

            cbsort.SelectedIndex = 0;
        }
        private void FilterProducts()
        {
            cbfiltr.Items.Add("-Все производители-");
            foreach (var manufacturers in AppConnect.model0DB.Products)
            {
                cbfiltr.Items.Add(manufacturers.Name);
            }

          cbfiltr.SelectedIndex = 0;
        }
        private void tbpoisk_KeyUp(object sender, KeyEventArgs e)
        {
            ListViewProducts.ItemsSource = ReloadFilterAndSortingProduts();
        }

        private void cbsort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewProducts.ItemsSource = ReloadFilterAndSortingProduts();
        }

        private void cbfiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewProducts.ItemsSource = ReloadFilterAndSortingProduts();
        }

        private void ProductsUpdate_Click(object sender, RoutedEventArgs e)
        {
            ListViewProducts.Items.Refresh();
        }

        private void ProductsAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAddProduct());
        }

        private void ProductsEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var productsObj = ListViewProducts.SelectedItems.Cast<Products>().ToList().ElementAt(0);
                Products products = new Products()
                {
                    Name = productsObj.Name,
                    //Price = productsObj.Cost,
                    //InStock = productsObj.InStock,
                    //IdManufacturer = productsObj.IdManufacturer,
                    //ImageProduct = productsObj.ImageProduct
                };
                AppFrame.frameMain.Navigate(new PageAddProduct(products));
            }
            catch
            {
                MessageBox.Show("Выберите запись для редактирования!");
            }
        }
        private void ProductsDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var productsObj = ListViewProducts.SelectedItems.Cast<Products>().ToList().ElementAt(0);
                if (MessageBox.Show("Вы подтверждаете безвозвратное удаление записи?", "Предупреждение!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        var addvar = Entities.GetContext().Products.Where(x => x.ID_Product == productsObj.ID_Product).FirstOrDefault();
                        Entities.GetContext().Products.Remove(addvar);
                        Entities.GetContext().SaveChanges();
                        MessageBox.Show("Запись успешна удалёна!");

                        ListViewProducts.ItemsSource = Entities.GetContext().Products.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Выберите запись для удаления!");
            }
        }
        private void UsersUpdate_Click(object sender, RoutedEventArgs e)
        {
            ListViewUsers.Items.Refresh();
        }

        private void UsersAdd_Click(object sender, RoutedEventArgs e)
        {
                
        }

        private void UsersEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var usersObj = ListViewUsers.SelectedItems.Cast<Staff>().ToList().ElementAt(0);
                Staff users = new Staff()
                {
               
                    Login = usersObj.Login,
                    Password = usersObj.Password,
              
                    Surname = usersObj.Surname,
                    Name = usersObj.Name,
                 
                };
                
            }
            catch
            {
                MessageBox.Show("Выберите запись для редактирования!");
            }
        }
    
    }
}

