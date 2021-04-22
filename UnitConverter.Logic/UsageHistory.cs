using System;
using System.Collections.Generic;
using System.Text;
using dbOperations;
using System.Data.SqlClient;
using System.Linq;
namespace UnitConverter.UsageHistory
{
    public class ConvertersHistory
    {
        public void AddHistoryToDb(string ConverterName, string valueBefore, string valueAfter, string unitFrom = null, string unitTo = null)
        {
            using (ConvertersHistoryDataContext context = new ConvertersHistoryDataContext())
            {
                History history = new History();
                history.ConverterName = ConverterName;
                DateTime date = DateTime.Now;
                history.UsageDate = date;
                history.valueBefore = valueBefore;
                history.valueAfter = valueAfter;
                history.unitFrom = unitFrom;
                history.unitTo = unitTo;
                context.History.Add(history);
                context.SaveChanges();
            }
        }
        public List<History> GetHistoryStatistic(int year, int month, int day)
        {
            using (ConvertersHistoryDataContext context = new ConvertersHistoryDataContext())
            {            
                DateTime timeFrom = new DateTime(2021, 4 , 21);
                DateTime timeTo = new DateTime(2021, 5, 21);
                List<History> history = context.History.Where(x=> x.UsageDate>=timeFrom &&  x.UsageDate >= timeTo).ToList();
                return history;
            }
        }
        public List<History> GetAllStatistics(int page = 0)
        {
            using (ConvertersHistoryDataContext context = new ConvertersHistoryDataContext())
            {
                List<History> history = context.History.Skip(page*20).Take(20).ToList();
                return history;
            }
        }
        public double GetStatisticAmount()
        {
            using (ConvertersHistoryDataContext context = new ConvertersHistoryDataContext())
            {
                List<History> history = context.History.ToList();

                return history.Count;
            }
        }
        public List<History> getThreeMostPopularConversions()
        {
            using (ConvertersHistoryDataContext context = new ConvertersHistoryDataContext())
            {
                List<History> history = context.History
                    .GroupBy(grp => grp.ConverterName)
                    .OrderByDescending(item => item.Count())
                    .Take(3)
                    .Select(s => new History
                    {
                        ConverterName = s.Key,
                        id = s.Count()
                    })
                    .ToList();
                return history;
            }
        }
    }
}
