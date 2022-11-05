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

namespace GoodsCompany.Pages.AddAndEditObject
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditGoods.xaml
    /// </summary>
    public partial class AddAndEditGoods : Page
    {
        private Model.Good _good = new Model.Good();
        public AddAndEditGoods(Model.Good good)
        {
            InitializeComponent();

            if (good != null)
                _good = good;
            DataContext = _good;

            GoodBox.ItemsSource = Model.GoodsEntities.GetContext().GoodsGroup.ToList();
        }

        private void SaveDatabtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrEmpty(_good.NameGood))
                error.AppendLine("Введите имя товара");
            if (_good.NumberGood < 100)
                error.AppendLine("Номер товара должен быть больше 100!");
            if (_good.GoodsGroup == null)
                error.AppendLine("Выберите группу товара!");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }

            if (_good.Id == 0)
            {
                Model.GoodsEntities.GetContext().Good.Add(_good);
            }

            try
            {
                Model.GoodsEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
                Classes.Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка! Текст ошибки: \n" + ex.Message);
            }
        }
    }
}
