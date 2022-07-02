using System.Windows;

namespace WpfBuildWithSquirrel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel("https://github.com/CleberRangel/cleber.portfolio");
        }


    }
}
