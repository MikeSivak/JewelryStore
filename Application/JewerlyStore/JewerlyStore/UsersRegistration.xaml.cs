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
    /// Interaction logic for UsersRegistration.xaml
    /// </summary>
    public partial class UsersRegistration : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public UsersRegistration()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void regButtonClick(object sender, RoutedEventArgs e)
        {
            //---------------------------------- Read a data from fields of UserRegistration form ---------------------------------------
            string email = emailBox.Text;
            string password = passwordBox.Text;
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string phoneNumberString = phoneNumberBox.Text;
            //---------------------------------- Check a data on emptiness and сorrectness -------------------------------------------------------
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
                            var sqlCmd = new SqlCommand("addClient", sqlConn);
                            sqlCmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter EmailParameter = new SqlParameter
                            {
                                ParameterName = "@email",
                                Value = email
                            };
                            sqlCmd.Parameters.Add(EmailParameter);
                            SqlParameter PasswordParameter = new SqlParameter
                            {
                                ParameterName = "@password",
                                Value = password
                            };
                            sqlCmd.Parameters.Add(PasswordParameter);
                            SqlParameter FirstNameParameter = new SqlParameter
                            {
                                ParameterName = "@first_name",
                                Value = firstName
                            };
                            sqlCmd.Parameters.Add(FirstNameParameter);
                            SqlParameter LastNameParameter = new SqlParameter
                            {
                                ParameterName = "@last_name",
                                Value = lastName
                            };
                            sqlCmd.Parameters.Add(LastNameParameter);
                            SqlParameter PhoneNumberParameter = new SqlParameter
                            {
                                ParameterName = "@phone_number",
                                Value = phoneNumber
                            };
                            sqlCmd.Parameters.Add(PhoneNumberParameter);

                            sqlCmd.ExecuteNonQuery();

                            MessageBox.Show("Registration completed successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            //MessageBox.Show("Error of registration :(\nPlease, try to register again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
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
