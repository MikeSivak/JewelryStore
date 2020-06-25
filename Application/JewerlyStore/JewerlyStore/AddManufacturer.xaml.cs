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
    /// Interaction logic for AddManufacturer.xaml
    /// </summary>
    public partial class AddManufacturer : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        int countryId;
        public AddManufacturer()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void selectCountries(object sender, EventArgs e)
        {
            selectCountry.Items.Clear();
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
                            selectCountry.Items.Add(countryName);
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

        private void addManufacturerClick(object sender, RoutedEventArgs e)
        {
            string countryName = selectCountry.SelectedItem.ToString();
            string manufacturerName = manufacturerBox.Text;
            if (countryName == "" || manufacturerName == "")
            {
                MessageBox.Show("Fill in all the fields", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                using (var sqlConn = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConn.Open();
                        var sqlCmd = new SqlCommand("getCountryId", sqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter countryParameter = new SqlParameter
                        {
                            ParameterName = "@nameCountry",
                            Value = countryName
                        };
                        sqlCmd.Parameters.Add(countryParameter);

                        SqlParameter idParam = new SqlParameter
                        {
                            ParameterName = "@idCountry",
                            SqlDbType = SqlDbType.Int // тип параметра
                        };
                        idParam.Direction = ParameterDirection.Output;
                        sqlCmd.Parameters.Add(idParam);
                        idParam.Size = 20;

                        sqlCmd.ExecuteNonQuery();

                        countryId = int.Parse(sqlCmd.Parameters["@idCountry"].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        //MessageBox.Show("Error of registration :(\nPlease, try to register again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    sqlConn.Close();
                }

                using (var sqlConn = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConn.Open();
                        var sqlCmd = new SqlCommand("addManufacturer", sqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter manufacturerParameter = new SqlParameter
                        {
                            ParameterName = "@nameManufacturer",
                            Value = manufacturerName
                        };
                        sqlCmd.Parameters.Add(manufacturerParameter);

                        SqlParameter idCountryParameter = new SqlParameter
                        {
                            ParameterName = "@idCountry",
                            Value = countryId
                        };
                        sqlCmd.Parameters.Add(idCountryParameter);

                        sqlCmd.ExecuteNonQuery();

                        MessageBox.Show("Manufacturer added successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        //MessageBox.Show("Error of registration :(\nPlease, try to register again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    sqlConn.Close();
                }


            }
        }
    }
}
