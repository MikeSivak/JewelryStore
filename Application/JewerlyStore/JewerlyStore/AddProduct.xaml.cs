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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        int manufacturerId;
        int typeId;
        int materialId;
        public AddProduct()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void selectManufacturer(object sender, EventArgs e)
        {
            manufacturerBox.Items.Clear();
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
                            manufacturerBox.Items.Add(manufacturerName);
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

        private void addProductClick(object sender, RoutedEventArgs e)
        {
            string manufacturerName = manufacturerBox.Text;
            string typeName = typeBox.Text;
            string materialName = materialBox.Text;
            string productPriceString = priceBox.Text;
            string productQuantityString = quantityBox.Text;
            
            if (manufacturerName == "" || typeName == "" || materialName == "" || productPriceString == "" || productQuantityString == "")
            {
                MessageBox.Show("Fill in all the fields", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int productPrice;
                int productQuantity;
                bool isNum1 = int.TryParse(productPriceString, out productPrice);
                bool isNum2 = int.TryParse(productQuantityString, out productQuantity);

                if(isNum1 && isNum2)
                {
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
                            var sqlCmd = new SqlCommand("getTypeId", sqlConn);
                            sqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter nameTypeParam = new SqlParameter
                            {
                                ParameterName = "@nameType",
                                Value = typeName
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
                            var sqlCmd = new SqlCommand("getMaterialId", sqlConn);
                            sqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter nameMaterialParam = new SqlParameter
                            {
                                ParameterName = "@nameMaterial",
                                Value = materialName
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

                    //----------------------------------------------------------------------------------------------------------------

                    using (var sqlConn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            sqlConn.Open();
                            var sqlCmd = new SqlCommand("addProduct", sqlConn);
                            sqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter priceParam = new SqlParameter
                            {
                                ParameterName = "@productPrice",
                                Value = productPrice
                            };
                            sqlCmd.Parameters.Add(priceParam);

                            SqlParameter quantityParam = new SqlParameter
                            {
                                ParameterName = "@productQuantity",
                                Value = productQuantity
                            };
                            sqlCmd.Parameters.Add(quantityParam);

                            SqlParameter manufacturerParam = new SqlParameter
                            {
                                ParameterName = "@idManufacturer",
                                Value = manufacturerId
                            };
                            sqlCmd.Parameters.Add(manufacturerParam);

                            SqlParameter typeParam = new SqlParameter
                            {
                                ParameterName = "@idType",
                                Value = typeId
                            };
                            sqlCmd.Parameters.Add(typeParam);

                            SqlParameter materialParam = new SqlParameter
                            {
                                ParameterName = "@idMaterial",
                                Value = materialId
                            };
                            sqlCmd.Parameters.Add(materialParam);

                            sqlCmd.ExecuteNonQuery();

                            MessageBox.Show("Product added successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    MessageBox.Show("You can enter only number\nPlease, enter product price and quantity again", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
