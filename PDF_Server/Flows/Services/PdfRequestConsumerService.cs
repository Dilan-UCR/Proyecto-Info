using Microsoft.Extensions.DependencyInjection;
using Confluent.Kafka;
using PDF_Server.Flows.DTOs;
using PDF_Server.Flows.Services.Interfaces;
using System.Text.Json;

namespace PDF_Server.Flows.Services
{
    public class PdfRequestConsumerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public PdfRequestConsumerService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"],
                GroupId = "pdf_server_consumer",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe(_configuration["Kafka:PdfRequestTopic"]);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var result = consumer.Consume(stoppingToken);
                    var request = JsonSerializer.Deserialize<PdfRequestDto>(result.Message.Value);
                    Console.WriteLine($"Recibido: {JsonSerializer.Serialize(request)}");
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var pdfGenerator = scope.ServiceProvider.GetRequiredService<IPdfGenerator>();
                        await pdfGenerator.GenerateCustomerReportsAsync(request);
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                }
            }
        }
    }
}
