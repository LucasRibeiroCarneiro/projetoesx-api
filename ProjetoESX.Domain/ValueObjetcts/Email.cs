using FluentValidator;
using FluentValidator.Validation;

namespace ProjetoESX.Domain.ValueObjetcs
{
    public class Email : Notifiable
    {
        protected Email() { }

        public Email(string address)
        {
            Address = address;

            DefineValidation();
        }

        public string Address { get; private set; }

        private void DefineValidation()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "E-mail inválido")
            );
        }

        public override string ToString()
        {
            return Address;
        }
    }
}