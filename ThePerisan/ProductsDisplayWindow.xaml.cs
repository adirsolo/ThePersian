using System;
using System.Collections.Generic;
using System.Data;
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
    /// This class is represents the product and his information
    /// </summary>
    public partial class ProductsDisplayWindow : Window
    {
        string _userName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtToShow">the information of the product from the database</param>
        /// <param name="productName">the name of the product</param>
        /// <param name="userName">the current user name in the system</param>
        public ProductsDisplayWindow(DataTable dtToShow,string productName, string userName)
        {
            InitializeComponent();
            _userName = userName;
            headline.Text = "מציג מחירים ומקומות אפשריים עבור " + productName;
            foreach (DataRow dr in dtToShow.Rows)
               {
                   lst.Items.Add(dr["Price"].ToString() + "                          " + dr["Place"].ToString());
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

        /// <summary>
        /// click event that will make the compare search window to appear
        /// </summary>
        private void backToCompBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CompareProduct cp = new CompareProduct(_userName);
            cp.ShowDialog();
        }
    }
}
