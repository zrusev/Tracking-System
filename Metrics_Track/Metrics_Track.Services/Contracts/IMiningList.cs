namespace Metrics_Track.Services.Contracts
{
    using Models.Mining;
    using System.Collections.Generic;

    public interface IMiningList
    {
        IEnumerable<MiningModel> All();

        MiningModel ById(int id);

        int UpdateMining(MiningModel model);

        int AddMining(MiningModel model);

        void RemoveMining(int id);

        int[] Ids(int id);

        void UpdateIds(int idCountry, int[] ids);
    }
}
