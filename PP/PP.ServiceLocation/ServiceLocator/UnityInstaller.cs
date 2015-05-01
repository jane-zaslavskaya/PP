using Microsoft.Practices.Unity;
using PP.BL.Implementation;
using PP.BL.Interfaces;

namespace PP.ServiceLocation.ServiceLocator
{
    public static class UnityInstaller
    {
        public static void Install(UnityContainer container)
        {
            //container.RegisterType<DbContext, SpaContext>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(IAuthBl), typeof(AuthBl));
            //container.RegisterType(typeof(IBaseService<>), typeof(BaseService<>));
            //container.RegisterType(typeof(IAccountRepository), typeof(AccountRepository));
            //container.RegisterType(typeof(IAccountService), typeof(AccountService));
            //container.RegisterType(typeof(ITestRepository), typeof(TestRepository));
            //container.RegisterType(typeof(ITestService), typeof(TestService));
        }
    }
}