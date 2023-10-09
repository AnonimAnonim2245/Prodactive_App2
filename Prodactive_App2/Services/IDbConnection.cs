using Prodactive_App2.Models;

namespace Prodactive_App2.Services
{
    public interface IDbConnection
    {
        Task<int> DeleteAllItemsAsync();
        Task<int> DeleteItemAsync(AddNewTab item);
        Task<AddNewTab> GetItemAsync(int id);
        Task<List<AddNewTab>> GetItemsAsync();
        Task<int> SaveAllItemAsync(List<AddNewTab> items);
        Task<int> SaveItemAsync(AddNewTab item);
        Task<int> UpdateItemAsync(AddNewTab item);
    }
}