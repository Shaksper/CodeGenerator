using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenarator
{
    public class MysqlConnect : SqlConnect
    {
        public  string connectstr = "";
        public MysqlConnect(string ip,string port,string name,string pwd)
        {
            connectstr = $"server={ip};port={port};user={name};password={pwd};SslMode = none;";
        }
        public DbConnection connect()
        {
            //String connetStr = "server=127.0.0.1;port=3306;user=root;password=root; database=minecraftdb;";
            // server=127.0.0.1/localhost 代表本机，端口号port默认是3306可以不写
            MySqlConnection conn = new MySqlConnection(connectstr);
            try
            {
                return conn;
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }
    }
}
