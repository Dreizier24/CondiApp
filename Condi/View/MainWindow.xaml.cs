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
using Condi.DBStorage;
using Condi.View;
using Condi.ViewModel;

namespace Condi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeVM _employeeVM;
        public MainWindow(EmployeeVM employeeVM)
        {
            InitializeComponent();
            _employeeVM = employeeVM;
        }

        private void newRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            AllRequests ar = new AllRequests(_employeeVM);
            ar.Show();
            this.Close();
        }

        private void viewRequestsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void manageRequestBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void employeesManageBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
