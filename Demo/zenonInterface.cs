using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using zenOn;

namespace Demo
{
    public class zenonInterface
    {
        private static zenOn.Application rt = null;
        private static Projects projs = null;
        private static Project proj = null;
        public static void ConnectZenonRuntime()
        {
            //start zenon runtime fisrt, or waiting if runtime already started.
            while (rt == null)
            {
                try
                {
                    rt = Marshal.GetActiveObject("zenOn.Application") as zenOn.Application;
                    if (rt != null)
                    {
                        Console.WriteLine("\n zenon runtime is online now!");
                        GetApplicationInterface();
                    }
                }
                catch (Exception)
                {
                    rt = null;
                }
            }
        }

        private static void GetApplicationInterface()
        {
            projs = rt.Projects();

            //Get zenon runtime project name from zenon editor
            string projectname = "SUPERVISOR800";  //just example
            proj = projs.Item(projectname);
            if (proj != null)
            {
                proj.Inactive += Program_Inactive;
                
                //Do what you want below......
                Variables vars = proj.Variables();
                Variable var = vars.Item(0); 
                MessageBox.Show(var.Name+"/"+var.Value);
            }
            else
            {
                Console.WriteLine("\n Your Project name is wrong!");
            }
        }

        private static void Program_Inactive()
        {
            proj.Inactive -= Program_Inactive;
            Console.WriteLine("\n Runtime stopped!");
            Environment.Exit(0);
        }
    }
}
