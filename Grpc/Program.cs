using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace Grpc
{
    class Program
    {
        static async Task Main(string[] args)
        {
           // Console.Write("Enter your ID:");
            //int id = Convert.ToInt32(Console.ReadLine());

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new Student.StudentClient(channel);
            //using (var call= client.GetAllStudents(new StudentAllLoopUp()))
            //{

            //  while(await call.ResponseStream.MoveNext())
            //{
            //  var reply = call.ResponseStream.Current;
            //Console.WriteLine($"{reply.User.Id}-{reply.User.Id}-{reply.User.Name}-{reply.User.Surname},{(reply.User.Gender ? "Male" : "Female")}with Gpa={reply.Gpa}");

            //                }

            var client = new Category.ProductClient(channel);
            using (var call=client.GetAllProducts(new CategoryAllLookUp())) { 
            
            while(await call.ResponseStream.MoveNext())
                {
                    var reply = call.ResponseStream.Current;

                    Console.WriteLine($"{reply.User.id}-{reply.User.name}--{reply.User.parentCategoryId}with Description{reply.description}--{reply.price}");
                }
                    }

        }
    }
}
