using FluentValidator;
using FluentValidator.Validation;
using ProjetoESX.Shared.Commands;

namespace ProjetoESX.Domain.Commands.Inputs
{
    public class EmployeeCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal GrossSalary { get; set; }

        public bool Validator()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Nome é obrigatório")
                .IsEmail(Address, "Email", "E-mail inválido")
                .IsNotNull(GrossSalary, "GrossSalary", "Salário é obrigatório")
            );

            return Valid;
        }
    }
}
