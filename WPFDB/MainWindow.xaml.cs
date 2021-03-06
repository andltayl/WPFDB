﻿/* Author: Anderson Taylor
 * Date: 9/25/2018
 * File: MainWindow.xaml.cs
 * Description: Logic for the database reader window.
 */
using System;
using System.Collections.Generic;
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
using System.Data.OleDb;

namespace WPFDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\atayl\\source\\repos\\WPFDB\\WPFDB\\CW5.accdb"); //Set up connection to database
        }

        private void See_Assets_Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                for(int i = 0; i < 3; i++)      //Read out 3 columns in each row.
                {
                    data += read[i].ToString() + "  ";
                }

                data += "\n";

            }
            cn.Close();     //Added this so that buttons could be pressed multiple times without a crash.
            DB_Display_Box.Text = data;
        }

        private void See_Employees_Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Employees";       //This is the only difference between the above button and this one.
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                for (int i = 0; i < 3; i++)
                {
                    data += read[i].ToString() + "  ";
                }

                data += "\n";

            }
            cn.Close();
            DB_Display_Box.Text = data;
        }
    }
}
