using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Activities2015
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DBActions" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DBActions.svc or DBActions.svc.cs at the Solution Explorer and start debugging.
    public class DBActions : IDBActions
    {
        string DBConnectionString = @"Server = 83.212.122.8; Port = 3306; Database = acti; Uid = acti; pwd = 12345;";

        public int insertCustomer(string customer_name, string customer_surname, string customer_address, string customer_phone)
        {
            int customer_id = customerExists(customer_name, customer_surname, customer_phone);
            if (customer_id == 0)
            {
                MySqlConnection db = new MySqlConnection(DBConnectionString);
                db.Open();

                MySqlCommand query = new MySqlCommand();
                query.Connection = db;
                query.CommandText = "INSERT INTO customer (customer_name, customer_surname, customer_address, customer_phone) "
                    + "VALUES (@customer_name, @customer_surname, @customer_address, @customer_phone); " 
                    + "SELECT LAST_INSERT_ID()";
                query.Prepare();

                query.Parameters.AddWithValue("@customer_name", customer_name.ToUpper());
                query.Parameters.AddWithValue("@customer_surname", customer_surname.ToUpper());
                query.Parameters.AddWithValue("@customer_address", customer_address.ToUpper());
                query.Parameters.AddWithValue("@customer_phone", customer_phone);

                customer_id = Convert.ToInt32(query.ExecuteScalar());

                db.Close();
            }
            
            return customer_id;
        }

        public int insertSupplier(string supplier_name, string supplier_address)
        {
            int supplier_id = supplierExists(supplier_name);
            if (supplier_id == 0)
            {
                MySqlConnection db = new MySqlConnection(DBConnectionString);
                db.Open();

                MySqlCommand query = new MySqlCommand();
                query.Connection = db;
                query.CommandText = "INSERT INTO supplier (supplier_name, supplier_address) "
                    + "VALUES (@supplier_name, @supplier_address); "
                    + "SELECT LAST_INSERT_ID()";
                query.Prepare();

                query.Parameters.AddWithValue("@supplier_name", supplier_name.ToUpper());
                query.Parameters.AddWithValue("@supplier_address", supplier_address.ToUpper());

                
                supplier_id = Convert.ToInt32(query.ExecuteScalar());

                db.Close();
            }

            return supplier_id;
        }

        public int insertTransporter(string transporter_name, decimal price_per_kilo)
        {
            int transporter_id = transporterExists(transporter_name);
            if (transporter_id == 0)
            {
                MySqlConnection db = new MySqlConnection(DBConnectionString);
                db.Open();

                MySqlCommand query = new MySqlCommand();
                query.Connection = db;
                query.CommandText = "INSERT INTO transporter (transporter_name, price_per_kilo) "
                    + "VALUES (@transporter_name, @price_per_kilo); "
                    + "SELECT LAST_INSERT_ID()";
                query.Prepare();

                query.Parameters.AddWithValue("@transporter_name", transporter_name.ToUpper());
                query.Parameters.AddWithValue("@price_per_kilo", price_per_kilo);


                transporter_id = Convert.ToInt32(query.ExecuteScalar());

                db.Close();
            }

            return transporter_id;
        }

        public int insertOrder(int customer_id, int supplier_id, int transporter_id, int chair_num, decimal chair_price, 
            decimal chair_weight, int table_num, decimal table_price, decimal table_weight, DateTime order_date, string file_name)
        {
            int order_id = 0;
            if (orderExists(file_name)) {
                return order_id;
            }
            else {            
                MySqlConnection db = new MySqlConnection(DBConnectionString);
                db.Open();

                MySqlCommand query = new MySqlCommand();
                query.Connection = db;
                query.CommandText = "INSERT INTO `order` (customer_id, supplier_id, transporter_id, chair_num, chair_price, chair_weight," + 
                    " table_num, table_price, table_weight, order_date, file_name) "
                    + "VALUES (@customer_id, @supplier_id, @transporter_id, @chair_num, @chair_price, @chair_weight," + 
                    " @table_num, @table_price, @table_weight, @order_date, @file_name); "
                    + "SELECT LAST_INSERT_ID()";
                query.Prepare();

                query.Parameters.AddWithValue("@customer_id", customer_id);
                query.Parameters.AddWithValue("@supplier_id", supplier_id);
                query.Parameters.AddWithValue("@transporter_id", transporter_id);
                query.Parameters.AddWithValue("@chair_num", chair_num);
                query.Parameters.AddWithValue("@chair_price", chair_price);
                query.Parameters.AddWithValue("@chair_weight", chair_weight);
                query.Parameters.AddWithValue("@table_num", table_num);
                query.Parameters.AddWithValue("@table_price", table_price);
                query.Parameters.AddWithValue("@table_weight",table_weight);
                query.Parameters.AddWithValue("@order_date", order_date);
                query.Parameters.AddWithValue("@file_name", file_name);
                
                order_id = Convert.ToInt32(query.ExecuteScalar());

                db.Close();
                return customer_id;
            }           
        }

        public int customerExists(string customer_name, string customer_surname, string customer_phone)
        {
            int customer_id = 0;
            
            MySqlConnection db = new MySqlConnection(DBConnectionString);
            db.Open();
            MySqlCommand query = new MySqlCommand();
            query.Connection = db;
            query.CommandText = "SELECT customer_id FROM customer WHERE customer_name = @customer_name" 
                + " AND customer_surname = @customer_surname AND customer_phone = @customer_phone";
            query.Prepare();

            query.Parameters.AddWithValue("@customer_name", customer_name.ToUpper());
            query.Parameters.AddWithValue("@customer_surname", customer_surname.ToUpper());
            query.Parameters.AddWithValue("@customer_phone", customer_phone);
            MySqlDataReader queryResults = query.ExecuteReader();
            if (queryResults.Read())
            {
                customer_id = queryResults.GetInt32(0);
            }
            queryResults.Close();
            queryResults = null;
            db.Close();

            return customer_id;
        }

        public int supplierExists(string supplier_name)
        {
            int supplier_id = 0;

            MySqlConnection db = new MySqlConnection(DBConnectionString);
            db.Open();
            MySqlCommand query = new MySqlCommand();
            query.Connection = db;
            query.CommandText = "SELECT supplier_id FROM supplier WHERE supplier_name = @supplier_name";
            query.Prepare();

            query.Parameters.AddWithValue("@supplier_name", supplier_name.ToUpper());
            MySqlDataReader queryResults = query.ExecuteReader();
            if (queryResults.Read())
            {
                supplier_id = queryResults.GetInt32(0);
            }
            queryResults.Close();
            queryResults = null;
            db.Close();

            return supplier_id;
        }

        public int transporterExists(string transporter_name)
        {
            int transporter_id = 0;

            MySqlConnection db = new MySqlConnection(DBConnectionString);
            db.Open();
            MySqlCommand query = new MySqlCommand();
            query.Connection = db;
            query.CommandText = "SELECT transporter_id FROM transporter WHERE transporter_name = @transporter_name";
            query.Prepare();

            query.Parameters.AddWithValue("@transporter_name", transporter_name.ToUpper());
            MySqlDataReader queryResults = query.ExecuteReader();
            if (queryResults.Read())
            {
                transporter_id = queryResults.GetInt32(0);
            }
            queryResults.Close();
            queryResults = null;
            db.Close();

            return transporter_id;
        }

        public bool orderExists(string file_name)
        {
            MySqlConnection db = new MySqlConnection(DBConnectionString);
            db.Open();

            MySqlCommand query = new MySqlCommand();
            query.Connection = db;
            query.CommandText = "SELECT file_name FROM `order` WHERE file_name = @file_name";
            query.Prepare();

            query.Parameters.AddWithValue("@file_name", file_name);
            MySqlDataReader queryResults = query.ExecuteReader();
            if (queryResults.Read())
            {
                queryResults.Close();
                queryResults = null;
                db.Close();
                return true;
            }
            else
            {
                queryResults.Close();
                queryResults = null;
                db.Close();
                return false;
            }
        }

        public List<Dictionary<string, string>> selectOrder()
        {
            List<Dictionary<string, string>> transfers = new List<Dictionary<string,string>>();

            MySqlConnection db = new MySqlConnection(DBConnectionString);
            db.Open();
            MySqlCommand query = new MySqlCommand();

            query.Connection = db;
            query.CommandText = "SELECT o.order_id, c.customer_surname, c.customer_name, s.supplier_name, t.transporter_name, " + 
                "s.supplier_address, c.customer_address, o.chair_num, o.chair_price, o.chair_weight, o.table_num, o.table_price, " + 
                "o.table_weight, o.order_date FROM `order` o, customer c, supplier s, transporter t " + 
                "WHERE o.customer_id = c.customer_id AND o.supplier_id = s.supplier_id AND o.transporter_id = t.transporter_id";
            query.Prepare();

            MySqlDataReader queryResults = query.ExecuteReader();
            while (queryResults.Read())
            {
                Dictionary<string, string> transfer = new Dictionary<string, string>();
                transfer.Add("order_id", queryResults.GetString(0));
                transfer.Add("customer_surname", queryResults.GetString(1));
                transfer.Add("customer_name", queryResults.GetString(2));
                transfer.Add("supplier_name", queryResults.GetString(3));
                transfer.Add("transporter_name", queryResults.GetString(4));
                transfer.Add("supplier_address", queryResults.GetString(5));
                transfer.Add("customer_address", queryResults.GetString(6));
                transfer.Add("chair_num", queryResults.GetString(7));
                transfer.Add("chair_price", queryResults.GetString(8));
                transfer.Add("chair_weight", queryResults.GetString(9));
                transfer.Add("table_num", queryResults.GetString(10));
                transfer.Add("table_price", queryResults.GetString(11));
                transfer.Add("table_weight", queryResults.GetString(12));
                transfer.Add("order_date", queryResults.GetString(13));

                transfers.Add(transfer);
            }

            queryResults.Close();
            queryResults = null;
            db.Close();

            return transfers;
        }


        public Dictionary<int, string> selectOrderMin()
        {
            MySqlConnection db = new MySqlConnection(DBConnectionString);
            db.Open();
            MySqlCommand query = new MySqlCommand();
            query.Connection = db;
            query.CommandText = "SELECT order_id, file_name FROM `order`";
            query.Prepare();

            MySqlDataReader queryResults = query.ExecuteReader();

            Dictionary<int,string> response = new Dictionary<int,string>();
            while (queryResults.Read()) 
            {
                response.Add(queryResults.GetInt32(0),queryResults.GetString(1));
            }

            queryResults.Close();
            queryResults = null;
            db.Close();

            return response;

        }

        public Dictionary<string, string> selectOrderById(int order_id)
        {
            MySqlConnection db = new MySqlConnection(DBConnectionString);
            MySqlCommand query = new MySqlCommand();
            db.Open();

            query.Connection = db;
            query.CommandText = "SELECT o.order_id, c.customer_surname, c.customer_name, s.supplier_name, t.transporter_name, " +
                "s.supplier_address, c.customer_address, o.chair_num, o.chair_price, o.chair_weight, o.table_num, o.table_price, " +
                "o.table_weight, o.order_date FROM `order` o, customer c, supplier s, transporter t " +
                "WHERE o.customer_id = c.customer_id AND o.supplier_id = s.supplier_id AND o.transporter_id = t.transporter_id" +
                " AND o.order_id = @order_id";
            query.Prepare();

            query.Parameters.AddWithValue("@order_id", order_id);
            MySqlDataReader queryResults = query.ExecuteReader();

            Dictionary<string, string> transfer = new Dictionary<string, string>();
            transfer.Add("", "");
            if (queryResults.Read())
            {
                transfer.Add("order_id", queryResults.GetString(0));
                transfer.Add("customer_surname", queryResults.GetString(1));
                transfer.Add("customer_name", queryResults.GetString(2));
                transfer.Add("supplier_name", queryResults.GetString(3));
                transfer.Add("transporter_name", queryResults.GetString(4));
                transfer.Add("supplier_address", queryResults.GetString(5));
                transfer.Add("customer_address", queryResults.GetString(6));
                transfer.Add("chair_num", queryResults.GetString(7));
                transfer.Add("chair_price", queryResults.GetString(8));
                transfer.Add("chair_weight", queryResults.GetString(9));
                transfer.Add("table_num", queryResults.GetString(10));
                transfer.Add("table_price", queryResults.GetString(11));
                transfer.Add("table_weight", queryResults.GetString(12));
                transfer.Add("order_date", queryResults.GetString(13));
            }

            queryResults.Close();
            queryResults = null;
            db.Close();

            return transfer;
        }
    }
}
