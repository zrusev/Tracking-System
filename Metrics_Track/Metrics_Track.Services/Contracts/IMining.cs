namespace Metrics_Track.Services.Contracts
{
    using Models.Mining;
    using System;
    using System.Collections.Generic;
    public interface IMining
    {
        IEnumerable<MiningModel> ById(int id);
        void AddUserActivity(int id, string type, DateTime stamp, string commment, short sandbox, string version);
    }
}
