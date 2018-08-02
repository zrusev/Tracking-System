namespace Metrics_Track.Services.Contracts
{
    using Models.Division;
    using System.Collections.Generic;
    public interface IDivisionList
    {
        IEnumerable<DivisionModel> All();

        DivisionModel ById(int id);

        int UpdateDivision(DivisionModel model);

        int AddDivision(DivisionModel model);

        void RemoveDivision(int id);

        int[] Ids(int id);

        void UpdateIds(int idProcess, int[] ids);
    }
}
