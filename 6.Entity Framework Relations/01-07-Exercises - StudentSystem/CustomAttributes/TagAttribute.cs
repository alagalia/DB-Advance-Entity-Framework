using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TagAttribute :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string tagName = (string)value;
            if (tagName.Length > 20)
            {
                throw new ArgumentException("Tag`s lenght is more than 20 symbols long");
            }
            if (Regex.IsMatch(tagName, "\\s"))
            {
                throw new ArgumentException("Tag contains white space/s!");
            }
            if (!tagName.StartsWith("#"))
            {
                throw new ArgumentException("Tag does not start with #!");
            }
            return true;
        }
    }
}
