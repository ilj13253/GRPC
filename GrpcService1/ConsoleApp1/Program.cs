using ConsoleApp1;
using Grpc.Net.Client;


// создаем канал для обмена сообщениями с сервером
// параметр - адрес сервера gRPC
using var channel = GrpcChannel.ForAddress("https://localhost:7062");
// создаем клиент
var client = new GreeterClient.GreeterClientClient(channel);
Console.Write("Введите имя: ");
var name = Console.ReadLine();
// обмениваемся сообщениями с сервером
var helloreply = await client.SayHelloAsync(new HelloRequest { Name = name });
Console.WriteLine($"Ответ сервера: {helloreply.Message}");
var goodbyereply = await client.SayGoodbyeAsync(new GoodbyeRequest { Name = name });
Console.WriteLine($"Ответ сервера: {goodbyereply.Message}");
Console.ReadKey();