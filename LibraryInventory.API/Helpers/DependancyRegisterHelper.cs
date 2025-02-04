using LibraryInventory.Data.Audit;
using LibraryInventory.Data.Audit.Interfaces;
using LibraryInventory.Data.Repositories;
using LibraryInventory.Data.Repositories.Interfaces;
using LibraryInventory.Service;
using LibraryInventory.Service.Interfaces;

namespace LibraryInventory.API.Helpers
{
    public static class DependancyRegisterHelper
    {
        public static void RegisterDependancies(IServiceCollection services)
        {
            // Audit
            services.AddScoped<IUserContext, UserContext>();

            // Services
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ITransactionService, TransactionService>();

            // Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
