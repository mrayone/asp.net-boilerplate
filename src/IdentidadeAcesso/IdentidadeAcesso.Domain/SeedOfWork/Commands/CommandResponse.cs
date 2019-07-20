using System.Collections.Generic;

namespace IdentidadeAcesso.Domain.SeedOfWork
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse { Success = true };
        public static CommandResponse Fail = new CommandResponse { Success = false };

        private List<string> _messages;

        public IReadOnlyCollection<string> Errors => _messages;

        public CommandResponse()
        {
            _messages = new List<string>();
        }

        public CommandResponse AddError(string message)
        {
            _messages.Add(message);
            Success = false;
            return this;
        }
        public bool Success { get; private set; }
    }
}