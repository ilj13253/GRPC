using GGGYstore.ViewModel;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GGYSTOREe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext=new GameServiceVM();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Привет");
        }
        /*
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        */
        /*
private void DataGrid_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
{

}
*/
    }
}
/*
public class VM
{
    public List<GameModel>List {get;set;}=[
                new()
                {
                    Id=1,Title="Batman",Description="Крутая игра",Publisher="Sony",DateRelease=new DateOnly(2009,10,10)
                }
            ];
}
*/
/*
public class GameModel
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("publisher")]
    public required string Publisher { get; set; }

    [JsonPropertyName("dateRelease")]
    public required DateOnly DateRelease { get; set; }
    /*
    public override string ToString() =>
        $"Id: {Id}, Title: {Title}, Description: {Description}, Publisher: {Publisher}, DateRelease: {DateRelease.ToString("D")}";
    
}
*/