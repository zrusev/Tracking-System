namespace Metrics_Track.Services.Contracts
{
    using Models.Lob;
    using System.Collections.Generic;

    public interface ILobList
    {
        IEnumerable<LobModel> All();

        LobModel ById(int id);

        int UpdateLob(LobModel model);

        int AddLob(LobModel model);

        void RemoveLob(int id);

        int[] Ids(int id);

        void UpdateIds(int idProcess, int[] ids);
    }
}
