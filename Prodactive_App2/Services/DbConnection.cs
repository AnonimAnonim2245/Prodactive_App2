using Prodactive_App2.Models;
using SQLite;

namespace Prodactive_App2.Services;

public class DbConnection
{
    SQLiteAsyncConnection Database;

    public const SQLite.SQLiteOpenFlags Flags =
      // open the database in read/write mode
      SQLite.SQLiteOpenFlags.ReadWrite |
      // create the database if it doesn't exist
      SQLite.SQLiteOpenFlags.Create |
      // enable multi-threaded database access
      SQLite.SQLiteOpenFlags.SharedCache;

    public DbConnection()
    {
    }

    async Task Init()
    {
        if (Database is not null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "ToDoDb.db");

        try
        {
            Database = new SQLiteAsyncConnection(databasePath, Flags);
        }
        catch (Exception ex)
        {

        }

        await Database.CreateTableAsync<AddNewTab>();
    }

    public async Task<List<AddNewTab>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<AddNewTab>().ToListAsync();
    }

    public async Task<AddNewTab> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<AddNewTab>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(AddNewTab item)
    {
        await Init();
        return await Database.InsertAsync(item);
    }

    public async Task<int> UpdateItemAsync(AddNewTab item)
    {
        await Init();
        return await Database.UpdateAsync(item);
    }

    public async Task<int> SaveAllItemAsync(List<AddNewTab> items)
    {
        await Init();
        return await Database.InsertAllAsync(items);
    }

    public async Task<int> DeleteItemAsync(AddNewTab item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

    public async Task<int> DeleteAllItemsAsync()
    {
        await Init();
        return await Database.DeleteAllAsync<AddNewTab>();
    }
}
