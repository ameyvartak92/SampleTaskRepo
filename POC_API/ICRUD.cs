using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace POC_API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICRUD" in both code and config file together.
    [ServiceContract]
    public interface ICRUD
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "AddnewStudent?Name={Name}&Address={Address}&Contact={Contact}&Roll={Roll}")]
        bool AddnewStudent(string Name, string Address, string Contact, string Roll);

        [OperationContract]
        [WebInvoke(Method = "GET",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "UpdateStudent?id={id}&Name={Name}&Address={Address}&Contact={Contact}&Roll={Roll}")]
        bool UpdateStudent(string id, string Name, string Address, string Contact, string Roll);

        [OperationContract]
        [WebInvoke(Method = "GET",
ResponseFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "DeleteStudent?studentid={studentid}")]
        bool DeleteStudent(string studentid);

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "GetAllStudents")]
        List<bizStudent> GetAllStudents();

        [OperationContract]
        [WebInvoke(Method = "GET",
      ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "GetAllStudents?startwithName={startwithName}")]
        List<bizStudent> GetAllStudents_startwith(string startwithName);
    }
    [DataContract]
    public class bizStudent
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string Roll { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Contact { get; set; }

    }
}
