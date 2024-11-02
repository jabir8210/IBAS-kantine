using Azure;
using Azure.Data.Tables;

namespace IBAS_kantine.Model
{
    public class ContactItem : ITableEntity
    {

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
