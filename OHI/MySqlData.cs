using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace OHI
{
    class sqlconnection
    {
        public static MySqlConnection GetDBConnection(string constring)
        {
            MySqlConnection conn = new MySqlConnection(constring);

            return conn;
        }

    }


    public class MySqlData
    {
        public class MySqlExecute
        {

            public class MyResult
            {
                public string ResultText;
                public string ErrorText;
                public bool HasError;
            }

            public static MyResult SqlScalar(string sql, string connection)
            {
                MyResult result = new MyResult();
                try
                {
                    MySqlConnection connRC = new MySqlConnection(connection);
                    MySqlCommand commRC = new MySqlCommand(sql, connRC);
                    connRC.Open();
                    try
                    {
                        result.ResultText = commRC.ExecuteScalar().ToString();
                        result.HasError = false;
                    }
                    catch (Exception ex)
                    {
                        result.ErrorText = ex.Message;
                        result.HasError = true;
                    }
                    connRC.Close();
                }
                catch (Exception ex)
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }
                return result;
            }


            public static MyResult SqlNoneQuery(string sql, MySqlConnection connection)
            {
                MyResult result = new MyResult();
                try
                {
                    MySqlCommand commRC = new MySqlCommand(sql, connection);
                    connection.Open();
                    try
                    {
                        commRC.ExecuteNonQuery();
                        result.HasError = false;
                    }
                    catch (Exception ex)
                    {
                        result.ErrorText = ex.Message;
                        result.HasError = true;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }
                return result;
            }

        }

        public class MySqlExecuteData
        {
            public class MyResultData
            {
                public DataTable ResultData;
                public string ErrorText;
                public bool HasError;
            }


            public static MyResultData SqlReturnDataset(string sql, MySqlConnection sqlConnection)
            {
                MyResultData result = new MyResultData();
                try
                {
                    MySqlCommand commRC = new MySqlCommand(sql, sqlConnection);

                    try
                    {
                        MySqlDataAdapter AdapterP = new MySqlDataAdapter();
                        AdapterP.SelectCommand = commRC;
                        DataSet ds1 = new DataSet();
                        AdapterP.Fill(ds1);
                        result.ResultData = ds1.Tables[0];
                    }
                    catch (Exception ex)
                    {
                        result.HasError = true;
                        result.ErrorText = ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }

                return result;

            }

        }
    }
}
