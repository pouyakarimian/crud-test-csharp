namespace Mc2.CrudTest.Domain.ValueObjects;

public sealed record Email
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Email"/> class.
    /// </summary>
    /// <param name="address">The email address.</param>
    private Email(string address) =>
        Address = address.ToLowerInvariant().Trim();

    /// <summary>
    /// Default constructor for EF/ORM.
    /// </summary>
    public Email() { }

    /// <summary>
    /// Gets the email address.
    /// </summary>
    public string Address { get; }

    /// <summary>
    /// Creates a new <see cref="Email"/> instance.
    /// </summary>
    /// <param name="emailAddress">The email address to create.</param>
    public static bool Create(string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress))
            throw new Exception("The e-mail address must be provided.");

        return !RegexPatterns.EmailIsValid.IsMatch(emailAddress)
            ? false
            : true;
    }

    /// <summary>
    /// Returns a string that represents the current <see cref="Email"/> object.
    /// </summary>
    /// <returns>A string that represents the current <see cref="Email"/> object.</returns>
    public override string ToString() => Address;
}