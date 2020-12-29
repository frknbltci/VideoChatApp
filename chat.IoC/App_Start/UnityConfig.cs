using chat.CORE.Entities;
using chat.DATA.GenericRepository;
using chat.DATA.UnitofWork;
using chat.SERVICES.Interfaces.Employee;
using chat.SERVICES.Services.Employee;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;
using chat.SERVICES.Interfaces;
using chat.SERVICES.Services.Admin;
using chat.SERVICES.Interfaces.Admin;
using chat.SERVICES.Interfaces.Customer;
using chat.SERVICES.Services.Customer;
using chat.SERVICES.Services;

namespace chat.IoC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.BindInRequestScope<IUnitofWork, UnitofWork>();
            container.BindInRequestScope<IAdminUserService, AdminUserService>();
            container.BindInRequestScope<IEmployeeUserService, EmployeeUserService>();
            container.BindInRequestScope<ICustomerUserService, CustomerUserService>();
            container.BindInRequestScope<ITimeLineService, TimeLineService>();
            container.BindInRequestScope<IMessageEmpAdminService, MessageEmpAdminService>();
            container.BindInRequestScope<IMessageCusAdminService, MessageCusAdminService>();
            container.BindInRequestScope<IFavoritesService, FavoritesService>();
            container.BindInRequestScope<IPoolBanService, PoolBanService>();
            container.BindInRequestScope<ICustomerPaymentService, CustomerPaymentService>();
            container.BindInRequestScope<IPayChartService, PayChartService>();
            container.BindInRequestScope<IEmployeeUserService, EmployeeUserService>();
            container.BindInRequestScope<IMessagesService, MessagesService>();
            container.BindInRequestScope<IPaymentService, PaymentService>();

            container.BindInRequestScope<IGenericRepository<AdminUser>, GenericRepository<AdminUser>>();
            container.BindInRequestScope<IGenericRepository<Payment>, GenericRepository<Payment>>();
            container.BindInRequestScope<IGenericRepository<CustomerPayment>, GenericRepository<CustomerPayment>>();
            container.BindInRequestScope<IGenericRepository<MessageEmpAdmin>, GenericRepository<MessageEmpAdmin>>();
            container.BindInRequestScope<IGenericRepository<MessageCusAdmin>, GenericRepository<MessageCusAdmin>>();
            container.BindInRequestScope<IGenericRepository<Customer>, GenericRepository<Customer>>();
            container.BindInRequestScope<IGenericRepository<Employee>, GenericRepository<Employee>>();
            container.BindInRequestScope<IGenericRepository<PoolBan>, GenericRepository<PoolBan>>();
            container.BindInRequestScope<IGenericRepository<Favorites>, GenericRepository<Favorites>>();
            container.BindInRequestScope<IGenericRepository<Gender>, GenericRepository<Gender>>();
            container.BindInRequestScope<IGenericRepository<GenderChoice>, GenericRepository<GenderChoice>>();
            container.BindInRequestScope<IGenericRepository<TimeLine>, GenericRepository<TimeLine>>();
            container.BindInRequestScope<IGenericRepository<Status>, GenericRepository<Status>>();
            container.BindInRequestScope<IGenericRepository<HairColors>, GenericRepository<HairColors>>();
            container.BindInRequestScope<IGenericRepository<HairTypes>, GenericRepository<HairTypes>>();
            container.BindInRequestScope<IGenericRepository<EyeColors>, GenericRepository<EyeColors>>();
            container.BindInRequestScope<IGenericRepository<BodyTypes>, GenericRepository<BodyTypes>>();
            container.BindInRequestScope<IGenericRepository<PayChart>, GenericRepository<PayChart>>();
            container.BindInRequestScope<IGenericRepository<Messages>, GenericRepository<Messages>>();

        }

        public static void BindInRequestScope<T1, T2>(this IUnityContainer container) where T2 : T1
        {
            container.RegisterType<T1, T2>(new HierarchicalLifetimeManager());
        }
    }
}