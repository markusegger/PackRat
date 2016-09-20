using System.Linq;
using System.Text;
using System.Windows;

namespace CODE.PackRat.TestBench.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchPackages(object sender, RoutedEventArgs e)
        {
            var packages = Core.NuGet.SearchRepository(searchTerm.Text.Trim());

            var sb = new StringBuilder();
            foreach (var package in packages)
                sb.AppendLine(package.ToString());

            results.Text = sb.ToString();

            var firstPackage = packages.FirstOrDefault();
            if (firstPackage != null)
                Core.NuGet.GetPackage(firstPackage.Id, firstPackage.Version.ToString());
        }
    }
}
