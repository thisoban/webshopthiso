using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Configuration;
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
            data.Adres = "anonymous";
            data.City = "anonymous";
            data.Firstname= "anonymous";
            data.Surname = "anonymous";
            data.Housenumber = "anonymous";
            data.Postalcode = "anonymous";
            
            string query = "UPDATE user SET email = @email, password  =@password, Admin = @admin " +
                           "WHERE id = @id";
           
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);

            command.Parameters.Add(new MySqlParameter("@email", data.Email ));
            command.Parameters.Add(new MySqlParameter("@password", data.Passsword));
            command.Parameters.Add(new MySqlParameter("@firstname", data.Firstname));
            command.Parameters.Add(new MySqlParameter("@surname", data.Surname));
            command.Parameters.Add(new MySqlParameter("@housenumber", data.Housenumber));
            command.Parameters.Add(new MySqlParameter("@adres", data.Adres));
            command.Parameters.Add(new MySqlParameter("@city", data.City));
            command.Parameters.Add(new MySqlParameter("@postalcode", data.Postalcode));
            command.ExecuteNonQuery();

           // command.Parameters.Add()
           return true;
        }

        public UserData GetUserDetail(UserData emaildata)
        {
            DALAcces.conn.Open();
            UserData data = new UserData();
            string query = "Select * FROM user WHERE IdUser = @IdUser";

            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@IdUser", emaildata.Email));

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.uid = reader.GetString(1);
                data.Email = reader.GetString(2);
                data.Passsword = reader.GetString(3);

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
                        IdUser = reader.GetInt32("id"),
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
            string query = "INSERT INTO User(uid, email, password, admin, Role_id) " +
                           "VALUES (@id, @email,@password,@quantity,@sellprice,@serialnumber)";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@email", newUser.Email));
            command.Parameters.Add(new MySqlParameter("@password", newUser.Passsword));
            command.Parameters.Add(new MySqlParameter("@admin", newUser.Admin));
            command.Parameters.Add(new MySqlParameter("@id", GuidMaker()));
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

        private string GuidMaker()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("==", "");
        }
        public void InsertCustomerDetail(UserData user)
        {
            string query = "INSERT INTO customer (uid, Email, Firstname, Surname, Adres, Housenumber, Postalcode, city) " +
                           "VALUES ( @id, @Email,@Firstname,@Surname,@Adres,@Housenumber,@Postalcode,@City)";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@Email", user.Email));
            command.Parameters.Add(new MySqlParameter("@Firstname", user.Firstname));
            command.Parameters.Add(new MySqlParameter("@Surname", user.Surname));
            command.Parameters.Add(new MySqlParameter("@Adres", user.Adres));
            command.Parameters.Add(new MySqlParameter("@Housenumber", user.Housenumber));
            command.Parameters.Add(new MySqlParameter("@Postalcode", user.Postalcode));
            command.Parameters.Add(new MySqlParameter("@City", user.City)); 
            command.Parameters.Add(new MySqlParameter("@id", user.uid));
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

        private bool CheckAdmin(UserData user)
        {
             int admin = 0;
             string query = "SELECT admin FROM user WHERE Id = @IdUser";
             DALAcces.conn.Open();
             MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
             command.Parameters.Add(new MySqlParameter("@IdUser", user.IdUser));
             MySqlDataReader reader = command.ExecuteReader();
             while (reader.Read())
             {
                admin = reader.GetInt32(4);
             }
             if (admin == 1)
             {
                 user.Admin = true;
                 return true;
             }
             if (admin == 0)
             {
                 user.Admin = false;
                 return false;
             }
             return false;
        }
    }
}
