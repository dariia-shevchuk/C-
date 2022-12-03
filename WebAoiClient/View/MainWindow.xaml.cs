using System.Windows;
using WebAoiClient.VirwModel;

namespace WebAoiClient.View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = new MainWindowVirwModel();
        InitializeComponent();
    }
}