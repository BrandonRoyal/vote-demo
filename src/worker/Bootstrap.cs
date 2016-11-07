using SimpleInjector;
using Vote.Worker.Providers;
using Vote.Worker.Repositories;

namespace Vote.Worker
{
    public class Bootstrap
    {
        public static Container Container;
        public static void Start()
        {
            Container = new Container();

            //register dependencies
            Container.Register<IConfigProvider, ConfigProvider>(Lifestyle.Singleton);
            Container.Register<IMessageQueueProvider, RabbitMqProvider>(Lifestyle.Singleton);
            Container.Register<IDbProvider, PostgresProvider>(Lifestyle.Singleton);
            Container.Register<IDataRepository, DataRepository>(Lifestyle.Singleton);

            //Container.Verify();
        }
    }
}