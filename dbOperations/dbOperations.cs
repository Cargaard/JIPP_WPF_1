using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
namespace dbOperations
{
    public class DbConn
    {
        public void DisplayDataUsingEF()
        {
            using (ConvertersHistoryDataContext context = new ConvertersHistoryDataContext())
            {
                List<Converters> converters = context.Converters.ToList();
                foreach(Converters conv in converters)
                {
                    
                }

            }
        }
        public void InsertDataUsingEF()
        {

        }
        public void AddHistory(string ConverterName)
        {
       
        }
    }
}
