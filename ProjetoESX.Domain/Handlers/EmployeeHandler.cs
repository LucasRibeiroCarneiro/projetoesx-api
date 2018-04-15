using FluentValidator;
using ProjetoESX.Domain.Entities;
using ProjetoESX.Domain.ValueObjetcs;
using ProjetoESX.Shared.Commands;
using ProjetoESX.Domain.Commands.Inputs;
using ProjetoESX.Domain.Commands.Output;

namespace ProjetoESX.Domain.Handlers
{
    public class EmployeeHandler : Notifiable, ICommandHandler<EmployeeCommand>
    {
        public ICommandResult Handle(EmployeeCommand command)
        {
            var email = new Email(command.Address);
            var employee = new Employee(command.Name, email, command.GrossSalary);

            AddNotifications(email.Notifications);
            AddNotifications(employee.Notifications);

            if (Invalid)
                return new CommandResult(false, "Verifique as notificações!", Notifications);

            var data = new
            {
                Name = employee.ToString(),
                GrossSalary = employee.GrossSalary,
                Tax = employee.Tax,
                NetSalary = employee.NetSalary
            };
            return new CommandResult(true, "Cálculo realizado com sucesso!", data);
        }
    }
}
