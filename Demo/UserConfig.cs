using System;
using System.Collections.Generic;
using Camstar.XMLClient.API;
using Camstar.XMLClient.Wraper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Demo
{
    public class UserConfig
    {
        public static string Host = ConfigurationManager.AppSettings["Host"];
        public static string Port = ConfigurationManager.AppSettings["Port"];
        public static string UserName = ConfigurationManager.AppSettings["Username"];
        public static string Password = ConfigurationManager.AppSettings["Password"];
        public static string Domain = ConfigurationManager.AppSettings["Domain"];

        public static XMLClient CreateXMLClient()
        {
            XMLClient client = new XMLClient();
            client.InitializeConfig(Host.Trim(), Port.Trim(), UserName.Trim(), Password.Trim(), Domain.Trim());
            return client;
        }

        public static EmployeeObj GetEmployee()
        {
            EmployeeObj emp = new EmployeeObj();
            emp.Username = UserName.Trim();
            emp.EmployeeNo = UserName.Trim();
            emp.Password = Password.Trim();
            return emp;
        }

        public void GetSecurityInputData(csiObject inputData, EmployeeObj e)
        {
            if (inputData != null && e != null)
            {
                if (!string.IsNullOrEmpty(e.Username))
                {
                    inputData.namedObjectField("User").setRef(e.Username);
                }
                if (!string.IsNullOrEmpty(e.EmployeeNo))
                {
                    inputData.namedObjectField("Employee").setRef(e.EmployeeNo);
                }
                if (!string.IsNullOrEmpty(e.Password))
                {
                    inputData.dataField("Password").setValue(e.Password);
                }
            }
        }


    }
}
