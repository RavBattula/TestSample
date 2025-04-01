using System.Diagnostics;
using System.Net.Http;
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
using static System.Net.WebRequestMethods;

namespace WpfAsyncAwaitSample
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

        private List<string> GetWebsites()
        {
            List<string> websites = new List<string>();
            websites.Add("https://www.google.com/");
            websites.Add("https://www.msn.com/");
            websites.Add("https://www.yahoo.com/");
            websites.Add("https://www.amazon.com/");
            websites.Add("https://www.facebook.com/");
            return websites;
        }
        private void btnSync_Click(object sender, RoutedEventArgs e)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            var startTime = Stopwatch.GetTimestamp();
            string retrieveType = "Sync";
            string message = GetWebData(retrieveType);

            txtResult.Text = message;
            //stopwatch.Stop();
            //txtResult.Text += "Time elapsed: " + stopwatch.ElapsedMilliseconds + " ms";
            txtResult.Text += "Time elapsed: " + Stopwatch.GetElapsedTime(startTime).TotalMilliseconds + " ms";
        }

        private string GetWebData(string retrieveType)
        {
            string message = string.Empty;
            message += retrieveType + " operation..." + "\n";
            foreach (var url in GetWebsites())
            {
                string result = new WebApi().Get(url);
                message += string.Concat(url, " length: ", result.Length);
                message += "\n";
            }

            return message;
        }

        private async Task<string> GetWebDataAsync(string retrieveType)
        {
            string message = string.Empty;
            message += retrieveType + " operation..." + "\n";
            foreach (var url in GetWebsites())
            {
                string result = await Task.Run(()=> new WebApi().Get(url));
                message += string.Concat(url, " length: ", result.Length);
                message += "\n";
            }

            return message;
        }

        private async Task<string> GetWebDataTaskParallelAsync(string retrieveType)
        {
            string message = string.Empty;
            message += retrieveType + " operation..." + "\n";
            List<Task<WebResponse>> tasks = new List<Task<WebResponse>>();
            foreach (var url in GetWebsites())
            {
                tasks.Add(new WebApi().GetAsync(url));
            }

            await Task.WhenAll(tasks);
            foreach (var task in tasks)
            {
                message += string.Concat(task.Result.Url + " length: ", task.Result.Result.Length);
                message += "\n";
            }

            return message;
        }

        private async void btnAsync_Click(object sender, RoutedEventArgs e)
        {
            var startTime = Stopwatch.GetTimestamp();
            string retrieveType = "Async";
            string message = await GetWebDataAsync(retrieveType);

            txtResult.Text = message;
            txtResult.Text += "Time elapsed: " + Stopwatch.GetElapsedTime(startTime).TotalMilliseconds + " ms";
        }

        private async void btnAsyncTaskParallel_Click(object sender, RoutedEventArgs e)
        {
            var startTime = Stopwatch.GetTimestamp();
            string retrieveType = "Async task parallel";
            string message = await GetWebDataTaskParallelAsync(retrieveType);

            txtResult.Text = message;
            txtResult.Text += "Time elapsed: " + Stopwatch.GetElapsedTime(startTime).TotalMilliseconds + " ms";
        }
    }

    public class WebApi
    {
        public async Task<WebResponse> GetAsync(string url)
        {
            WebResponse response = new WebResponse();
            response.Url = url;
            using (HttpClient client = new HttpClient())
            {
                response.Result = await client.GetStringAsync(url);
            }

            return response;
        }

        public string Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return client.GetStringAsync(url).Result;
            }
        }
    }

    public class WebResponse
    {
        public string Url { get; set; }
        public string Result { get; set; }
    }
}