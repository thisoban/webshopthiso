using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataModel;
using IDAL;
using MySql.Data.MySqlClient;

namespace DAL
{
   public class UserDal : IDalUser
    {
       private readonly DAL DALAcces = new DAL();
        public bool DeleteUser(UserData data)
        {
            string query = "UPDATE `user` SET `id`=[value - 1],`email`=[value - 2],`password`=[value - 3],`Admin`=[value - 4],`Role_id`=@roleid WHERE id = @id";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
           // command.Parameters.Add()
            throw new NotImplementedException();
        }

        public UserData GetUserDetail(UserData emaildata)
        {
            DALAcces.conn.Open();
            UserData data = new UserData();
            string query = "Select * FROM customer WHERE Id = @Id";

            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@Id", emaildata.Email));

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Id = reader.GetChar(0);
                data.Email = reader.GetString(2);
                data.Passsword = reader.GetString(3);
                data.Adres = reader.GetString(3);
                data.City = reader.GetString(4);
                data.Firstname = reader.GetString("Name");
                data.Surname = reader.GetString("surname");
                
            }
            DALAcces.conn.Close();
            return data;
           
        }

        public List<UserData> GetUsers()
        {
            List<UserData> users = new List<UserData>();
            string query = "Select * FROM user";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    UserData user = new UserData
                    {
                        Id = reader.GetChar("id"),
                        Email = reader.GetString("Email"),
                        Admin = reader.GetBoolean("Admin")
                    };
                    users.Add(user);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                DALAcces.conn.Close();
            }

            return users;
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
            InsertCustomerDetail(newUser);
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
            finally
            {
                DALAcces.conn.Close();
            }
            return false;
        }

        public void InsertCustomerDetail(UserData user)
        {
            string query = "INSERT INTO customer ( Email, Firstname, Surname, Adres, Housenumber, Postalcode, city) " +
                           "VALUES (@Email,@Firstname,@Surname,@Adres,@Housenumber,@Postalcode,@City)";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@Email", user.Email));
            command.Parameters.Add(new MySqlParameter("@Firstname", user.Firstname));
            command.Parameters.Add(new MySqlParameter("@Surname", user.Surname));
            command.Parameters.Add(new MySqlParameter("@Adres", user.Adres));
            command.Parameters.Add(new MySqlParameter("@Housenumber", user.Housenumber));
            command.Parameters.Add(new MySqlParameter("@Postalcode", user.Postalcode));
            command.Parameters.Add(new MySqlParameter("@City", user.City));
            command.ExecuteNonQuery();
            DALAcces.conn.Close();

        }

        public bool UpdateUser(UserData data)
        {
            string query = "UPDATE Customer SET  Firstname = @Firstname, Surname = @Surname, Adres = @Adres, Housenumber = @HouseNumber, Postalcode = @Postalcode, City = @City WHERE Email = @email";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@email", data.Email));
            command.Parameters.Add(new MySqlParameter("@Firstname", data.Firstname));
            command.Parameters.Add(new MySqlParameter("@Surname", data.Surname));
            command.Parameters.Add(new MySqlParameter("@Adres", data.Adres));
            command.Parameters.Add(new MySqlParameter("@HouseNumber", data.Housenumber));
            command.Parameters.Add(new MySqlParameter("@Postalcode", data.Postalcode));
            command.Parameters.Add(new MySqlParameter("@city", data.City));

            try
            {
                if (command.ExecuteNonQuery() < 0)
                {
                    DALAcces.conn.Close();
                    return false;
                }
                DALAcces.conn.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
