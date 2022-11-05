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
    /// Логика взаимодействия для AddAndEditSupervisor.xaml
    /// </summary>
    public partial class AddAndEditSupervisor : Page
    {
        private Model.Supervisor _supervisor = new Model.Supervisor();
        public AddAndEditSupervisor(Model.Supervisor supervisor)
        {
            InitializeComponent();

            if (supervisor != null)
                _supervisor = supervisor;
            DataContext = _supervisor;
        }

        private void SaveDatabtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrEmpty(_supervisor.FIO))
                error.AppendLine("Введите ФИО руководителя!");
            if (string.IsNullOrEmpty(_supervisor.Position))
                error.AppendLine("Введите должность руководителя");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }

            if (_supervisor.Id == 0)
            {
                Model.GoodsEntities.GetContext().Supervisor.Add(_supervisor);
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
