using Data;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_3._05
{
   
}
public partial class MainWindow : Window
{
    private DBManager dbManager;

    public MainWindow()
    {
        InitializeComponent();
        dbManager = new DBManager();
    }

    private void ShowAllProducts_Click(object sender, RoutedEventArgs e)
    {
        DisplayResults(dbManager.GetAllProducts());
    }

    private void ShowAllSuppliers_Click(object sender, RoutedEventArgs e)
    {
        DisplayResults(dbManager.GetAllSuppliers());
    }

    private void ShowProductDetails_Click(object sender, RoutedEventArgs e)
    {
        DisplayResults(dbManager.GetProductDetails());
    }

    private void ShowType1Products_Click(object sender, RoutedEventArgs e)
    {
        DisplayResults(dbManager.GetProductsByType("Type1"));
    }

    private void ShowSupplier1Products_Click(object sender, RoutedEventArgs e)
    {
        DisplayResults(dbManager.GetProductsBySupplier(1));
    }

    private void ShowHighestCostProduct_Click(object sender, RoutedEventArgs e)
    {
        DisplayResults(dbManager.GetProductWithHighestCost());
    }

    private void ShowLowestQuantityProduct_Click(object sender, RoutedEventArgs e)
    {
        DisplayResults(dbManager.GetProductWithLowestQuantity());
    }

    private void ExecuteCustomQuery_Click(object sender, RoutedEventArgs e)
    {
        DisplayResults(dbManager.ExecuteCustomQuery(SqlQueryTextBox.Text));
    }

    private void DisplayResults(DataTable dt)
    {
        ResultsListBox.ItemsSource = dt.DefaultView;
    }
}
