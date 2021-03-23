using Flunt.Notifications;
using Simpatia.Domain.shared.commands;

namespace Simpatia.Domain.shared.Handlers
{
    public class CommandHandler : Notifiable
    {
        public CommandResponse CreateResponse(object result, string message)
        {
            var data = new CommandResponse(result);
            data.StatusCode = 201;
            data.Message = message;
            return data;
        }

        // Ok
        public CommandResponse OkResponse(object result, string message)
        {
            var data = new CommandResponse(result);
            data.StatusCode = 200;
            data.Message = message;
            return data;
        }

        // parâmentros inválidos
        public CommandResponse BadRequestResponse(object errors, string message)
        {
            var data = new CommandResponse(errors);
            data.StatusCode = 400;
            data.Message = message;
            return data;
        }

        // erro interno
        public CommandResponse InternalServerErrorResponse(object errors, string message)
        {
            var data = new CommandResponse(errors);
            data.StatusCode = 500;
            data.Message = message;
            return data;
        }
    }
}
