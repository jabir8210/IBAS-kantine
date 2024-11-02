using Azure.Data.Tables;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly TableClient _tableClient;

    public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public IndexModel()
    { // min connection string og table name 
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=ibasbikeproduction1234;AccountKey=fu4oY8ZzJXCR34t75e6ZJxGWXv62ShriKUYMRhbVcJr7Q4bsYCIoqf/bH98dkbhLZVCfc4+59SuO+AStSVGW9A==;EndpointSuffix=core.windows.net";
        string tableName = "IbasMenu";
        _tableClient = new TableClient(connectionString, tableName);
    }

    public async Task OnGetAsync()
    {
        MenuItems = new List<MenuItem>();

        // Hent data fra Azure Table Storage
        await foreach (MenuItem menuItem in _tableClient.QueryAsync<MenuItem>())
        {
            MenuItems.Add(menuItem);
        }

        // dagene i RowKey bliver ikke sorteret korrekt, så jeg laver en liste med den rigtige rækkefølge
        var dayOrder = new List<string> { "Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag" };

        // Sorter menuItmes efter rækkefølgen i dayOrder
        MenuItems = MenuItems
                    .OrderBy(item => dayOrder.IndexOf(item.RowKey))
                    .ToList();
    }


}
