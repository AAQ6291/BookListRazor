using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class ConfigContext
    {
        public string MgzTitle { get; set; }


        public String GetPrdID()
        {
            String PrdID = "ABC_2010";

            return PrdID;
        }
    }
}
