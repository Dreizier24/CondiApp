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

namespace Condi.View
{
    /// <summary>
    /// Логика взаимодействия для AllRequests.xaml
    /// </summary>
    public partial class AllRequests : Window
    {
        private EmployeeVM _employeeVM;
        public AllRequests(EmployeeVM employeeVM)
        {
            InitializeComponent();
            _employeeVM = employeeVM;

            this.DataContext = new RequestVM();

        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(_employeeVM);
            mw.Show();
            this.Close();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow aew = new AddEditWindow(_employeeVM,null);
            aew.ShowDialog();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow aew = new AddEditWindow(_employeeVM, (DataContext as RequestVM).SelectedRequest);
            aew.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as RequestVM).DeleteSelectedRequest();
        }

        public void RefreshData()
        {
            (DataContext as RequestVM).LoadRequests();
        }
    }
}
