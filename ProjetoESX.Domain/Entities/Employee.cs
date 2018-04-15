using FluentValidator;
using FluentValidator.Validation;
using ProjetoESX.Domain.ValueObjetcs;

namespace ProjetoESX.Domain.Entities
{
    public class Employee : Notifiable
    {
        protected Employee() { }

        public Employee(string name, Email email, decimal grossSalary)
        {
            Name = name;
            Email = email;
            GrossSalary = grossSalary;

            DefineValidation();
        }

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public decimal GrossSalary { get; private set; }

        public decimal Tax
        {
            get
            {
                var tax = 0;

                //Salários abaixo de R$ 3.000,00 serão isentos                
                if (GrossSalary < 3000)
                {
                    tax = 0;
                }
                //Para salários de R$ 3.000,00 à R$ 5.000,00 teremos 10% de impostos
                else if (GrossSalary >= 3000 && GrossSalary < 5000.01m)
                {
                    tax = 10;
                }
                //Para salários de R$ 5.000,00 à R$ 7.000,00 teremos 15% de impostos
                else if (GrossSalary >= 5000 && GrossSalary < 7000.01m)
                {
                    tax = 15;
                }
                //Para salários acima R$ 7.000,00 teremos 25% de impostos
                else if (GrossSalary > 7000)
                {
                    tax = 25;
                }

                return tax;
            }
        }

        public decimal NetSalary
        {
            get
            {
                var netSalary = GrossSalary;

                if (Tax > 0)
                    netSalary -= GrossSalary * (Tax / 100);

                return netSalary;
            }
        }

        private void DefineValidation()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Nome é obrigatório")
                .IsNotNull(GrossSalary, "GrossSalary", "Salário é obrigatório")
            );
        }

        public override string ToString()
        {
            return $"{Name} ({Email.Address})";
        }
    }
}
