using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

       private void DeleteCustomer(UserData data)
       {
           data.Adres = "anonymous";
           data.City = "anonymous";
           data.Firstname = "anonymous";
           data.Surname = "anonymous";
           data.Housenumber = "anonymous";
           data.Postalcode = "anonymous";
           data.City = "anonymous";

           string query = "UPDATE customer SET Email = @email , Firstname = @firstname, Surname  = @surname, Adres = @adres, City = @city, Postalcode = @postalcode " +
                          "WHERE uid = @uid";

            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@uid", data.uid));
            command.Parameters.Add(new MySqlParameter("@email", data.Email));
            command.Parameters.Add(new MySqlParameter("@firstname", data.Firstname));
            command.Parameters.Add(new MySqlParameter("@surname", data.Surname));
            command.Parameters.Add(new MySqlParameter("@housenumber", data.Housenumber));
            command.Parameters.Add(new MySqlParameter("@adres", data.Adres));
            command.Parameters.Add(new MySqlParameter("@city", data.City));
            command.Parameters.Add(new MySqlParameter("@postalcode", data.Postalcode));
            try
            {
                command.ExecuteNonQuery();
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

       }
        public bool DeleteUser(UserData data)
        {
            if (data.Admin == false)
            {
                DeleteCustomer(data);
            }
            data.Email = "anonymous";
            data.Passsword = "anonymous";
            
            string query = "UPDATE user SET email = @email, password  = @password, Admin = @admin " +
                           "WHERE uid = @uid";
           
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);

            command.Parameters.Add(new MySqlParameter("@email", data.Email ));
            command.Parameters.Add(new MySqlParameter("@password", data.Passsword));
         
            command.Parameters.Add(new MySqlParameter("@uid", data.uid));
            try
            {
                command.ExecuteNonQuery();
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
          
           return true;
        }

        public UserData GetUserByEmail(UserData login)
        {
            DALAcces.conn.Open();
            UserData data = new UserData();
            string query = "Select * FROM user WHERE email = @email";

            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@email", login.Email));

            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {

                    data.Email = reader.GetString(2);
                    data.uid = reader.GetString(1);
                    data.Passsword = reader.GetString(3);
                    data.Admin = reader.GetBoolean(4);
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
         
          
            return data;
           
        }
        public  UserData GetuserdetailFromUid(string uid)
        {
            if (DALAcces.conn.State == ConnectionState.Open)
            {
                DALAcces.conn.Close();
            }
            DALAcces.conn.Open();
            UserData data = new UserData();
            string query = "Select * FROM user WHERE uid = @uid";

            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@uid", uid));

            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    data.Email = reader.GetString(2);
                    data.Passsword = reader.GetString(3);
                    data.Admin = reader.GetBoolean("Admin");

                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                data.uid = uid;
                DALAcces.conn.Close();
            }

           if(data.Admin == false)
           {
               data.Firstname = GetCustomerDetail(data).Firstname;
               data.Surname = GetCustomerDetail(data).Surname;
               data.Adres =  GetCustomerDetail(data).Adres;
               data.Postalcode =  GetCustomerDetail(data).Postalcode;
               data.Housenumber =  GetCustomerDetail(data).Housenumber;
               data.City =  GetCustomerDetail(data).City;
           }
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
            newUser.uid = GuidMaker();
            string query = "INSERT INTO User(uid, email, password, admin) " +
                           "VALUES (@uid,@email, @password,@admin)";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@email", newUser.Email));
            command.Parameters.Add(new MySqlParameter("@password", newUser.Passsword));
            command.Parameters.Add(new MySqlParameter("@admin", newUser.Admin));
            command.Parameters.Add (new MySqlParameter("@uid", newUser.uid));
            
            try
            {
                if (command.ExecuteNonQuery().Equals(1))
                {
                    DALAcces.conn.Close();
                    InsertCustomerDetail(newUser);
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
            string query = "INSERT INTO customer (uid, Email, Firstname, Surname, Adres, Housenumber, Postalcode, city) " +
                           "VALUES ( @uid, @Email,@Firstname,@Surname,@Adres,@Housenumber,@Postalcode,@City)";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@Email", user.Email));
            command.Parameters.Add(new MySqlParameter("@Firstname", user.Firstname));
            command.Parameters.Add(new MySqlParameter("@Surname", user.Surname));
            command.Parameters.Add(new MySqlParameter("@Adres", user.Adres));
            command.Parameters.Add(new MySqlParameter("@Housenumber", user.Housenumber));
            command.Parameters.Add(new MySqlParameter("@Postalcode", user.Postalcode));
            command.Parameters.Add(new MySqlParameter("@City", user.City));
            command.Parameters.Add(new MySqlParameter("@uid", user.uid));
            try
            {
                command.ExecuteNonQuery();
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
           

        }

        public bool UpdateCustomer(UserData data)
        {
            bool booltje = false;
            string query = "UPDATE Customer SET  Firstname = @Firstname, Surname = @Surname, Adres = @Adres, Housenumber = @HouseNumber, Postalcode = @Postalcode, City = @City WHERE uid = @uid";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
                command.Parameters.Add(new MySqlParameter("@email", data.Email));
                command.Parameters.Add(new MySqlParameter("@Firstname", data.Firstname));
                command.Parameters.Add(new MySqlParameter("@Surname", data.Surname));
                command.Parameters.Add(new MySqlParameter("@Adres", data.Adres));
                command.Parameters.Add(new MySqlParameter("@HouseNumber", data.Housenumber));
                command.Parameters.Add(new MySqlParameter("@Postalcode", data.Postalcode));
                command.Parameters.Add(new MySqlParameter("@city", data.City));
                command.Parameters.Add(new MySqlParameter("@uid", data.uid));
           try
           {
               if (command.ExecuteNonQuery() < 0)
               {

                   booltje = false;
               }
               else
               {
                   booltje = true;
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
           return booltje;
        }

        public bool UpdateUser(UserData user)
        {
            bool updateuser = false;
            DALAcces.conn.Open();
            string query = "UPDATE `user` SET email = @email, password = @password, Admin = @admin WHERE uid = @uid";
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@uid", user.uid));
            command.Parameters.Add(new MySqlParameter("@email", user.Email));
            command.Parameters.Add(new MySqlParameter("@password", user.Passsword));
            command.Parameters.Add(new MySqlParameter("@Admin", user.Admin));
            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    updateuser = true;
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

            if (user.Admin == false)
            {
                if (UpdateCustomer(user))
                {
                    updateuser = true;
                }
            }
            return updateuser;
        }
        private string GuidMaker()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("==", "");
        }
      

        private UserData GetCustomerDetail(UserData uid)
        {
           
            string query = "SELECT * FROM customer WHERE email = @email";
            DALAcces.conn.Open();
            MySqlCommand command = new MySqlCommand(query, DALAcces.conn);
            command.Parameters.Add(new MySqlParameter("@email", uid.Email));
            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.GetString("email") == uid.Email)
                    {
                        uid.Firstname = reader.GetString("Firstname");
                        uid.Surname = reader.GetString("Surname");
                        uid.Adres = reader.GetString("Adres");
                        uid.Housenumber = reader.GetString( "Housenumber");
                        uid.Postalcode = reader.GetString("Postalcode");
                        uid.City = reader.GetString("City");
                    }

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
            return uid;
        }
       
    }
}
