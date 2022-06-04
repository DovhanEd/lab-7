using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdventureWorksSalesEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() { }
        private AdventureWorksService.AdventureWorksLTEntities dataServiceClient;
        private System.Data.Services.Client.DataServiceQuery<AdventureWorksService.SalesOrderHeader> salesQuery;
        private CollectionViewSource ordersViewSource;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataServiceClient = new AdventureWorksService.AdventureWorksLTEntities(new Uri("http://localhost:45899/AdventureWorksService.svc"));
            salesQuery = dataServiceClient.SalesOrderHeaders;
            ordersViewSource = ((CollectionViewSource)(this.FindResource("salesOrderHeadersViewSource")));
            ordersViewSource.Source = salesQuery.Execute();
            ordersViewSource.View.MoveCurrentToFirst();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (ordersViewSource.View.CurrentPosition > 0) ordersViewSource.View.MoveCurrentToPrevious();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (ordersViewSource.View.CurrentPosition < ((CollectionView)ordersViewSource.View).Count -1)
            {
                ordersViewSource.View.MoveCurrentToNext();
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            AdventureWorksService.SalesOrderHeader currentOrder = (AdventureWorksService.SalesOrderHeader)ordersViewSource.View.CurrentItem;
            dataServiceClient.UpdateObject(currentOrder);
            dataServiceClient.SaveChanges();
        }
    } 
}
