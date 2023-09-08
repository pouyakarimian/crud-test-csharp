namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class BankAccountNumber
    {

        private BankAccountNumber(string number) =>
            Number = number.Trim();

        /// <summary>
        /// Default constructor for EF/ORM.
        /// </summary>
        public BankAccountNumber() { }

        public string Number { get; }

        public static bool Create(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new Exception("The bank account number must be provided.");

            return !RegexPatterns.BankAccountNumberIsValid.IsMatch(number)
                ? false
                : true;
        }

        public override string ToString() => Number;
    }
}
