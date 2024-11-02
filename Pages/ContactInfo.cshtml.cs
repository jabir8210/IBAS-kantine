using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Azure.Data.Tables;
using System.Collections.Generic;
using IBAS_kantine.Model;

namespace Ibas.MenuApp.Pages
{
    public class ContactInfoModel : PageModel
    {
        private readonly TableClient _tableClient;

        public List<ContactItem> ContactItems { get; set; } = new List<ContactItem>();

        public ContactInfoModel()
        { // min connection string og table name 
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=ibasbikeproduction1234;AccountKey=fu4oY8ZzJXCR34t75e6ZJxGWXv62ShriKUYMRhbVcJr7Q4bsYCIoqf/bH98dkbhLZVCfc4+59SuO+AStSVGW9A==;EndpointSuffix=core.windows.net";
            string tableName = "IbasContact";
            _tableClient = new TableClient(connectionString, tableName);
        }

        public async Task OnGetAsync()
        {
            ContactItems = new List<ContactItem>();

            // Hent data fra Azure Table Storage
            await foreach (ContactItem contactItem in _tableClient.QueryAsync<ContactItem>())
            {
                ContactItems.Add(contactItem);
            }
        }

    }
}
