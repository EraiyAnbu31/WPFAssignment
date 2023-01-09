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
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Markup;
using System.Reflection;


namespace Assignment.View.View
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        public Window2()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (localdb)\\LocalDB; Initial Catalog = Users; Integrated Security = True; Pooling = False");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[User]([FirstName],[LastName],[Gender],[Email],[D.O.B],[Password],[CPassword]) 
                VALUES('" + txtfname.Text + "','" + txtlname.Text + "','" + gender.SelectionBoxItemStringFormat + "','" + email.Text + "','" + date.SelectedDate +"','" + password.Password + "','" + cpassword.Password + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            MessageBox.Show("Registered successfully");

        }
    }
}
