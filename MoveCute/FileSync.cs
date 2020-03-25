using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MoveCute
{
    public class FileSync
    {
        public string DestPath { get; set; }
        private Regex SrcRx { get; set; }

        private string srcMacro;
        public string SrcMacro
        {
            get { return srcMacro; }
            set 
            {   
                srcMacro = value;

                //TODO finish making regex
                SrcRx = new Regex(srcMacro.Replace("\\", "\\\\"));
            }
        }
        
        override public string ToString()
        {
            return SrcMacro + " -> " + DestPath;
        }
    }
}
