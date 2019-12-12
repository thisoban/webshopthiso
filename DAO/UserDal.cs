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
        DAL DALAcces = new DAL();
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
                data.Id = reader.GetInt32(0);
                data.Firstname = reader.GetString("Name");
                data.Surname = reader.GetString("Description");
                data.Adres = reader.GetString(3);
                data.City = reader.GetString(4);

            }
            DALAcces.conn.Close();
            return data;
            throw new NotImplementedException();
        }

        public List<UserData> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool InsertUser()
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
