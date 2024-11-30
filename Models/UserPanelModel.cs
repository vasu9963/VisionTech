using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTemplate.Models
{
    public class UserPanelModel
    {
        public List<Slidertable> slidertables { get; set; }
        public List<Categorytable> categorytables { get; set; }
        public List<Abouttable> abouttables { get; set; }
        public List<Recipevideotable> recipevideotables { get; set; }
    }
}