using AccountService;
using Grpc.Net.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static AccountService.Account;
using static AccountService.Greeter;

//tim corey into to grpc in c#
namespace AccountClientTestProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // don't forget to work both projects should be set to startup right click on solution -> set startup projects -> multiple . start -> service should start before client
                // would realistically take this from appsettings

                //20/3 this is causing an SSL error now - SSL Connection could not be established, the handshake failed due an unexpected packet
                //using var channel = GrpcChannel.ForAddress("https://localhost:5001");

                // instantiate grpc call
                //var GreetClient = new Greeter.GreeterClient(channel);

                //// builds with using static above, unsure about naming / compiler
                ////var client = new Account.AccountsClient(channel);

                //27-3 see if this boilerplate code fro m the grpc github project still works - YES it works from client (without configure kestrel in service.program.cs)
                // Bloom - error stream removed (without kestrel)
                // try adding kestrel
                // client -> The SSL connection could not be established, see inner exception. {"The handshake failed due to an unexpected packet format."}
                // bloom (localhost:5001) -> works
                // can i call this from quiz app without kestrel? YES!!!
                // so can I set up account to call from here YES!!!
                using var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new Greeter.GreeterClient(channel);
                var reply = await client.SayHelloAsync(
                                  new HelloRequest { Name = "Justin" });
                Console.WriteLine("Greeting: " + reply.Message);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

                var accountClient = new Account.AccountClient(channel);
                var accountresponse = await accountClient.SetUserAsync(
                                  new UserSetRequest { Name = "Justin", EmailAddress = "test@test.com", Password = "Password2@" });
                Console.WriteLine($"SetUserResponse: {accountresponse.Success}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

                ////create hello request
                //var input = new HelloRequest { Name = "Justin " };

                //var reply = await GreetClient.SayHelloAsync(input);

                //Console.WriteLine(reply.Message);

                //var greetRequest = new HelloRequest
                //{
                //    Name = "Justin"
                //};

                //var greetResponse = await GreetClient.SayHelloAsync(greetRequest);

                //no connection could be made because the target machine actively refused it
                //using var accountChannel = GrpcChannel.ForAddress("https://localhost:5002");

                //{"IPv4 address 0.0.0.0 and IPv6 address ::0 are unspecified addresses that cannot be used as a target address. (Parameter 'hostName')"}
                //using var channel = GrpcChannel.ForAddress("http://0.0.0.0:5001");

                //"An error occurred while sending the request." the response ended prematurely
                //using var channel = GrpcChannel.ForAddress("http://localhost:5001");

                // {"Invalid URI: The URI scheme is not valid."}
                //using var channel = GrpcChannel.ForAddress("https://0.0.0.0:5001");
                //var httpHandler = new HttpClientHandler();
                //httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                //SSL error - failed because unexpected packet
                //var channel = GrpcChannel.ForAddress("https://localhost:5001");



                //var accountClient = new Account.AccountClient(channel);

                //var request = new UserSetRequest
                //{
                //    Name = "Justin",
                //    EmailAddress = "justinmarkark@gmail.com",
                //    Password = "Testtest2@"
                //};

                //// service is unimplemented

                //var response = await accountClient.SetUserAsync(request);                

                //Console.WriteLine(response.Success.ToString());
                //Console.ReadKey();

                //Console.WriteLine(response.Success.ToString());
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadLine();
            }            
        }
    }
}
