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
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IConnection _connection;
        private IChannel _channel;
        private ConnectionFactory _factory;
        private bool _isInitialized = false;
        private bool _isReceiverConnected = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task InitRobbitMQFactory()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = await factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            await _channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false,
                arguments: null);
        }

        private async void Sender_Click(object sender, RoutedEventArgs e)
        {
            logger.Items.Add("Sending...");
            if (!_isInitialized)
            {
                await InitRobbitMQFactory();
                _isInitialized = true;
            }

            Random random = new Random();
            string message = $"Hello Ravi!, this is message {random.Next(100)}";
            var body = Encoding.UTF8.GetBytes(message);

            await _channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body);
            logger.Items.Add(message);
            Console.WriteLine($" [x] Sent {message}");
        }

        private async void Receiver_Click(object sender, RoutedEventArgs e)
        {
            logger.Items.Add("Receiving...");
            //var factory = new ConnectionFactory { HostName = "localhost" };
            //using var connection = await factory.CreateConnectionAsync();
            //using var channel = await connection.CreateChannelAsync();

            //await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false,
            //    arguments: null);

            //Console.WriteLine(" [*] Waiting for messages.");
            if (!_isReceiverConnected)
            {
                logger.Items.Add("Waiting for messages...");
                var consumer = new AsyncEventingBasicConsumer(_channel);
                consumer.ReceivedAsync += Consumer_ReceivedAsync;
                await _channel.BasicConsumeAsync("hello", autoAck: true, consumer: consumer);
                _isReceiverConnected = true;
            }
        }

        private Task Consumer_ReceivedAsync(object sender, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            //Console.WriteLine($" [x] Received {message}");
            Dispatcher.Invoke(() =>
            {
                logger.Items.Add($"Received..  {message}");
            });

            //logger.Items.Add(message);
            return Task.CompletedTask;
        }
    }
}