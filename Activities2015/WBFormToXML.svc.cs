using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;

namespace Activities2015
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WBFormToXML" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WBFormToXML.svc or WBFormToXML.svc.cs at the Solution Explorer and start debugging.
    public class WBFormToXML : IWBFormToXML
    {

        public string CreateXML(Transfer transfer)
        {
            XDocument doc = new XDocument(
                new XElement("transfer",
                    new XElement("customer",
                        new XElement("name", transfer.customer_name),
                        new XElement("surname", transfer.customer_surname),
                        new XElement("address", transfer.customer_address),
                        new XElement("phone", transfer.customer_phone)
                        ),
                    new XElement("order",
                        new XElement("chair",
                            new XElement("quantity", transfer.chair_number),
                            new XElement("price", transfer.chair_price),
                            new XElement("weight", transfer.chair_weight)
                            ),
                        new XElement("table",
                            new XElement("quantity", transfer.table_number),
                            new XElement("price", transfer.table_price),
                            new XElement("weight", transfer.table_weight)
                            ),
                        new XElement("order_date", transfer.order_date)
                        ),
                    new XElement("supplier",
                        new XElement("supplier_name", transfer.supplier_name),
                        new XElement("supplier_address", transfer.supplier_address)
                        ),
                    new XElement("transporter",
                        new XElement("transporter_name", transfer.transporter_name),
                        new XElement("price_per_kilo", transfer.price_per_kilo)
                    )
                )
            );


            
            string filename = string.Concat("C:\\Users\\R.Giskard Reventlov\\Documents\\Visual Studio 2013\\Projects\\Activities2015\\Activities2015\\App_Data\\", string.Concat(transfer.order_date.ToString("yyyy-MM-dd-HH-mm-ss",CultureInfo.InvariantCulture),".xml"));
            doc.Save(filename);

            return filename;
        }
    }
}
