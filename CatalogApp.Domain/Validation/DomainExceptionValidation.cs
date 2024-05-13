using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error) 
        { 
        }
        
        /// <summary>
        /// Checks if a condition is true, if yes, throws a DomainExceptionValidation
        /// </summary>
        /// <param name="hasError"></param>
        /// <param name="error"></param>
        /// <exception cref="DomainExceptionValidation"></exception>
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExceptionValidation(error);
        }
    }
}
