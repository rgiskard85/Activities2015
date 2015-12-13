using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Activities2015
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMaster" in both code and config file together.
    [ServiceContract]
    public interface IMaster
    {
        [OperationContract]
        void UpdateOrders();

        [OperationContract]
        List<Dictionary<string, string>> GetOrders();

        [OperationContract]
        Dictionary<int, string> GetOrdersMin();

        [OperationContract]
        Dictionary<string, string> GetOrderByID(int order_id);
    }
}
