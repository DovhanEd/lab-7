using System;
using System.Data;

namespace AdventureWorksService
{
    internal class AdventureWorksLTEntities
    {
        private Uri uri;

        public AdventureWorksLTEntities(Uri uri)
        {
            this.uri = uri;
        }

        public Services.Client.DataServiceQuery<SalesOrderHeader> SalesOrderHeaders { get; internal set; }

        internal void UpdateObject(SalesOrderHeader currentOrder)
        {
            throw new NotImplementedException();
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}