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

namespace ThePerisan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// The main menu of the application
    /// </summary>
    public partial class MainWindow : Window
    {
        string _userName;

        /// <summary>
        /// The consturctor of the main window
        /// </summary>
        /// <param name="userName">the current user name that in the main window</param>
        public MainWindow(string userName)
        {
            InitializeComponent();
            _userName = userName;
        }

        /// <summary>
        /// a click event of adding a new product
        /// </summary>
        private void AddProductMenuBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddProductWindow ap = new AddProductWindow(_userName);
            ap.ShowDialog();
        }

        /// <summary>
        /// a click event comparing for a product
        /// </summary>
        private void CompMenuBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CompareProduct cp = new CompareProduct(_userName);
            cp.ShowDialog();
        }

        private void backToLogInBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LogInWindow liw = new LogInWindow();
            liw.ShowDialog();
        }
    }
}
