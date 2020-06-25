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
    /// Interaction logic for CheckoutOrder.xaml
    /// </summary>
    public partial class CheckoutOrder : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public CheckoutOrder()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void chkOrderClick(object sender, RoutedEventArgs e)
        {
            string idOrderString = chkOrderBox.Text;
            if (idOrderString == "")
            {
                MessageBox.Show("Fill in all the fields", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int idOrder;
                bool isNum = int.TryParse(idOrderString, out idOrder);

                if(isNum)
                {
                    idOrder = int.Parse(idOrderString);
                    using (var sqlConn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            sqlConn.Open();
                            var sqlCmd = new SqlCommand("deleteOrder", sqlConn);
                            sqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter idOrderParam = new SqlParameter
                            {
                                ParameterName = "@idOrder",
                                Value = idOrder
                            };
                            sqlCmd.Parameters.Add(idOrderParam);
                            sqlCmd.ExecuteNonQuery();

                            MessageBox.Show("Order sent successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    MessageBox.Show("You can enter only number\nPlease, enter order id again", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            
        }
    }
}
