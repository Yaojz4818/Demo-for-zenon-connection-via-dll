using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassC1;

namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
            myvariable my = new myvariable();
            my.Real = 150;
            my.calrealdisplay();
            Console.WriteLine("game is over");
        }
    }
    class myvariable { 
        private long real = 100, max = 300, min = 0, barheight = 300, realdisplay;


        public long Realdisplay  // Actual Bar Display
        {
            get { return realdisplay; }
            set
            {
                realdisplay = value;
            }
        }
        public long Real  //current temp.
        {
            get
            {
                return real;
            }
            set
            {

                real = value;

                //                myhandle();

            }
        }
        public void calrealdisplay()
        {
            realdisplay = (real - min)* BarHeight / (max - min) ;
                Console.WriteLine("real display is", realdisplay);

        }
        public long Max  // max. temp. limit
        {
            get { return max; }
            set
            {
                max = value;
            }
        }
        public long Min  //min. temp. limit
        {
            get { return min; }
            set
            {
                min = value;

            }
        }
        public long BarHeight  //max. bar height
        {
            get { return barheight; }
            set
            {
                barheight = value;

            }

        }
         
      } 
}
