using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        EmployeeVM employeeVM = new EmployeeVM();
        public AuthWindow()
        {
            InitializeComponent();

            this.DataContext = employeeVM;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            employeeVM.AuthInApp();
            if (employeeVM.IsAutheticated)
            {
                this.Close();
            }
        }
    }
}
