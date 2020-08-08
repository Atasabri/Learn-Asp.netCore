using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Models.Attributes
{
    public class EmailDomain : ValidationAttribute
    {
        private readonly string domain;
        public EmailDomain(string Domain)
        {
            this.domain = Domain;
        }

        public override bool IsValid(object value)
        {
            string domainName = value.ToString().Split("@")[1];
            return domainName.ToUpper() == domain.ToUpper();
        }

    }
}
