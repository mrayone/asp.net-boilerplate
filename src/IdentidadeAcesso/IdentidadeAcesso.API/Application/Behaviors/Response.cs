using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IdentidadeAcesso.API.Application.Behaviors
{
    public class Response
    {
        private List<string> _messages;

        public IReadOnlyCollection<string> Errors => _messages;
        public object Result { get; }

        public Response()
        {
            _messages = new List<string>();
        }
        public Response AddError(string message)
        {
            _messages.Add(message);
            return this;
        }
    }
}