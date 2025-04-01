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

namespace TestWpfSample
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

        private void GetRenderTier_Click(object sender, RoutedEventArgs e)
        {
            int renderTier = (RenderCapability.Tier >> 16);
            if (renderTier == 0)
            {
                MessageBox.Show("Tier is 0, No graphics hardware acceleration");
            }
            else if (renderTier == 1)
            {
                MessageBox.Show("Tier is 1, Partial graphics hardware acceleration");
            }
            else if (renderTier == 2)
            {
                MessageBox.Show("Tier is 2, Most graphics hardware acceleration");
            }
            else if (renderTier == 3)
            {
                MessageBox.Show("Tier is 3, All graphics hardware acceleration");
            }
        }
    }
}