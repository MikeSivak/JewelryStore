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
    /// Interaction logic for AddMaterial.xaml
    /// </summary>
    public partial class AddMaterial : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public AddMaterial()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void addMaterialClick(object sender, RoutedEventArgs e)
        {
            string materialName = materialBox.Text;
            if (materialName == "")
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
                        var sqlCmd = new SqlCommand("addMaterial", sqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter materialParameter = new SqlParameter
                        {
                            ParameterName = "@nameMaterial",
                            Value = materialName
                        };
                        sqlCmd.Parameters.Add(materialParameter);

                        sqlCmd.ExecuteNonQuery();

                        MessageBox.Show("Material added successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
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
