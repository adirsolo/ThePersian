using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePerisan.Model;

namespace ThePerisan.ViewModel
{
    /// <summary>
    /// The class of the ViewModel by the MVVM architecture
    /// </summary>
    class OurViewModel : INotifyPropertyChanged
    {
        IModel _model;

        string _result;
        public string Result
        {
            set
            {
                _result = value;
                NotifyPropertyChanged("Result");
            }
            get
            {
                return _result;
            }
        }

        DataTable _dt;
        public DataTable DT
        {
            set
            {
                _dt = value;
                NotifyPropertyChanged("DataTable");
            }
            get
            {
                return _dt;
            }
        }

        bool _flagUserExsit;
        public bool FlagUserExsit
        {
            set
            {
                _flagUserExsit = value;
                NotifyPropertyChanged("UserExsit");
            }
            get
            {
                return _flagUserExsit;
            }
        }

        bool _productExsit;
        public bool ProductExsit
        {
            set
            {
                _productExsit = value;
                NotifyPropertyChanged("ProductExsit");
            }
            get
            {
                return _productExsit;
            }
        }

        bool _superExsit;
        public bool SuperExsit
        {
            set
            {
                _superExsit = value;
                NotifyPropertyChanged("SuperExsit");
            }
            get
            {
                return _superExsit;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The consturctor of the ViewModel
        /// </summary>
        /// <param name="model">getting an interface of the model</param>
        public OurViewModel(IModel model)
        {
            _model = model;
            _model.PropertyChanged += model_PropertyChanged;
        }

        /// <summary>
        /// Represents if one of the propertys have been changed
        /// </summary>
        /// <param name="e">checking wich one of the property have been change and update the information</param>
        private void model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Result")
                Result = _model.getResult();
            if (e.PropertyName == "DataTable")
                DT = _model.getDataTable();
            if (e.PropertyName == "UserExsit")
                FlagUserExsit = _model.getUserExsit();
            if (e.PropertyName == "ProductExsit")
                ProductExsit = _model.getProductExsit();
            if (e.PropertyName == "SuperExsit")
                SuperExsit = _model.getSuperExsit();
        }

        /// <summary>
        /// Notify if one of the property have been changed
        /// </summary>
        /// <param name="propName">the name of the property that have been changed</param>
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        /// <summary>
        /// Moving the model a command to add a new product
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="place"></param>
        /// <param name="userName"></param>
        public void AddProductDetails(string name, double price, string place, string userName)
        {
            _model.AddProudctToDB(name, price, place, userName);
        }

        /// <summary>
        /// Moving the model a command to search for a new product
        /// </summary>
        /// <param name="nameOfProdcut"></param>
        public void SearchAproduct(string nameOfProdcut)
        {
            _model.SearchProductInDB(nameOfProdcut);
        }

        /// <summary>
        /// Moving the model a command to make sure the user is exsit and "loyal"
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void checkIfUserOK(string Name, string Pass)
        {
            _model.IsUserExist(Name, Pass);
        }

        /// <summary>
        /// getter from outer class of the result
        /// </summary>
        /// <returns>string of a adding product detalys result</returns>
        public string getResult()
        {
            return Result;
        }

        /// <summary>
        /// getter from outer class of the DataTable
        /// </summary>
        /// <returns>information of a product from the model database</returns>
        public DataTable getDataTable()
        {
            return DT;
        }


        public bool isUserExsist()
        {
            return _model.getUserExsit();
        }

        public bool isProductExsist()
        {
            return _model.getProductExsit();
        }

        public bool isSuperExsist()
        {
            return _model.getSuperExsit();
        }

    }
}
