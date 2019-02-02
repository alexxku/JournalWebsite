using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JournalLibrary
{
    public class Access
    {
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog = JournalWebsite; Integrated Security = True";

        static SqlConnection JournalWebsite = new SqlConnection(connection);

        public static User login(User user)
        {
            string SELECT = $"SELECT LoginId, [UserName], [Password] FROM [User info] WHERE [UserName] = @UserName AND [Password] = @Password";

          
            SqlDataAdapter log = new SqlDataAdapter(SELECT, JournalWebsite);

            log.SelectCommand.Parameters.AddWithValue("@UserName", user.UserName);
            log.SelectCommand.Parameters.AddWithValue("@Password", user.Password);

            DataSet data = new DataSet();

            log.Fill(data);


            User user1 = new User();


            if (data.Tables[0].Rows.Count > 0)
            {
                user1.UserName = data.Tables[0].Rows[0]["UserName"].ToString();
                user1.Password = data.Tables[0].Rows[0]["Password"].ToString();
                user1.LoginId = (int)data.Tables[0].Rows[0]["LoginId"];

                return user1;
            }

            return null;

        }

        public static User register(User user)
        {
            string SELECT = $"SELECT LoginId, [UserName] FROM [User info] WHERE [UserName] = @UserName";
            string SELECT2 = $"SELECT LogInId, [UserName], [Password] FROM [User info] WHERE [UserName] = @UserName AND [Password] = @Password";
            string ADD = $"INSERT INTO[User info] ([UserName], [Password]) VALUES(@UserName, @Password)";

            SqlDataAdapter reg = new SqlDataAdapter(SELECT, JournalWebsite);

            reg.SelectCommand.Parameters.AddWithValue("@UserName", user.UserName);

            DataSet data = new DataSet();

            reg.Fill(data);


            if (data.Tables[0].Rows.Count < 1)
            {
                if (user.Password == "" || user.Password.Length < 1)
                {
                    return user;
                }
                else
                {
                    SqlCommand command = new SqlCommand(ADD, JournalWebsite);


                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@Password", user.Password);

                    JournalWebsite.Open();

                    command.ExecuteNonQuery();


                    JournalWebsite.Close();

                    User user1 = new User();

                    SqlDataAdapter newreg = new SqlDataAdapter(SELECT2, JournalWebsite);

                    newreg.SelectCommand.Parameters.AddWithValue("@UserName", user.UserName);
                    newreg.SelectCommand.Parameters.AddWithValue("@Password", user.Password);


                    newreg.Fill(data);

                    user1.LoginId = (int)data.Tables[0].Rows[0]["LogInId"];
                    user1.UserName = data.Tables[0].Rows[0]["UserName"].ToString();
                    user1.Password = data.Tables[0].Rows[0]["Password"].ToString();
                    
                    return user1;
                }

            }
            else
            {
                return null;
            }
        }
    }
}