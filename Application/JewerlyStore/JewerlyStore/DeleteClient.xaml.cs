﻿using System;
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
    /// Interaction logic for DeleteClient.xaml
    /// </summary>
    public partial class DeleteClient : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        public DeleteClient()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void selectEmails(object sender, EventArgs e)
        {
            delEmailBox.Items.Clear();
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("getClientsEmails", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    var reader = sqlCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string email = reader.GetString(0);
                            delEmailBox.Items.Add(email);
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

        private void delEmailClick(object sender, RoutedEventArgs e)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                    var sqlCmd = new SqlCommand("deleteClient", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter emailParam = new SqlParameter
                    {
                        ParameterName = "@email",
                        Value = delEmailBox.SelectedItem.ToString()
                    };
                    sqlCmd.Parameters.Add(emailParam);
                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("Client deleted successfully :)", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("The client can not removed, since he commissioned the order");
                }
            }
        }
    }
}
