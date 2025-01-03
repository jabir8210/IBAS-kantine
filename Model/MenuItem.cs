﻿using Azure;
using Azure.Data.Tables;

public class MenuItem : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string VarmRet { get; set; } 
    public string KoldRet { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

}
