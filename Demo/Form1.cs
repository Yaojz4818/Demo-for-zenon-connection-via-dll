using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Camstar.XMLClient.API;
using Camstar.XMLClient.Wraper;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static string ServiceName = "Open";
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ExecuteService("8BM1950161").ReturnMsg);
            zenonInterface zi = new zenonInterface();

            //read or write zenon data
            try
            {
                zenonInterface.ConnectZenonRuntime();
            }
            catch (Exception ex)
            {
            }
        }
        public ReturnInformation ExecuteService(string lotID)
        {
            ReturnInformation rt = new ReturnInformation();
            rt.ReturnCode = "0";
            rt.ReturnMsg = "Return Error";

            XMLClient Client = new XMLClient();
            UserConfig userconfig = new UserConfig();
            string LotMoveInService = "Open";
            try
            {
                Client = UserConfig.CreateXMLClient();
                EmployeeObj emp = UserConfig.GetEmployee();
                Client.InitializeSession();
                Client.CreateDocumentandService(LotMoveInService + "Doc", LotMoveInService);

                csiObject inputData = Client.GetService().inputData();
                userconfig.GetSecurityInputData(inputData, emp);

                inputData.namedObjectField("Container").setRef(lotID); //只需传入批号条件即可
                Client.GetService().setExecute();
                //Request the completion message and more from the XML Application server
                csiRequestData requestData = Client.GetService().requestData();
                requestData.requestField("CompletionMsg");
                csiDocument respDoc = Client.GetDocument().submit();

                Client.CheckForErrors(respDoc);

                if (Client.Success() == true)
                {
                    rt.ReturnCode = "1";
                    rt.ReturnMsg = string.Format("批次[{0}]，操作成功，返回成功信息[{1}]！", lotID, Client.GetMessage());
                }
                else
                {
                    rt.ReturnCode = "0";
                    rt.ReturnMsg = string.Format("批次[{0}]，操作失败，返回失败信息[{1}]！", lotID, Client.GetMessage());
                }
            }
            catch (Exception ex)
            {
                rt.ReturnCode = "0";
                rt.ReturnMsg = string.Format("批次[{0}]，通讯异常:[{1}]！", lotID, ex.Message);
            }
            finally
            {
                Client.CleanUp(ServiceName + "Doc");
            }
            return rt;
        }
        public class ReturnInformation
        {
            //返回值，"0"表示成功,其他值表示失敗
            //[DataMember]
            public string ReturnCode { get; set; }
            //返回資訊
            //[DataMember]
            public string ReturnMsg { get; set; }
            //返回資訊
            //[DataMember]
            public string ReturnValue { get; set; }
        }
    }
}
