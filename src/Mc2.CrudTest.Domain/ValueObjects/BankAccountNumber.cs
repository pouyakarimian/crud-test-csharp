using System.Net.Mail;

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

        public static BankAccountNumber Create(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new Exception("The bank account number must be provided.");

            if (!RegexPatterns.BankAccountNumberIsValid.IsMatch(number))
                throw new Exception("The bank account number is not valid");

            return new BankAccountNumber(number);
        }

        public override string ToString() => Number;
    }
}
