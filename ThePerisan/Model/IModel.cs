using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePerisan.Model
{
    interface IModel : INotifyPropertyChanged
    {
        /// <summary>
        /// adding a new product to the database
        /// </summary>
        /// <param name="name">name of the product</param>
        /// <param name="price">price of the product</param>
        /// <param name="place">place of the product sales</param>
        /// <param name="userName">the user name that want to add the new product</param>
        void AddProudctToDB(string name, double price, string place, string userName);

        /// <summary>
        /// searching for a product in the database
        /// </summary>
        /// <param name="name">name of the product for searching</param>
        void SearchProductInDB(string name);

        /// <summary>
        /// the result of the proccess of adding a new product
        /// </summary>
        /// <returns>string represents the result</returns>
        string getResult();

        /// <summary>
        /// checking if the user exsist in the system
        /// </summary>
        /// <param name="Name">the user name</param>
        /// <param name="Pass">the user password</param>
        /// <returns>bool represents if the user can continue with his proccess</returns>
        void IsUserExist(string Name, string Pass);

        /// <summary>
        /// Getting the result if the the user exsist
        /// </summary>
        /// <returns>bool, true if exsist</returns>
        bool getUserExsit();

        /// <summary>
        /// Getting the result if the product is exsist
        /// </summary>
        /// <returns>true if the product exsist</returns>
        bool getProductExsit();

        /// <summary>
        /// Getting the super if the product is exsist
        /// </summary>
        /// <returns>true if the super exsist</returns>
        bool getSuperExsit();

        /// <summary>
        /// information of the product from the data base
        /// </summary>
        /// <returns>datatable from the the database</returns>
        DataTable getDataTable();
    }
}
