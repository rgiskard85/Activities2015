using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Activities2015
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Master" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Master.svc or Master.svc.cs at the Solution Explorer and start debugging.
    public class Master : IMaster
    {
        string orderDirectory = "C:\\Users\\R.Giskard Reventlov\\Documents\\Visual Studio 2013\\Projects\\Activities2015" +
            "\\Activities2015\\App_Data\\";

        public void UpdateOrders()
        {
            DBActions dbc = new DBActions();
            XMLToDict xtdc = new XMLToDict();
            List<Dictionary<string,string>> unFiledOrders = new List<Dictionary<string,string>>();
            string[] fileEntries = Directory.GetFiles(orderDirectory);
            
            foreach (string file_name in fileEntries)
            {
                if (!dbc.orderExists(file_name))
                {
                    unFiledOrders.Add(xtdc.ReadXML(file_name));
                }                
            }

            if (unFiledOrders.Count > 0)
            {
                foreach (Dictionary<string, string> dict in unFiledOrders)
                {                    
                    int customer_id = dbc.insertCustomer(dict["customer_name"], dict["customer_surname"], dict["customer_address"], dict["customer_phone"]);
                    int supplier_id = dbc.insertSupplier(dict["supplier_name"], dict["supplier_address"]);
                    int transporter_id = dbc.insertTransporter(dict["transporter_name"], Decimal.Parse(dict["price_per_kilo"]));
                    dbc.insertOrder(customer_id, supplier_id, transporter_id, 
                        Int32.Parse(dict["chair_num"]), Decimal.Parse(dict["chair_price"]), Decimal.Parse(dict["chair_weight"]),
                        Int32.Parse(dict["table_num"]), Decimal.Parse(dict["table_price"]), Decimal.Parse(dict["table_weight"]),
                        DateTime.Parse(dict["order_date"]), dict["file_name"]);
                }
            }
        }


        public List<Dictionary<string, string>> GetOrders()
        {
            DBActions dbc = new DBActions();

            return dbc.selectOrder();
        }


        public Dictionary<int, string> GetOrdersMin()
        {
            DBActions dbc = new DBActions();

            return dbc.selectOrderMin();
        }

        public Dictionary<string, string> GetOrderByID(int order_id)
        {
            DBActions dbc = new DBActions();

            return dbc.selectOrderById(order_id);
        }
    }
}
