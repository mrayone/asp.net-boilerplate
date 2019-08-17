using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.CrossCutting.Identity.Options
{
    public class AppOptions
    {
        public AppOptions()
        {
            SendGridKey = "";
        }
        public string SendGridKey { get; set; }
    }
}
