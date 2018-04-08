using API.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task.Run(async () =>
                {
                    APIClient client = new APIClient("http://localhost:36232/Api/");

                    var result = await client.GetObjectAsync<Person[]>("Values");

                    var properties = typeof(Person).GetProperties();
                    var output = String.Join("\r\n", result.Select(x =>
                                     String.Join(",", properties.Select(f => f.GetValue(x)))
                                 ));

                    Console.WriteLine(output);

                }).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
