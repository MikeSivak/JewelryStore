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
    /// Interaction logic for AddType.xaml
    /// </summary>
    public partial class AddType : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public AddType()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void addTypeClick(object sender, RoutedEventArgs e)
        {
            string typeName = addTypeBox.Text;
            if (typeName == "")
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
                        var sqlCmd = new SqlCommand("addType", sqlConn);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter typeParameter = new SqlParameter
                        {
                            ParameterName = "@nameType",
                            Value = typeName
                        };
                        sqlCmd.Parameters.Add(typeParameter);

                        sqlCmd.ExecuteNonQuery();

                        MessageBox.Show("Type added successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
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
