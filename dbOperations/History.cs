using System;
using System.Collections.Generic;
using System.Text;

namespace dbOperations
{
    public class History
    {
        public int id { get; set; }
        public string ConverterName { get; set; }
        public DateTime UsageDate { get; set; }
        public string unitFrom { get; set; }
        public string unitTo { get; set; }
        public string valueBefore { get; set; }
        public string valueAfter { get; set; }
    }
}
