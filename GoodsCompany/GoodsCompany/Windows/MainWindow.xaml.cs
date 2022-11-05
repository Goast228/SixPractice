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
using Word = Microsoft.Office.Interop.Word;

namespace GoodsCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.SeeObject.SeeGoods());
            Classes.Manager.MainFrame = MainFrame;
        }

        #region Визуализация кнопки "Назад"

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
                BtnBack.Visibility = Visibility.Visible;
            else
                BtnBack.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Просмотр объектов из Базы Данных

        private void SeeGoodsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.SeeObject.SeeGoods());
        }

        private void SeeSupervisorBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.SeeObject.SeeSupervisor());
        }

        private void SeeCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.SeeObject.SeeCompany());
        }

        #endregion

        #region Генерация WORD документов

        private void WordGoodBtn_Click(object sender, RoutedEventArgs e)
        {
            var goods = Model.GoodsEntities.GetContext().Good.OrderBy(x => x.NameGood).ToList();
            Word.Application app = new Word.Application();
            Word.Document document = app.Documents.Add();
            int startRowIndex = 1;
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.Text = "Список товаров";
            paragraph.set_Style("Заголовок 1");
            range.InsertParagraphAfter();
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table table = document.Tables.Add(tableRange, goods.Count() + 1, 3);
            Word.Range cellRange;
            cellRange = table.Cell(1, 1).Range;
            cellRange.Text = "Наименование товара";
            cellRange = table.Cell(1, 2).Range;
            cellRange.Text = "Номер товара";
            cellRange = table.Cell(1, 3).Range;
            cellRange.Text = "Группа товара";
            startRowIndex++;
            foreach (var item in goods)
            {
                cellRange = table.Cell(startRowIndex, 1).Range;
                cellRange.Text = item.NameGood;
                cellRange = table.Cell(startRowIndex, 2).Range;
                cellRange.Text = Convert.ToString(item.NumberGood);
                cellRange = table.Cell(startRowIndex, 3).Range;
                cellRange.Text = item.GoodsGroup.NameGroup;
                startRowIndex++;
            }
            app.Visible = true;
            document.SaveAs2(@"C:\WordFile.docx");
            document.SaveAs2(@"C:\WordFile.pdf", Word.WdExportFormat.wdExportFormatPDF);
        }

        private void WordSupervisorBtn_Click(object sender, RoutedEventArgs e)
        {
            var supervisor = Model.GoodsEntities.GetContext().Supervisor.OrderBy(x => x.FIO).ToList();
            Word.Application app = new Word.Application();
            Word.Document document = app.Documents.Add();
            int startRowIndex = 1;
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.Text = "Список товаров";
            paragraph.set_Style("Заголовок 1");
            range.InsertParagraphAfter();
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table table = document.Tables.Add(tableRange, supervisor.Count() + 1, 2);
            Word.Range cellRange;
            cellRange = table.Cell(1, 1).Range;
            cellRange.Text = "Фамилия Имя Отчество";
            cellRange = table.Cell(1, 2).Range;
            cellRange.Text = "Должность";
            startRowIndex++;
            foreach (var item in supervisor)
            {
                cellRange = table.Cell(startRowIndex, 1).Range;
                cellRange.Text = item.FIO;
                cellRange = table.Cell(startRowIndex, 2).Range;
                cellRange.Text = item.Position;
                startRowIndex++;
            }
            app.Visible = true;
            document.SaveAs2(@"C:\WordFile.docx");
            document.SaveAs2(@"C:\WordFile.pdf", Word.WdExportFormat.wdExportFormatPDF);
        }

        private void WordCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            var company = Model.GoodsEntities.GetContext().Company.OrderBy(x => x.CompanyName).ToList();
            Word.Application app = new Word.Application();
            Word.Document document = app.Documents.Add();
            int startRowIndex = 1;
            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.Text = "Список товаров";
            paragraph.set_Style("Заголовок 1");
            range.InsertParagraphAfter();
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table table = document.Tables.Add(tableRange, company.Count() + 1, 6);
            Word.Range cellRange;
            cellRange = table.Cell(1, 1).Range;
            cellRange.Text = "Название компании";
            cellRange = table.Cell(1, 2).Range;
            cellRange.Text = "Статический номер";
            cellRange = table.Cell(1, 3).Range;
            cellRange.Text = "Адрес компании";
            cellRange = table.Cell(1, 4).Range;
            cellRange.Text = "Телефон компании";
            cellRange = table.Cell(1, 5).Range;
            cellRange.Text = "Руководитель отдела маркетинга";
            cellRange = table.Cell(1, 6).Range;
            cellRange.Text = "Руководитель компании";
            startRowIndex++;
            foreach (var item in company)
            {
                cellRange = table.Cell(startRowIndex, 1).Range;
                cellRange.Text = item.CompanyName;
                cellRange = table.Cell(startRowIndex, 2).Range;
                cellRange.Text = Convert.ToString(item.StaticCode);
                cellRange = table.Cell(startRowIndex, 3).Range;
                cellRange.Text = item.Address;
                cellRange = table.Cell(startRowIndex, 4).Range;
                cellRange.Text = item.TelephoneNumber;
                cellRange = table.Cell(startRowIndex, 5).Range;
                cellRange.Text = item.MarketingDepartment.ContactPerson;
                cellRange = table.Cell(startRowIndex, 6).Range;
                cellRange.Text = item.Supervisor.FIO;
                startRowIndex++;
            }
            app.Visible = true;
            document.SaveAs2(@"C:\WordFile.docx");
            document.SaveAs2(@"C:\WordFile.pdf", Word.WdExportFormat.wdExportFormatPDF);
        }

        #endregion
    }
}
