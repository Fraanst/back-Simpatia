using Flunt.Notifications;
using Flunt.Validations;
using MediatR;

namespace Simpatia.Domain.shared.commands
{
    public class CommandRequest: Notifiable, IRequest<CommandResponse>, IValidatable
    {
        public virtual void Validate()
        {

        }
    }
}
