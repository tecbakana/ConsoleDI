using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDependecyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistroInstanciaDemo();
            Console.ReadLine();
        }

        private static void RegistroInstanciaDemo()
        {
            var instancia = new MyFirstInstance { Valor = 44 };
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(instancia);

            foreach(ServiceDescriptor service in services)
            {
                if(service.ServiceType==typeof(MyFirstInstance))
                {
                    var instanciaRegistrada = (MyFirstInstance)service.ImplementationInstance;
                    Console.WriteLine($"Instancia registrada: {instanciaRegistrada.Valor}");
                }
            }

            var serviceProvider = services.BuildServiceProvider();
            var minhaInstancia = serviceProvider.GetService<MyFirstInstance>();

            Console.WriteLine($"Serviço registrado pelo registro de instancia: {minhaInstancia.Valor}");

        }
    }
}
