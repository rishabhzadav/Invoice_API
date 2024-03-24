using Invoice_Api.Repo;
using Invoice_Api.Repo.Modal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Api.Service
{
    public class ItemService
    {
        InvoiceDbContext _db2;
        public ItemService(InvoiceDbContext db2)
        {
            _db2 = db2;
        }

        public async Task<bool> CreateItem(item _item)
        {
            try
            {
                await _db2.items.AddAsync(_item);
                await _db2.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }
        public async Task<List<item>> GetItemByCategory(string category)
        {
            List<item> _item;
            if (category == "ALL")
            {
                 _item = await _db2.items.ToListAsync();
            }
            else
            {
                 _item = await _db2.items.Where(i => i.ItemCategory == category).ToListAsync();
            }
            return  _item;

        }
 
    }
}
