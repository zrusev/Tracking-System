namespace Metrics_Track.Services.Services
{
    using Metrics_Track.Data.Models;
    using System;
    using System.Collections.Generic;
    public interface IMining
    {
        IEnumerable<MiningDataModel> ById(int id);
        void AddUserActivity(int id, string type, DateTime stamp, string commment, short sandbox, string version);
    }
}
