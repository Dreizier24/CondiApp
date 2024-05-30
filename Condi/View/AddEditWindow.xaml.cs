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
using System.Windows.Shapes;
using Condi.ViewModel;
using Condi.DBStorage;
using System.Data.Entity.Migrations;

namespace Condi.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private Request _request;
        private List<EquipmentType> _equipmentTypes;
        public AddEditWindow(EmployeeVM employeeVM, Request request)
        {

            InitializeComponent();


            foreach (var item in App.Current.Windows)
            {
                if (item is AllRequests)
                    this.Owner = item as Window;
            }

            if (request != null)
            {
                _request = request;
            }
            else
            {
                _request = new Request();
            }

            _request.DateAdded = DateTime.Now;
            _request.StatusId = 1;
            _request.ApplicantId = employeeVM.Id;

            this.DataContext = _request;

            LoadEquipmentTypes();

        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CondiEntities())
            {
                try
                {
                    db.Request.AddOrUpdate(_request);
                    db.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    (Owner as AllRequests)?.RefreshData();
                    Owner.Focus();
                    this.Close();
                } catch (Exception ex)
                {
                    MessageBox.Show($"Во время сохранения произошла ошибка\nПодробности:\n{ex}");
                }
            }
        }

        public void LoadEquipmentTypes()
        {
            using (var db = new CondiEntities())
            {
                _equipmentTypes = db.EquipmentType.ToList();
                EquipmentTypeComboBox.ItemsSource = _equipmentTypes;
            }
        }
    }
}
