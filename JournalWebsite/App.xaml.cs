using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;

namespace JournalWebsite
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Connection (Like a bridge)...app config
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog = JournalWebsite; Integrated Security = True";

        //Connecting to your database
        static SqlConnection JournalWebsite = new SqlConnection(connection);
    }
}
