using Microsoft.Extensions.DependencyInjection;
using UltraLogger.Core.Application.Common;
using UltraLogger.Core.Application.Services;
using UltraLogger.Core.Domain.Aggregates.Customers;
using UltraLogger.Core.Domain.Aggregates.Defectograms;
using UltraLogger.Core.Domain.Aggregates.Evaluations;
using UltraLogger.Core.Domain.Aggregates.Orders;
using UltraLogger.Core.Domain.Aggregates.Plates;
using UltraLogger.Core.Domain.Aggregates.Reports;
using UltraLogger.Core.Domain.Aggregates.Users;
using UltraLogger.Core.Domain.Aggregates.USTModes;
using UltraLogger.Core.Domain.Aggregates.UTResults;
using UltraLogger.Infrastructure;
using UltraLogger.Infrastructure.Data;
using UltraLogger.Infrastructure.Repositories;
using UltraLogger.UI;

namespace UltraLogger.Core
{
    internal static class Extensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IDbConnectionFactory>(_ => new SQLiteConnectionFactory("UltraLogger.db"));
            services.AddSingleton<UnitOfWork>();
            services.AddSingleton<ISessionManager, SessionManager>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUSTModeRepository, USTModeRepository>();
            services.AddTransient<IDefectogramRepository, DefectogramRepository>();
            services.AddTransient<IPlateRepository, PlateRepository>();
            services.AddTransient<IUTResultRepository, UTResultRepository>();
            services.AddTransient<IEvaluationRepository, EvaluationRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IAdministratorPasswordManager, AdministratorPasswordManager>();
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<AuthenticationService>();
            services.AddTransient<DefectogramService>();
            services.AddTransient<CustomerService>();
            services.AddTransient<OrderService>();
            services.AddTransient<ReportService>();
            services.AddTransient<AdministratorService>();
            services.AddTransient<PlateService>();
        }

        public static void AddUIServices(this IServiceCollection services)
        {
            services.AddTransient<MainForm>();
        }
    }
}
