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
