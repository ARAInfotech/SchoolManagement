using ConfigManager;
using ConfigManager.Interfaces;
using EmailScheduler;
using EmailScheduler.Interface;
using EmailScheduler.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;

namespace Test.ConsoleApp
{
    class Program
    {
        private static ServiceCollection collection { get; set; }

        public static IConfiguration Configuration { get; set; }

        private static void ConfigurationSetup()
        {
            string path = Directory.GetCurrentDirectory();

            if (path.Contains("\\bin\\"))
            {
                int pos = path.IndexOf("bin");
                path = path.Remove(pos);
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            collection = new ServiceCollection();
            collection.AddSingleton<IConfiguration>(Configuration);
            collection.AddScoped<IConfigurationManager, WebConfigManager>();
            collection.AddScoped<IEmailServices, EmailService>();
        }

        static void Main(string[] args)
        {
            ConfigurationSetup();

            IServiceProvider serviceProvider = collection.BuildServiceProvider();
            var service = serviceProvider.GetService<IEmailServices>();

            try
            {
                List<string> toAddress = new List<string>();
                toAddress.Add("r.ajith869@gmail.com");

                EmailModel model = new EmailModel
                {
                    FromAddress = "donotreply@test.test",
                    Subject = "test",
                    EmailContent = "<b>This is a test mail</b>",
                    ToAddress = toAddress
                };

                service.SendEmail(model);
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
