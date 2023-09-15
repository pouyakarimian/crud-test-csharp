using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Infrastructure.AppSettings;

public sealed class ConnectionOptions : IAppOptions
{
    private const StringComparison ComparisonType = StringComparison.InvariantCultureIgnoreCase;

    [Required]
    public string SqlConnection { get; private init; }

    [Required]
    public string NoSqlConnection { get; private init; }
    
    [Required]
    public string DatabaseName { get; private init; }

    static string IAppOptions.ConfigSectionPath => "ConnectionStrings";
}