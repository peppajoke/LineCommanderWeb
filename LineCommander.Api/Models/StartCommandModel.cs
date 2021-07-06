using System;

namespace LineCommander.Api.Models
{
    public class StartCommandModel
    {
        public Guid SessionId;

        public StartCommandModel()
        {
            SessionId = Guid.NewGuid();
        }
    }
}