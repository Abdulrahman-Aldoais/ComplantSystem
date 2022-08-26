using System;

namespace ComplantSystem.Models.Benef
{
    internal class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}