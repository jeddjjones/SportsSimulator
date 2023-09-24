using SimWars.Shared.Models;

namespace SimWars.Server.Services;
public interface IStoreItemPrizeService {
	public List<StoreItemPrize> GetAll();
	public void Add(StoreItemPrize storeItemPrize);
	public void Update(StoreItemPrize storeItemPrize);
	public StoreItemPrize GetById(int id);
	public void Delete(int id);
}
