using System.Reflection;
using GoodHamburger.Application.Products.Modules;
using GoodHamburger.Contracts.Products;
using GoodHamburger.Presentation.Orders;
using GoodHamburger.Presentation.Product;

namespace GoodHamburger.Presentation.Api.Extensions;

public static class ModuleExtensions
{
    public static IServiceCollection AddAllApplicationParts(this IServiceCollection services)
    {
        var assemblies = GetAllReferencedAssemblies();

        var mvc = services.AddControllers();

        foreach (var assembly in assemblies)
            mvc.AddApplicationPart(assembly);

        return services.AddAbstractModules();
    }

    private static IServiceCollection AddAbstractModules(this IServiceCollection services)
    {
        return services.AddScoped<IProductModule, ProductModule>();
    }

    private static List<Assembly> GetAllReferencedAssemblies()
    {
        var types = new[]
        {
            //todo: find a way to make this more idiomatic && scalable
            typeof(ProductController),
            typeof(OrderController),
        };

        return types.Select(x => x.GetTypeInfo().Assembly).ToList();
    }
}