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
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable productsTable;
        int countryId;
        string manufacturerName;
        int materialId;
        int typeId;
        int manufacturerId;
        int productPrice;
        int priceProduct;
        int productId;

        public int userId;

        public Client()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void clientOpenWindow(object sender, RoutedEventArgs e)
        {
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

                    allProducts.AutoGenerateColumns = true;
                    allProducts.ItemsSource = productsTable.DefaultView;
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
            allProducts.ItemsSource = null;
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

                    allProducts.AutoGenerateColumns = true;
                    allProducts.ItemsSource = productsTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void selectCountry(object sender, EventArgs e)
        {
            countryBox.Items.Clear();
            countryBox.Items.Clear();
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
                            countryBox.Items.Add(countryName);
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

        private void selectManufacturer(object sender, EventArgs e)
        {
            
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getCountryId", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter nameCountry = new SqlParameter
                    {
                        ParameterName = "@nameCountry",
                        Value = countryBox.SelectedItem.ToString()
                    };
                    sqlCmd.Parameters.Add(nameCountry);

                    SqlParameter idCountry = new SqlParameter
                    {
                        ParameterName = "@idCountry",
                        SqlDbType = SqlDbType.Int // тип параметра
                    };
                    idCountry.Direction = ParameterDirection.Output;
                    sqlCmd.Parameters.Add(idCountry);
                    idCountry.Size = 20;

                    sqlCmd.ExecuteNonQuery();

                    countryId = int.Parse(sqlCmd.Parameters["@idCountry"].Value.ToString());
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Please, Select a country of manufacturer", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                sqlConn.Close();
            }

            using (var sqlConn = new SqlConnection(connectionString))
            {
                manufacturerBox.Items.Clear();
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getMnftrByCntryName", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter idCountry = new SqlParameter
                    {
                        ParameterName = "@idCountry",
                        Value = countryId
                    };
                    sqlCmd.Parameters.Add(idCountry);

                    SqlParameter nameManufacturer = new SqlParameter
                    {
                        ParameterName = "@nameManufacturer",
                        SqlDbType = SqlDbType.NVarChar // тип параметра
                    };
                    nameManufacturer.Direction = ParameterDirection.Output;
                    sqlCmd.Parameters.Add(nameManufacturer);
                    nameManufacturer.Size = 20;

                    sqlCmd.ExecuteNonQuery();

                    manufacturerName = sqlCmd.Parameters["@nameManufacturer"].Value.ToString();
                    manufacturerBox.Items.Add(manufacturerName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sqlConn.Close();
            }
        }

        private void selectType(object sender, EventArgs e)
        {
            typeBox.Items.Clear();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getTypes", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string typeName = reader.GetString(0);
                            typeBox.Items.Add(typeName);
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
        private void selectMaterial(object sender, EventArgs e)
        {
            materialBox.Items.Clear();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getMaterials", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string materialName = reader.GetString(0);
                            materialBox.Items.Add(materialName);
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

        private void changeTextBox(object sender, TextChangedEventArgs e)
        {
                using (var sqlConn = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConn.Open();
                        var sqlCmd = new SqlCommand("getMaterialId", sqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter nameMaterialParam = new SqlParameter
                        {
                            ParameterName = "@nameMaterial",
                            Value = materialBox.SelectedItem.ToString()
                        };
                        sqlCmd.Parameters.Add(nameMaterialParam);

                        SqlParameter idMaterialParam = new SqlParameter
                        {
                            ParameterName = "@idMaterial",
                            SqlDbType = SqlDbType.Int // тип параметра
                        };
                        idMaterialParam.Direction = ParameterDirection.Output;
                        sqlCmd.Parameters.Add(idMaterialParam);
                        idMaterialParam.Size = 20;

                        sqlCmd.ExecuteNonQuery();

                        materialId = int.Parse(sqlCmd.Parameters["@idMaterial"].Value.ToString());
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
                        var sqlCmd = new SqlCommand("getTypeId", sqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter nameTypeParam = new SqlParameter
                        {
                            ParameterName = "@nameType",
                            Value = typeBox.SelectedItem.ToString()
                        };
                        sqlCmd.Parameters.Add(nameTypeParam);

                        SqlParameter idTypeParam = new SqlParameter
                        {
                            ParameterName = "@idType",
                            SqlDbType = SqlDbType.Int // тип параметра
                        };
                        idTypeParam.Direction = ParameterDirection.Output;
                        sqlCmd.Parameters.Add(idTypeParam);
                        idTypeParam.Size = 20;

                        sqlCmd.ExecuteNonQuery();

                        typeId = int.Parse(sqlCmd.Parameters["@idType"].Value.ToString());
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
                        var sqlCmd = new SqlCommand("getManufacturerId", sqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter nameManufacturerParam = new SqlParameter
                        {
                            ParameterName = "@nameManufacturer",
                            Value = manufacturerName
                        };
                        sqlCmd.Parameters.Add(nameManufacturerParam);

                        SqlParameter idManufacturerParam = new SqlParameter
                        {
                            ParameterName = "@idManufacturer",
                            SqlDbType = SqlDbType.Int // тип параметра
                        };
                        idManufacturerParam.Direction = ParameterDirection.Output;
                        sqlCmd.Parameters.Add(idManufacturerParam);
                        idManufacturerParam.Size = 20;

                        sqlCmd.ExecuteNonQuery();

                        manufacturerId = int.Parse(sqlCmd.Parameters["@idManufacturer"].Value.ToString());
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
                        var sqlCmd = new SqlCommand("getProductPrice", sqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter IdMaterialParam = new SqlParameter
                        {
                            ParameterName = "@idMaterial",
                            Value = materialId
                        };
                        sqlCmd.Parameters.Add(IdMaterialParam);

                        SqlParameter IdTypeParam = new SqlParameter
                        {
                            ParameterName = "@idType",
                            Value = typeId
                        };
                        sqlCmd.Parameters.Add(IdTypeParam);

                        SqlParameter idManufacturerParam = new SqlParameter
                        {
                            ParameterName = "@idManufacturer",
                            Value = manufacturerId
                        };
                        sqlCmd.Parameters.Add(idManufacturerParam);

                        SqlParameter priceParam = new SqlParameter
                        {
                            ParameterName = "@productPrice",
                            SqlDbType = SqlDbType.Int // тип параметра
                        };
                        priceParam.Direction = ParameterDirection.Output;
                        sqlCmd.Parameters.Add(priceParam);
                        priceParam.Size = 20;

                        sqlCmd.ExecuteNonQuery();
                        productPrice = int.Parse(sqlCmd.Parameters["@productPrice"].Value.ToString());
                        //totalPriceBox.Text = productPrice.ToString();
                    }
                    catch (Exception ex)
                    {
                    MessageBox.Show("There is no product in the store with this description", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    //MessageBox.Show("Error of registration :(\nPlease, try to register again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                    sqlConn.Close();
                }
            try
            {
                totalPriceBox.Clear();
                string totalPriceString = quantityBox.Text;

                if (totalPriceString != "")
                {
                    int totalPrice;
                    bool isNum = int.TryParse(totalPriceString, out totalPrice);

                    if(isNum)
                    {
                        totalPrice = int.Parse(totalPriceString);
                        priceProduct = totalPrice * productPrice;
                        totalPriceBox.Text = priceProduct.ToString();
                    }
                    else
                    {
                        MessageBox.Show("You can enter only number\nPlease, enter product price again", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("There is no product in the store with this description", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
                
        }

        private void makeOrderClick(object sender, RoutedEventArgs e)
        {   
            if (countryBox.SelectedItem == null || manufacturerBox.SelectedItem == null || typeBox.SelectedItem == null || materialBox.SelectedItem == null || quantityBox.Text == "")
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
                        var sqlCmd = new SqlCommand("getIdProduct", sqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter IdMaterialParam = new SqlParameter
                        {
                            ParameterName = "@idMaterial",
                            Value = materialId
                        };
                        sqlCmd.Parameters.Add(IdMaterialParam);

                        SqlParameter IdTypeParam = new SqlParameter
                        {
                            ParameterName = "@idType",
                            Value = typeId
                        };
                        sqlCmd.Parameters.Add(IdTypeParam);

                        SqlParameter idManufacturerParam = new SqlParameter
                        {
                            ParameterName = "@idManufacturer",
                            Value = manufacturerId
                        };
                        sqlCmd.Parameters.Add(idManufacturerParam);

                        SqlParameter productPriceParam = new SqlParameter
                        {
                            ParameterName = "@productPrice",
                            Value = productPrice
                        };
                        sqlCmd.Parameters.Add(productPriceParam);

                        SqlParameter idProductParam = new SqlParameter
                        {
                            ParameterName = "@idProduct",
                            SqlDbType = SqlDbType.Int // тип параметра
                        };
                        idProductParam.Direction = ParameterDirection.Output;
                        sqlCmd.Parameters.Add(idProductParam);
                        idProductParam.Size = 20;

                        sqlCmd.ExecuteNonQuery();

                        productId = int.Parse(sqlCmd.Parameters["@idProduct"].Value.ToString());

                        //MessageBox.Show(productId.ToString());
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
                        var sqlCmd = new SqlCommand("addOrder", sqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter idUserParam = new SqlParameter
                        {
                            ParameterName = "@idUser",
                            Value = userId
                        };
                        sqlCmd.Parameters.Add(idUserParam);

                        SqlParameter idProductParam = new SqlParameter
                        {
                            ParameterName = "@idProduct",
                            Value = productId
                        };
                        sqlCmd.Parameters.Add(idProductParam);

                        SqlParameter orderDateParam = new SqlParameter
                        {
                            ParameterName = "@orderDate",
                            Value = DateTime.Now.ToShortDateString()
                        };
                        sqlCmd.Parameters.Add(orderDateParam);

                        SqlParameter totalPriceParam = new SqlParameter
                        {
                            ParameterName = "@totalPrice",
                            Value = priceProduct
                        };
                        sqlCmd.Parameters.Add(totalPriceParam);

                        sqlCmd.ExecuteNonQuery();

                        MessageBox.Show("Order added successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);   
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
                        var sqlCmd = new SqlCommand("addHistoryOrder", sqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter idUserParam = new SqlParameter
                        {
                            ParameterName = "@idUser",
                            Value = userId
                        };
                        sqlCmd.Parameters.Add(idUserParam);

                        SqlParameter idProductParam = new SqlParameter
                        {
                            ParameterName = "@idProduct",
                            Value = productId
                        };
                        sqlCmd.Parameters.Add(idProductParam);

                        SqlParameter orderDateParam = new SqlParameter
                        {
                            ParameterName = "@orderDate",
                            Value = DateTime.Now.ToShortDateString()
                        };
                        sqlCmd.Parameters.Add(orderDateParam);

                        SqlParameter totalPriceParam = new SqlParameter
                        {
                            ParameterName = "@totalPrice",
                            Value = priceProduct
                        };
                        sqlCmd.Parameters.Add(totalPriceParam);

                        sqlCmd.ExecuteNonQuery();

                        MessageBox.Show("Order saved in history table :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void showClientProfile(object sender, RoutedEventArgs e)
        {
            clientManagmentGrid.Visibility = Visibility.Hidden;
            clientInfoGrid.Visibility = Visibility.Visible;

            updateClientInfo();
        }

        public void updateClientInfo()
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

            updateClientInfo();
        }

        private void backClick(object sender, RoutedEventArgs e)
        {
            clientInfoGrid.Visibility = Visibility.Hidden;
            clientManagmentGrid.Visibility = Visibility.Visible;
        }
    }
}
