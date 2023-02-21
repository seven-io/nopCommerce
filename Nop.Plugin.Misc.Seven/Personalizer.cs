using System.Linq;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;

namespace Nop.Plugin.Misc.Seven {
    public class Personalizer {
        #region Ctor

        public Personalizer(string text) {
            Text = text;
            HasPlaceholders = IsPersonalized(Text);
        }

        #endregion

        #region Fields

        public string Text { get; private set; }
        public bool HasPlaceholders { get; }

        public static bool IsPersonalized(string text) {
            return Placeholders.Any(placeholder => text.Contains(ToPlaceholder(placeholder)));
        }

        private static readonly string[] CustomerPlaceholders = {
            "Email",
            "Username"
        };

        private static readonly string[] AddressPlaceholders = {
            "Address.Address1",
            "Address.Address2",
            "Address.City",
            "Address.Company",
            "Address.County",
            "Address.FaxNumber",
            "Address.FirstName",
            "Address.LastName",
            "Address.PhoneNumber",
            "Address.ZipPostalCode"
        };

        public static readonly string[] Placeholders = CustomerPlaceholders.Concat(AddressPlaceholders).ToArray();

        #endregion

        #region Methods

        private static string ToPlaceholder(string placeholder) {
            return "{{" + placeholder + "}}";
        }

        public string Transform(Customer customer, Address address) {
            return Address(address, Customer(customer, Text));
        }
        
        private string Customer(Customer customer, string text) {
            return CustomerPlaceholders.Aggregate(text, (current, placeholder) => {
                var oldValue = ToPlaceholder(placeholder);

                if (!current.Contains(oldValue)) {
                    return current;
                }

                var newValue = customer.GetType().GetProperty(placeholder)?.GetValue(customer)?.ToString();

                return "" == newValue ? current : current.Replace(oldValue, newValue);
            });
        }

        private string Address(Address address, string text) {
            return AddressPlaceholders.Aggregate(text, (current, placeholder) => {
                var oldValue = ToPlaceholder(placeholder);

                if (!current.Contains(oldValue)) {
                    return current;
                }

                var newValue = address.GetType()
                    .GetProperty(placeholder.Split(".").Last())
                    ?.GetValue(address)?.ToString();

                return "" == newValue ? current : current.Replace(oldValue, newValue);
            });
        }

        #endregion
    }
}