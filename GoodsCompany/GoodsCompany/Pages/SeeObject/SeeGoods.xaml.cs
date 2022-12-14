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

namespace GoodsCompany.Pages.SeeObject
{
    /// <summary>
    /// Логика взаимодействия для SeeGoods.xaml
    /// </summary>
    public partial class SeeGoods : Page
    {
        public SeeGoods()
        {
            InitializeComponent();
            DBGridModel.ItemsSource = Model.GoodsEntities.GetContext().Good.OrderBy(x => x.NameGood).ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddAndEditObject.AddAndEditGoods((sender as Button).DataContext as Model.Good));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddAndEditObject.AddAndEditGoods(null));

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var deleteData = DBGridModel.SelectedItems.Cast<Model.Good>().ToList();

            if (MessageBox.Show($"Вы уверены в том, что хотите удалить {deleteData.Count()} элемента.", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Model.GoodsEntities.GetContext().Good.RemoveRange(deleteData);
                Model.GoodsEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация удалена успешно", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                DBGridModel.ItemsSource = Model.GoodsEntities.GetContext().Good.OrderBy(x => x.NameGood).ToList();
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            DBGridModel.ItemsSource = Model.GoodsEntities.GetContext().Good.OrderBy(x => x.NameGood).ToList();
        }
    }
}
