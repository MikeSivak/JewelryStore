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
    /// Interaction logic for Cashier.xaml
    /// </summary>
    public partial class Cashier : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable ordersTable;
        System.Diagnostics.Stopwatch sw;

        public int userId;
        public Cashier()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            sw = new System.Diagnostics.Stopwatch();
            sw.Start();
        }

        private void updateOrders(object sender, MouseButtonEventArgs e)
        {
            ordersList.ItemsSource = null;
            ordersTable = new DataTable();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllOrders", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    ordersTable.Load(reader);

                    ordersList.AutoGenerateColumns = true;
                    ordersList.ItemsSource = ordersTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();

            }
        }

        private void cashierOpenWindow(object sender, RoutedEventArgs e)
        {
            ordersTable = new DataTable();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllOrders", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    ordersTable.Load(reader);

                    ordersList.AutoGenerateColumns = true;
                    ordersList.ItemsSource = ordersTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();

            }
        }

        private void closedCashierWindow(object sender, EventArgs e)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("addWorkTime", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter idUserParam = new SqlParameter
                    {
                        ParameterName = "@idUser",
                        Value = userId
                    };
                    sqlCmd.Parameters.Add(idUserParam);

                    SqlParameter timeParam = new SqlParameter
                    {
                        ParameterName = "@time",
                        Value = (int)(sw.ElapsedMilliseconds / 100)
                    };
                    sqlCmd.Parameters.Add(timeParam);

                    sqlCmd.ExecuteNonQuery();
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConn.Close();
            }
        }

        private void sendOrderClick(object sender, RoutedEventArgs e)
        {
            CheckoutOrder checkoutOrder = new CheckoutOrder();
            checkoutOrder.Show();
        }

        private void showCashierProfile(object sender, RoutedEventArgs e)
        {
            cashierManagementGrid.Visibility = Visibility.Hidden;
            cashierInfoGrid.Visibility = Visibility.Visible;

            updateCashierInfo();
        }

        public void updateCashierInfo()
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("InfoUser", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter idUserParam = new SqlParameter
                    {
                        ParameterName = "@idUser",
                        Value = userId
                    };
                    sqlCmd.Parameters.Add(idUserParam);

                    SqlParameter emailParam = new SqlParameter
                    {
                        ParameterName = "@email",
                        SqlDbType = SqlDbType.NVarChar // тип параметра
                    };
                    emailParam.Direction = ParameterDirection.Output;
                    sqlCmd.Parameters.Add(emailParam);
                    emailParam.Size = 50;

                    SqlParameter passwordParam = new SqlParameter
                    {
                        ParameterName = "@password",
                        SqlDbType = SqlDbType.NVarChar // тип параметра
                    };
                    passwordParam.Direction = ParameterDirection.Output;
                    sqlCmd.Parameters.Add(passwordParam);
                    passwordParam.Size = 50;

                    SqlParameter firstNameParam = new SqlParameter
                    {
                        ParameterName = "@first_name",
                        SqlDbType = SqlDbType.NVarChar // тип параметра
                    };
                    firstNameParam.Direction = ParameterDirection.Output;
                    sqlCmd.Parameters.Add(firstNameParam);
                    firstNameParam.Size = 50;

                    SqlParameter lastNameParam = new SqlParameter
                    {
                        ParameterName = "@last_name",
                        SqlDbType = SqlDbType.NVarChar // тип параметра
                    };
                    lastNameParam.Direction = ParameterDirection.Output;
                    sqlCmd.Parameters.Add(lastNameParam);
                    lastNameParam.Size = 50;

                    SqlParameter phoneParam = new SqlParameter
                    {
                        ParameterName = "@phone_number",
                        SqlDbType = SqlDbType.Int // тип параметра
                    };
                    phoneParam.Direction = ParameterDirection.Output;
                    sqlCmd.Parameters.Add(phoneParam);
                    phoneParam.Size = 20;

                    sqlCmd.ExecuteNonQuery();

                    emailBox.Text = sqlCmd.Parameters["@email"].Value.ToString();
                    passwordBox.Text = sqlCmd.Parameters["@password"].Value.ToString();
                    firstNameBox.Text = sqlCmd.Parameters["@first_name"].Value.ToString();
                    lastNameBox.Text = sqlCmd.Parameters["@last_name"].Value.ToString();
                    phoneNumberBox.Text = sqlCmd.Parameters["@phone_number"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void backClick(object sender, RoutedEventArgs e)
        {
            cashierInfoGrid.Visibility = Visibility.Hidden;
            cashierManagementGrid.Visibility = Visibility.Visible;
        }

        private void saveClick(object sender, RoutedEventArgs e)
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
                            var sqlCmd = new SqlCommand("updateUser", sqlConn);
                            sqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter idUserParam = new SqlParameter
                            {
                                ParameterName = "@idUser",
                                Value = userId
                            };
                            sqlCmd.Parameters.Add(idUserParam);

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

                            SqlParameter phoneParam = new SqlParameter
                            {
                                ParameterName = "@phone_number",
                                Value = phoneNumber
                            };
                            sqlCmd.Parameters.Add(phoneParam);

                            sqlCmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    MessageBox.Show("Data saved successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("You can enter only number\nPlease, enter phone number again", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            updateCashierInfo();
        }
    }
}
