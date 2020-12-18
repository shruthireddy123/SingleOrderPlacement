using Microsoft.Extensions.DependencyInjection;
using System;

namespace OrderPlacement
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IService, Service>()
                .AddSingleton<IOrder, Order>()
                .BuildServiceProvider();

            var orderService = serviceProvider.GetService<Order>();
            orderService.PlaceOrder(1, 2, "1234567891234567");
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
