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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JewerlyStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        int roleId;
        int userId;
        HelloWindow helloWindow;
        public MainWindow()
        {
            helloWindow = new HelloWindow();
            helloWindow.Show();
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void getRegLink(object sender, MouseEventArgs e)
        {
            registration.Foreground = new SolidColorBrush(Colors.Purple);
        }

        private void lostRegLink(object sender, MouseEventArgs e)
        {
            registration.Foreground = new SolidColorBrush(Color.FromRgb(24, 214, 197));
        }

        private void clickRegLink(object sender, RoutedEventArgs e)
        {
            UsersRegistration usersRegistration = new UsersRegistration();
            usersRegistration.Show();
        }

        private void signInClick(object sender, RoutedEventArgs e)
        {
            string email = emailBox.Text;
            string password = passwordBox.Password;

            if (email == "" || password == "")
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
                        var sqlCmd = new SqlCommand("getIdRole", sqlConn);
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

                        SqlParameter idRoleParam = new SqlParameter
                        {
                            ParameterName = "@idRole",
                            SqlDbType = SqlDbType.Int // тип параметра
                        };
                        idRoleParam.Direction = ParameterDirection.Output;
                        sqlCmd.Parameters.Add(idRoleParam);
                        idRoleParam.Size = 20;

                        sqlCmd.ExecuteNonQuery();

                        roleId = int.Parse(sqlCmd.Parameters["@idRole"].Value.ToString());
                        //MessageBox.Show(roleId.ToString());
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Incorrect login or password :(", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }

                using (var sqlConn = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConn.Open();
                        var sqlCmd = new SqlCommand("getIdUser", sqlConn);
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

                        SqlParameter idUserParam = new SqlParameter
                        {
                            ParameterName = "@idUser",
                            SqlDbType = SqlDbType.Int // тип параметра
                        };
                        idUserParam.Direction = ParameterDirection.Output;
                        sqlCmd.Parameters.Add(idUserParam);
                        idUserParam.Size = 20;

                        sqlCmd.ExecuteNonQuery();

                        userId = int.Parse(sqlCmd.Parameters["@idUser"].Value.ToString());
                        //MessageBox.Show(roleId.ToString());

                        switch (roleId)
                        {
                            case 1:
                                Admin admin = new Admin();
                                admin.Show();
                                admin.userId = userId;
                                break;
                            case 2:
                                Cashier cashier = new Cashier();
                                cashier.Show();
                                cashier.userId = userId;
                                break;
                            case 3:
                                Client client = new Client();
                                client.Show();
                                client.userId = userId;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Incorrect login or password :(", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }

            
        }

        private void closeLogin(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeHelloWindow(object sender, MouseEventArgs e)
        {
            helloWindow.Close();
        }
    }
}
