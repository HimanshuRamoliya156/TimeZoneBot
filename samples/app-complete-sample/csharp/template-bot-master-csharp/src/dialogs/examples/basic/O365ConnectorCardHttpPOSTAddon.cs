using Microsoft.Bot.Schema.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.Teams.TemplateBotCSharp.src.dialogs.examples.basic
{
    public class O365ConnectorCardHttpPOSTAddon : O365ConnectorCardHttpPOST
    {
        public string Date
        {
            get;
            set;
        }
        public string TimeZone
        {
            get;
            set;
        }
        // create constructor 
        public O365ConnectorCardHttpPOSTAddon(string type = null, string name = null, string id = null, string body = null)
           : base(type, name, id)
        {
            Body = body;
        }
    }
}