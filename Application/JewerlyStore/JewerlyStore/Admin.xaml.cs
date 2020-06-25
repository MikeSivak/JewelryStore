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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable usersTable;
        DataTable cashiersTable;
        DataTable clientsTable;
        DataTable productsTable;
        DataTable materialsTable;
        DataTable typesTable;
        DataTable countriesTable;
        DataTable manufacturersTable;
        DataTable workTimeTable;
        DataTable cashIncomeTable;
        DataTable orderHistoryTable;

        public int userId;

        public Admin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void addCountriesClick(object sender, RoutedEventArgs e)
        {
            AddCountry addCountry = new AddCountry();
            addCountry.Show();
        }

        private void addManufacturerClick(object sender, RoutedEventArgs e)
        {
            AddManufacturer addManufacturer = new AddManufacturer();
            addManufacturer.Show();
        }

        private void addProductClick(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
        }

        private void addMaterialClick(object sender, RoutedEventArgs e)
        {
            AddMaterial addMaterial = new AddMaterial();
            addMaterial.Show();
        }

        private void addTypeClick(object sender, RoutedEventArgs e)
        {
            AddType addType = new AddType();
            addType.Show();
        }

        private void addCashierClick(object sender, RoutedEventArgs e)
        {
            AddCashier addCashier = new AddCashier();
            addCashier.Show();
        }

        private void delCountryClick(object sender, RoutedEventArgs e)
        {
            DeleteCountry deleteCountry = new DeleteCountry();
            deleteCountry.Show();
        }

        private void delManufacturerClick(object sender, RoutedEventArgs e)
        {
            DeleteManufacturer deleteManufacturer = new DeleteManufacturer();
            deleteManufacturer.Show();
        }

        private void delProduct(object sender, RoutedEventArgs e)
        {
            DeleteProduct deleteProduct = new DeleteProduct();
            deleteProduct.Show();
        }

        private void delMaterial(object sender, RoutedEventArgs e)
        {
            DeleteMaterial deleteMaterial = new DeleteMaterial();
            deleteMaterial.Show();
        }

        private void delTypes(object sender, RoutedEventArgs e)
        {
            DeleteType deleteType = new DeleteType();
            deleteType.Show();
        }

        private void delCashier(object sender, RoutedEventArgs e)
        {
            DeleteCashier deleteCashier = new DeleteCashier();
            deleteCashier.Show();
        }

        private void delClient(object sender, RoutedEventArgs e)
        {
            DeleteClient deleteClient = new DeleteClient();
            deleteClient.Show();
        }

        private void adminOpenWindow(object sender, RoutedEventArgs e)
        {
            usersTable = new DataTable();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllUsers", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    usersTable.Load(reader);

                    allUsers.AutoGenerateColumns = true;
                    allUsers.ItemsSource = usersTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }

            workTimeTable = new DataTable();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getWorkTime", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    workTimeTable.Load(reader);

                    workTime.AutoGenerateColumns = true;
                    workTime.ItemsSource = workTimeTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }

            using (var sqlConn = new SqlConnection(connectionString))
            {
                cashiersTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getCashiers", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    cashiersTable.Load(reader);

                    cashiers.AutoGenerateColumns = true;
                    cashiers.ItemsSource = cashiersTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }

            using (var sqlConn = new SqlConnection(connectionString))
            {
                clientsTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getClients", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();
                    
                    clientsTable.Load(reader);

                    clients.AutoGenerateColumns = true;
                    clients.ItemsSource = clientsTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }

            using (var sqlConn = new SqlConnection(connectionString))
            {
                productsTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getProducts", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    productsTable.Load(reader);

                    products.AutoGenerateColumns = true;
                    products.ItemsSource = productsTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }

            using (var sqlConn = new SqlConnection(connectionString))
            {
                materialsTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllMaterials", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    materialsTable.Load(reader);

                    materials.AutoGenerateColumns = true;
                    materials.ItemsSource = materialsTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }

            using (var sqlConn = new SqlConnection(connectionString))
            {
                typesTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllTypes", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    typesTable.Load(reader);

                    types.AutoGenerateColumns = true;
                    types.ItemsSource = typesTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }

            using (var sqlConn = new SqlConnection(connectionString))
            {
                countriesTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllCountries", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    countriesTable.Load(reader);

                    countries.AutoGenerateColumns = true;
                    countries.ItemsSource = countriesTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }

            using (var sqlConn = new SqlConnection(connectionString))
            {
                manufacturersTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllManufacturers", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    manufacturersTable.Load(reader);

                    manufacturers.AutoGenerateColumns = true;
                    manufacturers.ItemsSource = manufacturersTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }

            using (var sqlConn = new SqlConnection(connectionString))
            {
                workTimeTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getWorkTime", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    workTimeTable.Load(reader);

                    workTime.AutoGenerateColumns = true;
                    workTime.ItemsSource = workTimeTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void updateAllUsers(object sender, MouseButtonEventArgs e)
        {
            allUsers.ItemsSource = null;
            usersTable = new DataTable();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllUsers", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    usersTable.Load(reader);

                    allUsers.AutoGenerateColumns = true;
                    allUsers.ItemsSource = usersTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void updateCashiers(object sender, MouseButtonEventArgs e)
        {
            cashiers.ItemsSource = null;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                cashiersTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getCashiers", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    cashiersTable.Load(reader);

                    cashiers.AutoGenerateColumns = true;
                    cashiers.ItemsSource = cashiersTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void updateClients(object sender, MouseButtonEventArgs e)
        {
            clients.ItemsSource = null;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                clientsTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getClients", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    clientsTable.Load(reader);

                    clients.AutoGenerateColumns = true;
                    clients.ItemsSource = clientsTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void updateProducts(object sender, MouseButtonEventArgs e)
        {
            products.ItemsSource = null;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                productsTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getProducts", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    productsTable.Load(reader);

                    products.AutoGenerateColumns = true;
                    products.ItemsSource = productsTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void updateMaterials(object sender, MouseButtonEventArgs e)
        {
            materials.ItemsSource = null;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                materialsTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllMaterials", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    materialsTable.Load(reader);

                    materials.AutoGenerateColumns = true;
                    materials.ItemsSource = materialsTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void updateTypes(object sender, MouseButtonEventArgs e)
        {
            types.ItemsSource = null;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                typesTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllTypes", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    typesTable.Load(reader);

                    types.AutoGenerateColumns = true;
                    types.ItemsSource = typesTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void updateCountries(object sender, MouseButtonEventArgs e)
        {
            countries.ItemsSource = null;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                countriesTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllCountries", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    countriesTable.Load(reader);

                    countries.AutoGenerateColumns = true;
                    countries.ItemsSource = countriesTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void updateManufacturers(object sender, MouseButtonEventArgs e)
        {
            manufacturers.ItemsSource = null;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                manufacturersTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getAllManufacturers", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    manufacturersTable.Load(reader);

                    manufacturers.AutoGenerateColumns = true;
                    manufacturers.ItemsSource = manufacturersTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void updateWorkTime(object sender, MouseButtonEventArgs e)
        {
            workTime.ItemsSource = null;
            using (var sqlConn = new SqlConnection(connectionString))
            {
                workTimeTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getWorkTime", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    workTimeTable.Load(reader);

                    workTime.AutoGenerateColumns = true;
                    workTime.ItemsSource = workTimeTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void updateCashIncome(object sender, MouseButtonEventArgs e)
        {
            int money = 0;
            cashIncome.Clear();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                cashIncomeTable = new DataTable();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getMoney", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            money += reader.GetInt32(0);
                        }
                    }
                    reader.Close();

                    /*workTimeTable.Load(reader);

                    workTime.AutoGenerateColumns = true;
                    workTime.ItemsSource = workTimeTable.DefaultView;*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
            cashIncome.Text = money.ToString() + "$";
        }

        private void updateHistory(object sender, MouseButtonEventArgs e)
        {
            orderHistory.ItemsSource = null;
            orderHistoryTable = new DataTable();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getHistoryOrders", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    orderHistoryTable.Load(reader);

                    orderHistory.AutoGenerateColumns = true;
                    orderHistory.ItemsSource = orderHistoryTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void showAdminInfo(object sender, RoutedEventArgs e)
        {
            managementGrid.Visibility = Visibility.Hidden;
            adminInfoGrid.Visibility = Visibility.Visible;

            updateAdminInfo();
        }

        public void updateAdminInfo()
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
            adminInfoGrid.Visibility = Visibility.Hidden;
            managementGrid.Visibility = Visibility.Visible;
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
                        catch(Exception ex)
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

            updateAdminInfo();
        }
    }
}
