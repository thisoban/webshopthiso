using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using IDAL;
using MySql.Data.MySqlClient;

namespace DAL
{
   public class UserDal : IDalUser
    {
       private readonly DAL DALAcces = new DAL();
        public bool DeleteUser()
        {
            throw new NotImplementedException();
        }

        public UserData GetUserDetail(int id)
        {
            DALAcces.conn.Open();
            UserData data = new UserData();
            string query = "Select * FROM user WHERE Id = @Id";

            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@Id", id));

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Id = reader.GetChar(0);
                data.Email = reader.GetString(2);
                data.Passsword = reader.GetString(3);

                //data.Firstname = reader.GetString("Name");
                //data.Surname = reader.GetString("surname");
                //data.Adres = reader.GetString(3);
                //data.City = reader.GetString(4);

            }
            DALAcces.conn.Close();
            return data;
           
        }

        public List<UserData> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool InsertUser(UserData newUser)
        {
            string query = "INSERT INTO User(email, password, admin, Role_id) " +
                           "VALUES (@email,@password,@quantity,@sellprice,@serialnumber)";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@email", newUser.Email));
            command.Parameters.Add(new MySqlParameter("@password", newUser.Passsword));
            command.Parameters.Add(new MySqlParameter("@admin", newUser.Admin));
            try
            {
                command.ExecuteNonQuery();
                if (command.ExecuteNonQuery().Equals(1))
                {
                    DALAcces.conn.Close();
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            DALAcces.conn.Close();
            return false;
            throw new NotImplementedException();
        }

        public bool UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
