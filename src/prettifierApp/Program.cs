using Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using PrettifierService;
using System;

namespace prettifierApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<INumberValidator, NumberValidator>();
            services.AddScoped<INumberPrettifier, Prettifier>();
            services.AddSingleton<IPrettifierService>(
                s => new PrettifierService.PerttifierService(s.GetService<INumberValidator>(),
                    s.GetService<INumberPrettifier>()));
            
            IServiceProvider provider = services.BuildServiceProvider();
            var prettifierService = provider.GetService<IPrettifierService>();

            Console.WriteLine("Please enter a number to prettify (Q or q to quit): ");
            var input = Console.ReadLine();
            if (string.Equals(input, "q", StringComparison.CurrentCultureIgnoreCase)) return;
            bool endApp = false;
            
            while (!endApp)
            {
                try
                {
                    double aNumber;
                    if (double.TryParse(input, out aNumber))
                    {
                        var result = prettifierService.Prettify(aNumber);
                        if (!string.Equals(result.StatusMessage, "Success", StringComparison.CurrentCultureIgnoreCase))
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(result.StatusMessage);
                            Console.WriteLine("Please try again ^_^");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.WriteLine(result.PrettifiedResult);
                            Console.WriteLine(
                                "--------------------------------------------------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not a number, please try again");
                        Console.WriteLine("------ *************************************************************** ---------");
                    }
                   
                    input = Console.ReadLine();
                    if (input == "Q" || input == "q") endApp = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }

            return;
        }
    }
}
