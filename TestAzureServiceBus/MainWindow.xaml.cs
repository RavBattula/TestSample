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
using Azure.Identity;
using Azure.Messaging.ServiceBus;

namespace TestAzureServiceBus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _serviceBusConnectionString = "Endpoint=sb://ravibattula.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=51dueiMey/iJg1yNUC3GVXtQnA3nu57q1+ASbC6zPUg=";
        private const int NumOfMessages = 3;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //var clientOptions = new ServiceBusClientOptions
            //{
            //    TransportType = ServiceBusTransportType.AmqpWebSockets
            //};

            ServiceBusClient client = new ServiceBusClient(_serviceBusConnectionString);

            //ServiceBusProcessor serviceBusProcessor = client.CreateProcessor("sbqueue_1");

            ServiceBusSender sb_sender = client.CreateSender("sbqueue_1");

            ServiceBusMessageBatch serviceBusMessageBatch  = await sb_sender.CreateMessageBatchAsync();

            for (int i = 0; i < NumOfMessages; i++)
            {
                if(!serviceBusMessageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
                {
                    throw new Exception("The mesage didnot fit {i}");
                }
            }

            try
            {
                await sb_sender.SendMessagesAsync(messageBatch: serviceBusMessageBatch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await sb_sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }

        ServiceBusProcessor serviceBusProcessor;

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var clientOptions = new ServiceBusClientOptions()
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            };

            ServiceBusClient client = new ServiceBusClient(_serviceBusConnectionString, clientOptions);
            serviceBusProcessor = client.CreateProcessor("sbqueue_1", new ServiceBusProcessorOptions());
            try
            {
                serviceBusProcessor.ProcessMessageAsync += MessageHandler;
                serviceBusProcessor.ProcessErrorAsync += ErrorHandler;
                await serviceBusProcessor.StartProcessingAsync();
            }
            finally
            {

            }
        }

        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            MessageBox.Show($"Received: {body}");
            await args.CompleteMessageAsync(args.Message);
        }

        // handle any errors when receiving messages
        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await serviceBusProcessor?.StopProcessingAsync();
        }
    }
}