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
    /// Interaction logic for AddCashier.xaml
    /// </summary>
    public partial class AddCashier : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public AddCashier()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void registerClick(object sender, RoutedEventArgs e)
        {
            string email = emailBox.Text;
            string password = passwordBox.Text;
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string phoneNumberString = phoneNumberBox.Text;
            
            if (email == "" || password == "" || firstName == "" || lastName == "" || phoneNumberString == "")
            {
                MessageBox.Show("Fill in all the fields", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int phoneNumber;
                bool isNum = int.TryParse(phoneNumberString, out phoneNumber);
                if (isNum)
                {
                    phoneNumber = int.Parse(phoneNumberString);
                    using (var sqlConn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            sqlConn.Open();
                            var sqlCmd = new SqlCommand("addCashier", sqlConn);
                            sqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter emailParam = new SqlParameter
                            {
                                ParameterName = "@email",
                                Value = email
                            };
                            sqlCmd.Parameters.Add(emailParam);

                            SqlParameter passwordParam = new SqlParameter
                            {
                                ParameterName = "@password",
                                Value = password
                            };
                            sqlCmd.Parameters.Add(passwordParam);

                            SqlParameter firstNameParam = new SqlParameter
                            {
                                ParameterName = "@first_name",
                                Value = firstName
                            };
                            sqlCmd.Parameters.Add(firstNameParam);

                            SqlParameter lastNameParam = new SqlParameter
                            {
                                ParameterName = "@last_name",
                                Value = lastName
                            };
                            sqlCmd.Parameters.Add(lastNameParam);

                            SqlParameter phoneNumberParam = new SqlParameter
                            {
                                ParameterName = "@phone_number",
                                Value = phoneNumber
                            };
                            sqlCmd.Parameters.Add(phoneNumberParam);

                            sqlCmd.ExecuteNonQuery();

                            MessageBox.Show("Cashier added successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
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
                else
                {
                    MessageBox.Show("You can enter only number\nPlease, enter phone number again", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
        }
    }
}
