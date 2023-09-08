﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain
{
    public static partial class RegexPatterns
    {
        /// <summary>
        /// Regular expression pattern to validate email addresses
        /// </summary>
        public static readonly Regex EmailIsValid = EmailRegexPatternAttr();
        public static readonly Regex BankAccountNumberIsValid = BankAccountNumberRegexPatternAttr();

        [GeneratedRegex(
            @"^([0-9a-zA-Z]([+\-_.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant)]
        private static partial Regex EmailRegexPatternAttr();

        [GeneratedRegex(
            @"^[0-9]{9,18}$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant)]
        private static partial Regex BankAccountNumberRegexPatternAttr();
    }
}
