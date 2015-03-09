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
using ThePerisan.ViewModel;
using ThePerisan.Model;

namespace ThePerisan
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// Represents the login of a user into the system
    /// </summary>
    public partial class LogInWindow : Window
    {
        OurViewModel _vm;
        bool isUserExsit;

        /// <summary>
        /// The constructor of this class
        /// </summary>
        public LogInWindow()
        {
            InitializeComponent();
            isUserExsit = false;
            _vm = new OurViewModel(new ModelPractical());
            _vm.PropertyChanged += _vm_PropertyChanged;
            this.DataContext = _vm;
        }

        /// <summary>
        /// describes an event of property that have been changed
        /// </summary>
        /// <param name="e">checking if the property is changed and updating the information</param>
        private void _vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "UserExsit")
            {
                isUserExsit = _vm.isUserExsist();
            }
        }

        /// <summary>
        /// an event of click on the button that login the current user with the details his filled in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogInBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            _vm.checkIfUserOK(userNameTXT.Text, passwordTXT.Text);
            if (isUserExsit)
            {
                MainWindow mw = new MainWindow(userNameTXT.Text);
                mw.ShowDialog();
            }
            else
            {
                MessageBox.Show("פרטי התחברות שגויים, נסה שנית","שגיאת התחברות");
                LogInWindow liw = new LogInWindow();
                liw.ShowDialog();
            }
        }

    }
}
