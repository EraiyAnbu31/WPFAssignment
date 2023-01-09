using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Assignment.View.View;
using Assignment.View.ViewModel;

namespace Assignment.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var window1 = new Window1();
            window1.Show();
            window1.IsVisibleChanged += (s,ev) =>
            {
                if (window1.IsVisible == false && window1.IsLoaded)
                {
                    var mainwindow = new MainWindow();
                    mainwindow.Show();
                    window1.Close();
                }
            };
        }
    }
}
