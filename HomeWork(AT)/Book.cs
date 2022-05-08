using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_AT_
{
    [Serializable]
    public class Book
    {
        public int BID { get; set; }
        public string BName { get; set; }
        public string AuthorName { get; set; }
        public int BPrice { get; set; }
    }
}
