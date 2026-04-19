using System.ComponentModel.DataAnnotations;

namespace GoodHamburger.Infrastructure.PostgreSQL.Options;

public class DatabaseOptions
{
    [Required] public string DefaultConnection { get; set; }
}