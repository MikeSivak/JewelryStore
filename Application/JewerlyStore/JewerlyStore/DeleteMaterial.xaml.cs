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
    /// Interaction logic for DeleteMaterial.xaml
    /// </summary>
    public partial class DeleteMaterial : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public DeleteMaterial()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void selectMaterial(object sender, EventArgs e)
        {
            delMaterialBox.Items.Clear();
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
                            delMaterialBox.Items.Add(materialName);
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

        private void delMaterialClick(object sender, RoutedEventArgs e)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("deleteMaterial", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter materialParameter = new SqlParameter
                    {
                        ParameterName = "@nameMaterial",
                        Value = delMaterialBox.SelectedItem.ToString()
                    };
                    sqlCmd.Parameters.Add(materialParameter);
                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("Material deleted successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
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
