using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Activities2015
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWBFormToXML" in both code and config file together.
    [DataContract]
    public class Transfer
    {
        [DataMember]
        public string customer_name { get; set; }
        [DataMember]
        public string customer_surname { get; set; }
        [DataMember]
        public string customer_address { get; set; }
        [DataMember]
        public string customer_phone { get; set; }
        [DataMember]
        public int chair_number { get; set; }
        [DataMember]
        public decimal chair_weight { get; set; }
        [DataMember]
        public decimal chair_price { get; set; }
        [DataMember]
        public int table_number { get; set; }
        [DataMember]
        public decimal table_weight { get; set; }
        [DataMember]
        public decimal table_price { get; set; }
        [DataMember]
        public DateTime order_date { get; set; }
        [DataMember]
        public string supplier_name { get; set; }
        [DataMember]
        public string supplier_address { get; set; }
        [DataMember]
        public string transporter_name { get; set; }
        [DataMember]
        public decimal price_per_kilo { get; set; }

        public Transfer(string customer_name, string customer_surname, string customer_address, string customer_phone, int chair_number, decimal chair_weight, decimal chair_price, int table_number, decimal table_weight, decimal table_price, DateTime order_date, string supplier_name, string supplier_address, string transporter_name, decimal price_per_kilo)
        {
            this.customer_name = customer_name;
            this.customer_surname = customer_surname;
            this.customer_address = customer_address;
            this.customer_phone = customer_phone;
            this.chair_number = chair_number;
            this.chair_weight = chair_weight;
            this.chair_price = chair_price;
            this.table_number = table_number;
            this.table_weight = table_weight;
            this.table_price = table_price;
            this.order_date = order_date;
            this.supplier_name = supplier_name;
            this.supplier_address = supplier_address;
            this.transporter_name = transporter_name;
            this.price_per_kilo = price_per_kilo;
        }
    }
    
    [ServiceContract]
    public interface IWBFormToXML
    {
        [OperationContract]
        string CreateXML(Transfer transfer);
    }
}
