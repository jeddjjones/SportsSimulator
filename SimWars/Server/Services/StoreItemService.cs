using Microsoft.EntityFrameworkCore;
using SimWars.Server.Data;
using SimWars.Shared.Models;

namespace SimWars.Server.Services {
  public class StoreItemService : IStoreItemService {
    readonly SimWarsContext _dbContext = new();

    public StoreItemService(SimWarsContext dbContext) {
      _dbContext = dbContext;
    }

    public List<StoreItem> GetAll() {
      return _dbContext.StoreItems.ToList();
    }

    public void Add(StoreItem storeItem) {
      _dbContext.StoreItems.Add(storeItem);
      _dbContext.SaveChanges();
    }

    public void Update(StoreItem storeItem) {
      _dbContext.Entry(storeItem).State = EntityState.Modified;
      _dbContext.SaveChanges();
    }

    public StoreItem GetById(int id) {
      StoreItem? storeItem = _dbContext.StoreItems.Find(id);
      if (storeItem != null) {
        return storeItem;
      } else {
        return new StoreItem();
      }
    }

    public void Delete(int id) {
      StoreItem? storeItem = _dbContext.StoreItems.Find(id);
      if (storeItem != null) {
        _dbContext.StoreItems.Remove(storeItem);
        _dbContext.SaveChanges();
      }
    }

  }
}
