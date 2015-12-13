using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace Activities2015
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "XMLToDict" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select XMLToDict.svc or XMLToDict.svc.cs at the Solution Explorer and start debugging.
    public class XMLToDict : IXMLToDict
    {

        public Dictionary<string, string> ReadXML(string XMLFile)
        {
            Dictionary<string, string> order = new Dictionary<string, string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLFile);

            XmlNodeList customerNodeList = doc.SelectNodes("/transfer/customer");
            foreach (XmlNode xn in customerNodeList)
            {
                order.Add("customer_name", xn["name"].InnerText);
                order.Add("customer_surname", xn["surname"].InnerText);
                order.Add("customer_address", xn["address"].InnerText);
                order.Add("customer_phone", xn["phone"].InnerText);
            }
            XmlNodeList chairNodeList = doc.SelectNodes("/transfer/order/chair");
            foreach (XmlNode xn in chairNodeList)
            {
                order.Add("chair_num", xn["quantity"].InnerText);
                order.Add("chair_price", xn["price"].InnerText);
                order.Add("chair_weight", xn["weight"].InnerText);
            }
            XmlNodeList tableNodeList = doc.SelectNodes("/transfer/order/table");
            foreach (XmlNode xn in tableNodeList)
            {
                order.Add("table_num", xn["quantity"].InnerText);
                order.Add("table_price", xn["price"].InnerText);
                order.Add("table_weight", xn["weight"].InnerText);
            }
            XmlNode orderDateNode = doc.SelectSingleNode("/transfer/order/order_date");
            order.Add("order_date", orderDateNode.InnerText);
            XmlNodeList supplierNodeList = doc.SelectNodes("/transfer/supplier");
            foreach (XmlNode xn in supplierNodeList)
            {
                order.Add("supplier_name", xn["supplier_name"].InnerText);
                order.Add("supplier_address", xn["supplier_address"].InnerText);
            }
            XmlNodeList tranrporterNodeList = doc.SelectNodes("/transfer/transporter");
            foreach (XmlNode xn in tranrporterNodeList)
            {
                order.Add("transporter_name", xn["transporter_name"].InnerText);
                order.Add("price_per_kilo", xn["price_per_kilo"].InnerText);
            }
            order.Add("file_name", XMLFile.Substring(106));
            return order;
        }
    }
}
