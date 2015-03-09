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
    /// This class is about adding a new product GUI
    /// </summary>
    public partial class AddProductWindow : Window
    {
        OurViewModel _vm;
        string _userName;
        bool _productExsist;
        bool _superExsist;

        /// <summary>
        /// The consturctor of this class - initialize the adding product window
        /// </summary>
        /// <param name="userName">gets the user name from the log in screen</param>
        public AddProductWindow(string userName)
        {
            InitializeComponent();
            _userName = userName;
            _vm = new OurViewModel(new ModelPractical());
            _vm.PropertyChanged += _vm_PropertyChanged;
            this.DataContext = _vm;
            _productExsist = false;
            _superExsist = false;
        }

        /// <summary>
        /// Main button of this window, start the proccess of adding a new product
        /// </summary>
        private void AddProductBTN_Click(object sender, RoutedEventArgs e)
        {
            /*
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
             */
            double priceAsDouble = 0.0;
            try
            {
                priceAsDouble = Convert.ToDouble(productPriceTXT.Text);
                _vm.AddProductDetails(productNameTXT.Text, priceAsDouble, productPlaceTXT.Text, _userName);
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("אנא הזן רק ספרות למחיר המוצר", "הזנת מחיר שגויה");
            }
            
        }

        /// <summary>
        /// Description of property changed as a result of adding a new product
        /// </summary>
        /// <param name="e">Result have been changed</param>
        private void _vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Result")
            {
                System.Windows.MessageBox.Show(_vm.getResult(), "פרטי אישור הזנת מוצר");
            }
            if (e.PropertyName == "ProductExsit")
            {
                _productExsist = _vm.isProductExsist();
            }
            if (e.PropertyName == "SuperExsit")
            {
                _superExsist = _vm.isSuperExsist();
            }
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
