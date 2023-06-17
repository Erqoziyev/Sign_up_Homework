using Npgsql;
using Sign_up_Homework.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Sign_up_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async  void Button_Click(object sender, RoutedEventArgs e)
        {

            await using (var connection = new NpgsqlConnection(db_constans.DB_CONNECTION_STRING))
            {
                await connection.OpenAsync();

                string email = tbEmail.Text;
                string password = tbPassword.Password;

                string query = $"select *from users where id = '1'";


                await using (var command = new NpgsqlCommand(query, connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            if (email == reader.GetString(1) && password == reader.GetString(2))
                            {
                                MessageBox.Show("Successful");
                            }
                            else
                                MessageBox.Show("Eror");
                        }
                        await reader.CloseAsync();
                    }
                }
                await connection.CloseAsync();
            }
        }
    }
}
