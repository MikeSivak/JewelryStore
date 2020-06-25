using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace JewerlyStore
{
    /// <summary>
    /// Interaction logic for DeleteProduct.xaml
    /// </summary>
    public partial class DeleteProduct : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public DeleteProduct()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void delProductClick(object sender, RoutedEventArgs e)
        {
            string idProductString = delProductBox.Text;

            if (idProductString == "")
            {
                MessageBox.Show("Fill in all the fields", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int idProduct;
                bool isNum = int.TryParse(idProductString, out idProduct);

                if(isNum)
                {
                    idProduct = int.Parse(idProductString);
                    using (var sqlConn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            sqlConn.Open();
                            var sqlCmd = new SqlCommand("deleteProduct", sqlConn);
                            sqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter idProductParam = new SqlParameter
                            {
                                ParameterName = "@idProduct",
                                Value = idProduct
                            };
                            sqlCmd.Parameters.Add(idProductParam);
                            sqlCmd.ExecuteNonQuery();

                            MessageBox.Show("Product deleted successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You can enter only number\nPlease, enter product id again", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
               
            }
            
        }
    }
}
