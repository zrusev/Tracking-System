namespace Metrics_Track.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Common.Validation;
    using Contracts;
    using Data.Models;
    using Models.Lob;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Lob : ILob
    {
        private readonly TrackerDbContext db;

        public Lob(TrackerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<LobListModel> All()
            => this.db
                .TblLob
                .OrderBy(l => l.Lob)
                .ProjectTo<LobListModel>()
                .ToList();

        public LobListModel ById(int id)
            => this.db
                .TblLob
                .Where(i => i.IdLob == id)
                .ProjectTo<LobListModel>()
                .FirstOrDefault();

        public int UpdateLob(LobListModel model)
        {
            var lob = this.db
                .TblLob
                .Where(i => i.IdLob == model.IdLob)
                .FirstOrDefault();

            lob.Lob = model.Lob;
            lob.MmcpLob = model.MmcpLob;
            lob.MmcpSegment = model.MmcpSegment;
            lob.ProductLine1 = model.ProductLine1;
            lob.ProductLine2 = model.ProductLine2;
            lob.ProductLine3 = model.ProductLine3;
            lob.SpphIdProduct = model.SpphIdProduct;

            this.db.TblLob.Update(lob);
            this.db.SaveChanges();

            return lob.IdLob;
        }

        public int AddLob(LobListModel model)
        {
            if (model == null)
            {
                throw new ArgumentException(ValidationConstants.LobDefinedMessage);
            }

            var lob = new tbl_Lob()
            {
                Lob = model.Lob,
                MmcpLob = model.MmcpLob,
                MmcpSegment = model.MmcpSegment,
                ProductLine1 = model.ProductLine1,
                ProductLine2 = model.ProductLine2,
                ProductLine3 = model.ProductLine3,
                SpphIdProduct = model.SpphIdProduct
            };

            this.db.TblLob.Add(lob);
            this.db.SaveChanges();

            return lob.IdLob;
        }

        public void RemoveLob(int id)
        {
            var lob = this.db
                .TblLob
                .Where(i => i.IdLob == id)
                .FirstOrDefault();

            this.db.TblLob.Remove(lob);
            this.db.SaveChanges();
        }
    }
}
