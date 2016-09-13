using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataContract
/// </summary>

    public class GetAllStudentsResult
    {
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }
        public int id { get; set; }
    }

    public class Students
    {
        public List<GetAllStudentsResult> GetAllStudentsResult { get; set; }
    }
public class Utility
	{
    public static string getservicebaseURL()
    {
      //can be define in webconfig
        return "http://localhost:16799/CRUD.svc/";
    }
	}  
