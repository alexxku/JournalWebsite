using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JournalLibrary
{
    public class Entry
    {
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog = JournalWebsite; Integrated Security = True";

        static SqlConnection JournalWebsite = new SqlConnection(connection);

        public static JournalList entry(JournalList newentry)
        {
            string INSERT = "INSERT INTO [Journal entry] ([LogInID], [Title], [Entry]) VALUES (@ID, @JournalTitle, @JournalEntry)";

            SqlCommand command = new SqlCommand(INSERT, JournalWebsite);

            command.Parameters.AddWithValue("@ID", newentry.LogID);
            command.Parameters.AddWithValue("@JournalTitle", newentry.Title);
            command.Parameters.AddWithValue("@JournalEntry", newentry.Entry);

            JournalWebsite.Open();
            command.ExecuteNonQuery();
            JournalWebsite.Close();

            if(newentry.Entry == "" || newentry.Entry.Length < 1)
            {
                return null;
            }
            else
            {
                return newentry;
            }

        }
    }
}
