namespace Metrics_Track.Services.Contracts
{
    using System;
    public interface ITransaction
    {
        int AddTransaction(int loginId, int countryId, int processId, int activityId, int lobId, int divisionId, int towerCategoryId, int towerId, 
                            DateTime receivedDate, DateTime startDate, DateTime completeDate, int statusId, string comment, 
                            string numberId, string partnerId, string contactId, double premium, string currCode, 
                            string insuredName, string tranRequestor, int originalId, short statusCode, short priority,
                            string attachments, DateTime inceptionDate, DateTime dateReceived);
    }
}
