using System;
using MySql.Data.MySqlClient;
namespace DAO
{
    public class DAL
    {
        public MySqlConnection conn;
        public DAL()
        {
            conn =  new MySqlConnection("server=studmysql01.fhict.local;Uid=dbi419727;Database=dbi419727;pwd=Testing;");
        }
    }
}
