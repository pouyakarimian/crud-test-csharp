using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Web.Host.AppSettings;

public sealed class ConnectionOptions : IAppOptions
{
    private const StringComparison ComparisonType = StringComparison.InvariantCultureIgnoreCase;

    [Required]
    public string SqlConnection { get; private init; }

    [Required]
    public string NoSqlConnection { get; private init; }

    static string IAppOptions.ConfigSectionPath => "ConnectionStrings";
}