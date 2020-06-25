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
    /// Interaction logic for DeleteManufacturer.xaml
    /// </summary>
    public partial class DeleteManufacturer : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public DeleteManufacturer()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void selectManufacturers(object sender, EventArgs e)
        {
            delManufacturerBox.Items.Clear();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getManufacturers", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string manufacturerName = reader.GetString(0);
                            delManufacturerBox.Items.Add(manufacturerName);
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void delManufacturerClick(object sender, RoutedEventArgs e)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("deleteManufacturer", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter manufacturerParameter = new SqlParameter
                    {
                        ParameterName = "@nameManufacturer",
                        Value = delManufacturerBox.SelectedItem.ToString()
                    };
                    sqlCmd.Parameters.Add(manufacturerParameter);
                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("Manufacturer deleted successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
