using System;
using System.Text.Json;

namespace dotnet.jsonserializeroptionsperformance
{
    class Program
    {
        class MessageItem
        {
            public string Message { get; set; }
            public string Message2 { get; set; }
            public string Message3 { get; set; }
            public string Message4 { get; set; }
            public string Message5 { get; set; }

        }

        static void Main(string[] args)
        {

            var start = DateTime.Now;
            var data = new MessageItem { Message = "simple message" };
            for (var i = 0; i < 100000; i++)
            {
                var dataStr = JsonSerializer.Serialize(data, new JsonSerializerOptions { IgnoreNullValues = true });
            }
            Console.WriteLine($"Slow Looup took: {DateTime.Now - start}");


            start = DateTime.Now;
            var options = new JsonSerializerOptions { };
            for (var i = 0; i < 100000; i++)
            {
                var dataStr = JsonSerializer.Serialize(data, options);
            }
            Console.WriteLine($"Fast Loop Took: {DateTime.Now - start}");
            Console.ReadLine();
            return;
        }
    }
}
