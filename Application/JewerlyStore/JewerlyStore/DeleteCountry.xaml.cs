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
    /// Interaction logic for DeleteCountry.xaml
    /// </summary>
    public partial class DeleteCountry : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public DeleteCountry()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void delCountryClick(object sender, RoutedEventArgs e)
        {
            using(var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("deleteCountry", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter nameCountry = new SqlParameter
                    {
                        ParameterName = "@nameCountry",
                        Value = delCountryBox.SelectedItem.ToString()
                    };
                    sqlCmd.Parameters.Add(nameCountry);
                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("Country deleted successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void selectCountries(object sender, EventArgs e)
        {
            delCountryBox.Items.Clear();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getCountries", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string countryName = reader.GetString(0);
                            delCountryBox.Items.Add(countryName);
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
    }
}
