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
    /// Interaction logic for DeleteType.xaml
    /// </summary>
    public partial class DeleteType : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public DeleteType()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void delTypeClick(object sender, RoutedEventArgs e)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("deleteType", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter typeParameter = new SqlParameter
                    {
                        ParameterName = "@nameType",
                        Value = delTypeBox.SelectedItem.ToString()
                    };
                    sqlCmd.Parameters.Add(typeParameter);
                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("Type deleted successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void selectTypes(object sender, EventArgs e)
        {
            delTypeBox.Items.Clear();
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
                            delTypeBox.Items.Add(typeName);
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
