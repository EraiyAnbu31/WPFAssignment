using Assignment.View.View;
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
using System.Data.SqlClient;
using System.Data;

namespace Assignment.View
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
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(localdb)\\LocalDB;Initial Catalog=Users;Integrated Security=True;Pooling=False";
            try
            {
                con.Open();
                string Query = "select FirstName,LastName,Gender,Email from [User]";
                SqlCommand cmd = new SqlCommand(Query,con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);   
                DataTable dt = new DataTable("User");
                da.Fill(dt);
                datagrid.ItemsSource = dt.DefaultView;

                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
            }
        }
    }
}
