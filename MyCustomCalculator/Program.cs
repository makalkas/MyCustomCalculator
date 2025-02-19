/* Author: Michael kalkas
     * Date  : 11/12/2024
     * Notes: This is an ok application but it contains too much of the logic in the form. The object CalculationStateFactory
     * is not designed properly to handl the logic that should be in it. For this reason it doesn't compleatly conform to the
     * SOLID & DRY principles.
*/
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace MyCustomCalculator
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<StandardForm>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }


        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<OperationFactory>();
                    services.AddSingleton<CalculationStateFactory>();
                    services.AddSingleton<StateKeeper>();
                    services.AddTransient<StandardForm>();


                });
        }
    }
}
