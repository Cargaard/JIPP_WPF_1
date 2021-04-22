using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UnitConverter.UsageHistory;
using dbOperations;
namespace UnitConverter.desktop
{
    /// <summary>
    /// Logika interakcji dla klasy Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        ConvertersHistory history;
        int page;
        double pages;
        public Statistics()
        {
            page = 0;
            InitializeComponent();
           
            history = new ConvertersHistory();
            showStatistics();
        }

        private void previousStatisticPage_Click(object sender, RoutedEventArgs e)
        {
            if (page > 0)
                page--;
            else
                return;
            showStatistics();
        }

        private void nextStatisticPage_Click(object sender, RoutedEventArgs e)
        {
            if (page < pages-1)
                page++;
            else
                return;
            showStatistics();
        }
        private void allStatisticsTab_Clicked(object sender, RoutedEventArgs e)
        {
            page = 0;
            showStatistics();
        }
        private void showStatistics()
        {
            List<History> historyList = history.GetAllStatistics(page);
            pages = Math.Ceiling(history.GetStatisticAmount()/20);
            statisticsPages.Text = (page+1).ToString()+"/" + pages.ToString();
            statisticResultField.ItemsSource = historyList;
        }
        private void filtrByPopularityTab_Clicked(object sender, RoutedEventArgs e)
        {
           List<History> historyList =  history.getThreeMostPopularConversions();
            popularityResultField.ItemsSource = historyList;
        }
        private void filtrByDateTab_Clicked(object sender, RoutedEventArgs e)
        {
            statisticResultField.ItemsSource = "test";
        }
    }
}
