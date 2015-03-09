using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ThePerisan.Model
{
    class ModelPractical : IModel
    {
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private DataTable ExecuteDataTable(string query)
        {
            SqlConnection con = new SqlConnection(global::ThePerisan.Properties.Settings.Default.CenteralDatabaseConnectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                command.ExecuteNonQuery();
                SqlDataAdapter tableAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                tableAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// To Execute update / insert / delete queries
        /// </summary>
        /// <param name="query">the query string</param>
        private void ExecuteNonQuery(string query)
        {
            //SqlConnection con = new SqlConnection(@"data source=(LocalDB)\v11.0;attachdbfilename=|DataDirectory|\CentralDatabase.mdf;integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework");
            SqlConnection con = new SqlConnection(global::ThePerisan.Properties.Settings.Default.CenteralDatabaseConnectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// To Execute queries which return scalar value
        /// </summary>
        /// <param name="query">the query string</param>
        private object ExecuteScalar(string query)
        {
            SqlConnection con = new SqlConnection(global::ThePerisan.Properties.Settings.Default.CenteralDatabaseConnectionString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddProudctToDB(string name, double price, string place, string userName)
        {
            try
            {
                if (IsUserAllow(userName))
                {
                    if (IsProductExist(name))
                    {
                        if (IsshopExist(place))
                        {
                            string query = "";
                            if (IsProductsExist(name, place))
                                query = "UPDATE Products SET Price='" + price + "' WHERE Name=N'" + name + "' AND Place=N'" + place + "'";
                            else
                                query = "INSERT INTO Products (Name,Price,Place) values(N'" + name + "','" + price + "',N'" + place + "')";
                            ExecuteNonQuery(query);
                            Result = "תודה שהזנת מוצר";
                        }
                        else
                        {
                            Result = "הסופר לא קיים במאגר ";
                        }
                    }
                    else
                        Result = "המוצר לא קיים במאגר ";
                }
                else
                {
                    Result = "הינך לא מורשה להזין מחירים ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean IsUserAllow(string Name)
        {
            try
            {
                string query = "Select * from Users where UserName=N'" + Name + "'";
                DT = ExecuteDataTable(query);
                foreach (DataRow dr in DT.Rows)
                {
                    if (float.Parse(dr["Reliable"].ToString()) < 2)
                        return false;
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void GetAllProducts()
        {
            try
            {
                string query = "Select * from Products";
                DT = ExecuteDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SearchProductInDB(string ProductName)
        {
            try
            {
                string query = "Select * from Products where Name=N'" + ProductName + "' ORDER BY Price";
                DT = ExecuteDataTable(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool IsProductsExist(string ProductName, string ProductPlace)
        {
            bool ans = false;
            try
            {
                string query = "Select count(*) from Products where Name=N'" + ProductName + "' AND Place=N'" + ProductPlace + "'";
                int result = Convert.ToInt16(ExecuteScalar(query));
                if (result > 0)
                    ans = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return ans;
        }

        public bool IsProductExist(string ProductName)
        {
            bool ans = false;
            try
            {
                string query = "Select count(*) from Product where Name=N'" + ProductName + "'";
                int result = Convert.ToInt16(ExecuteScalar(query));
                if (result > 0)
                    ans = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return ans;
        }

        public bool IsshopExist(string shopName)
        {
            bool ans = false;
            try
            {
                string query = "Select count(*) from ShoppingPlaces where Name=N'" + shopName + "'";
                int result = Convert.ToInt16(ExecuteScalar(query));
                if (result > 0)
                    ans = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return ans;
        }

        public void IsUserExist(string Name, string Pass)
        {
            try
            {
                string query = "Select count(*) from Users where UserName=N'" + Name + "' AND Password=N'" + Pass + "'";
                int result = Convert.ToInt16(ExecuteScalar(query));
                if (result > 0)
                    FlagUserExsit = true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteAllProducts()
        {
            try
            {
                string query = "Delete * From Products";
                ExecuteNonQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteProduct(string ProductName)
        {
            try
            {
                string query = "Delete from Products where Name=N" + ProductName + "'";
                ExecuteNonQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string getResult()
        {
            return Result;
        }

        public DataTable getDataTable()
        {
            return DT;
        }

        public bool getUserExsit()
        {
            return FlagUserExsit;
        }

        public bool getProductExsit()
        {
            return ProductExsit;
        }

        public bool getSuperExsit()
        {
            return SuperExsit;
        }
    }
}