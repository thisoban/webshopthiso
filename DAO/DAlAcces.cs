﻿using System;
using MySql.Data.MySqlClient;
namespace DAO
{
    public class DAL
    {
        public MySqlConnection conn;
        public DAL()
        {
            conn =  new MySqlConnection("server=localhost;database=testDB;uid=root;pwd=abc123;");
        }
    }
}