using System;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.ValidationAttributes
{
    public class DateNotInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime >= DateTime.Now.AddMinutes(-5);
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "The selected date and time cannot be in the past.";
        }
    }
}