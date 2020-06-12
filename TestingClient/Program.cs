using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using SharedLibrary.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TestingClient
{
    class Program
    {
        private static IEnumerable<MethodInfo> _methodNames;
        private static DiscoveryDocumentResponse _discoveryDocumentResponse;
        private static TokenResponse _tokenResponse;

        static void Main(string[] args)
        {
            _methodNames = typeof(Program).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            _tokenResponse = new TokenResponse();
            Console.WriteLine("Your options:");
            PrintMethods();
            Console.WriteLine("Write the function name you want to execute...");
            ExecuteCommand(Console.ReadLine());
        }

        private static void ExecuteCommand(string command)
        {
            foreach (var method in _methodNames)
            {
                if(command == nameof(ExecuteCommand) || command == nameof(Main))
                {
                    Console.WriteLine("Can't use this command. Try another");
                    ExecuteCommand(Console.ReadLine());
                    break;
                }   

                if (method.Name == command)
                {
                    method.Invoke(null, null);
                    break;
                }
            }
            Console.WriteLine("Next command:");
            ExecuteCommand(Console.ReadLine());
        }

        private async static void Discover()
        {
            try
            {
                using (var client = new HttpHandler())
                {
                    Console.WriteLine("Retreiving the discovery document...");
                    _discoveryDocumentResponse = await client.GetDiscoveryDocumentAsync();
                    if (_discoveryDocumentResponse.IsError)
                    {
                        Console.WriteLine(_discoveryDocumentResponse.Error);
                        return;
                    }

                    Console.WriteLine(_discoveryDocumentResponse.Raw);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private static void PrintMethods()
        {
            foreach (var method in _methodNames)
            {
                Console.WriteLine(method.Name);
            }
        }

        private async static void RequestToken()
        {
            try
            {
                using (var client = new HttpHandler())
                {
                    _tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                    {
                        Address = _discoveryDocumentResponse.TokenEndpoint,

                        ClientId = "client",
                        ClientSecret = "secret",
                        Scope = "api1"
                    });

                    if (_tokenResponse.IsError)
                    {
                        Console.WriteLine(_tokenResponse.Error);
                        return;
                    }

                    Console.WriteLine(_tokenResponse.Json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async static void CallIdentityController()
        {
            try
            {
                using (HttpHandler client = new HttpHandler(_tokenResponse.AccessToken))
                {
                    var response = await client.GetAsync("identity");
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.StatusCode);
                    }
                    else
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(JArray.Parse(content));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
