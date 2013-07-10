using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Finan
{
    public class Validator
    {
        private IBankCodeService _service;
        public Validator() : this(new BankCodeService())
        {

        }

        public Validator(IBankCodeService service)
        {
            _service = service;
        }

        /// <summary>
        /// - Landcode (2 letters)
        /// - 2 controle cijfers
        /// - Bank code
        /// - Rekeningnummer of rekening identificatie
        /// </summary>
        /// <param name="iban"></param>
        /// <returns></returns>
        public bool Validate(string iban)
        {
            if (!new Regex("^[a-zA-Z]{2}[0-9]{2}.*").IsMatch(iban))
            {
                return false;
            }

            if (!_service.Contains(iban.Substring(4, 4)))
            {
                return false;
            }

            return true;
        }
    }
}
