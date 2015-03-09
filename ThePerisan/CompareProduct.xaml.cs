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
using ThePerisan.Model;
using ThePerisan.ViewModel;

namespace ThePerisan
{
    /// <summary>
    /// Interaction logic for CompareProduct.xaml
    /// </summary>
    public partial class CompareProduct : Window
    {
        OurViewModel _vm;
        string _userName;

        /// <summary>
        /// The consturctor of this class - initialize the CompareProduct class
        /// </summary>
        /// <param name="userName">The current user name in the system</param>
        public CompareProduct(string userName)
        {
            InitializeComponent();
            _userName = userName;
            _vm = new OurViewModel(new ModelPractical());
            _vm.PropertyChanged += _vm_PropertyChanged;
            this.DataContext = _vm;
        }

        /// <summary>
        /// ready for updating the current information and displaying a product window
        /// </summary>
        /// <param name="e">if a "DataTable" has been changed pop up a new product window</param>
        private void _vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DataTable")
            {
                this.Hide();
                ProductsDisplayWindow pdm = new ProductsDisplayWindow(_vm.getDataTable(), productCompareTXT.Text, _userName);
                pdm.ShowDialog();
            }
        }

        /// <summary>
        /// an event that starts the searching for a product in the system
        /// </summary>
        private void SearchProductBTN_Click(object sender, RoutedEventArgs e)
        {
            _vm.SearchAproduct(productCompareTXT.Text);
        }

        /// <summary>
        /// click event that will make the main window to appear
        /// </summary>
        private void backToMenuBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow(_userName);
            mw.ShowDialog();
        }
    }
}
