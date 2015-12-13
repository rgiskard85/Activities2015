using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Activities2015
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IXMLToDict" in both code and config file together.
    [ServiceContract]
    public interface IXMLToDict
    {
        [OperationContract]
        Dictionary<string, string> ReadXML(string XMLFile);
    }
}
