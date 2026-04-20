using System.Reflection;
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

        return services;
    }
    

    private static List<Assembly> GetAllReferencedAssemblies()
    {
        var types = new List<Type>()
        {
            typeof(ProductController),
            typeof(OrderController)
        };

        return types.Select(x => x.GetTypeInfo().Assembly).ToList();
    }
}