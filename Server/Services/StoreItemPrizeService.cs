using Microsoft.EntityFrameworkCore;
using SimWars.Server.Models;
using SimWars.Shared.Models;

namespace SimWars.Server.Services {
	public class StoreItemPrizeService : IStoreItemPrizeService {
		readonly SimWarsContext _dbContext = new();

		public StoreItemPrizeService(SimWarsContext dbContext) {
			_dbContext = dbContext;
		}

		public List<StoreItemPrize> GetAll() {
			return _dbContext.StoreItemPrizes.ToList();
		}

		public void Add(StoreItemPrize storeItemPrize) {
			_dbContext.StoreItemPrizes.Add(storeItemPrize);
			_dbContext.SaveChanges();
		}

		public void Update(StoreItemPrize storeItemPrize) {
			_dbContext.Entry(storeItemPrize).State = EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public StoreItemPrize GetById(int id) {
			StoreItemPrize? storeItemPrize = _dbContext.StoreItemPrizes.Find(id);
			if (storeItemPrize != null) {
				return storeItemPrize;
			} else {
				return new StoreItemPrize();
			}
		}

		public void Delete(int id) {
			StoreItemPrize? storeItemPrize = _dbContext.StoreItemPrizes.Find(id);
			if (storeItemPrize != null) {
				_dbContext.StoreItemPrizes.Remove(storeItemPrize);
				_dbContext.SaveChanges();
			}
		}

	}
}
