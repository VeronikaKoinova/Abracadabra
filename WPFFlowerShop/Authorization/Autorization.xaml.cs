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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFFlowerShop.ApplicationData;
using WPFFlowerShop.PagesClient;
using WPFFlowerShop.Authorization;
using System.CodeDom;
using WPFFlowerShop.PageAdmin;
using System.Xml.Linq;

namespace WPFFlowerShop.Authorization
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }
        public static bool check_user(string login, string password)
        {
            var AllStaff = AppConnect.model0DB.Staff.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (AllStaff == null)
                return false;
            return true;

        }
        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    var user = AppConnect.model0DB.Staff.FirstOrDefault(x => x.Login == log.Text && x.Password == pass.Password);
                    if (user == null)
                    {
                        MessageBox.Show("Erorr", "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else

                    {
                        switch (user.ID_Post)
                        {
                            case 1:
                                MessageBox.Show("Здравствуйте, Администратор " + user.Name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                AppFrame.frameMain.Navigate(new PageAdministrator());
                                break;
                            case 2:
                                MessageBox.Show("Здравствуйте, Клиент " + user.Name + "!",
                             "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                AppFrame.frameMain.Navigate(new PageProduct());
                                break;
                            case 3:
                                MessageBox.Show("Здравствуйте, Менеджер " + user.Name + "!",
                             "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                AppFrame.frameMain.Navigate(new PageProduct());
                                break;
                            default:
                                MessageBox.Show("Данный пользователь не имеет роли!", "Уведомление", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                                break;
                        }

                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("no" + Ex.Message, "aaa", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
        }
    }
}
//}
//MessageBox.Show("hello" + Name.ToString(), "ddhdh", MessageBoxButton.OK, MessageBoxImage.Information);
//AppFrame.frameMain.Navigate(new PageProduct());