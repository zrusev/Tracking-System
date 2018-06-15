namespace Metrics_Track.Services.Contracts
{
    using Models.Lob;
    using System.Collections.Generic;

    public interface ILob
    {
        IEnumerable<LobListModel> All();

        LobListModel ById(int id);

        int UpdateLob(LobListModel model);

        void RemoveLob(int id);

        int AddPLob(LobListModel model);
    }
}
