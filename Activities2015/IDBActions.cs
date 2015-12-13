using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Activities2015
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDBActions" in both code and config file together.
    [ServiceContract]
    public interface IDBActions
    {
        [OperationContract]
        int insertCustomer(string customer_name, string customer_surname, string customer_address, string customer_phone);

        [OperationContract]
        int insertSupplier(string supplier_name, string supplier_address);

        [OperationContract]
        int insertTransporter(string transporter_name, decimal price_per_kilo);

        [OperationContract]
        int insertOrder(int customer_id, int supplier_id, int transporter_id, int chair_num, decimal chair_price,
            decimal chair_weight, int table_num, decimal table_price, decimal table_weight, DateTime order_date,
            string file_name);

        [OperationContract]
        int customerExists(string customer_name, string customer_surname, string customer_phone);

        [OperationContract]
        int supplierExists(string supplier_name);

        [OperationContract]
        int transporterExists(string transporter_name);

        [OperationContract]
        bool orderExists(string file_name);

        [OperationContract]
        List<Dictionary<string, string>> selectOrder();

        [OperationContract]
        Dictionary<int, string> selectOrderMin();

        [OperationContract]
        Dictionary<string, string> selectOrderById(int order_id);
    }
}
