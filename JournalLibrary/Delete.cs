using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JournalLibrary
{
    public class Erase
    {

        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog = JournalWebsite; Integrated Security = True";

        static SqlConnection JournalWebsite = new SqlConnection(connection);

        static public void delete(int ID)
        {
            string DELETE = "DELETE FROM [Journal entry] WHERE JournalID = @ID";

            SqlCommand command = new SqlCommand(DELETE, JournalWebsite);
            command.Parameters.AddWithValue("@ID", ID);

            JournalWebsite.Open();
            command.ExecuteNonQuery();
            JournalWebsite.Close();
        }
    }
}
