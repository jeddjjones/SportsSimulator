using SimWars.Shared.Models;

namespace SimWars.Server.Services;
public interface IStoreItemService {
	public List<StoreItem> GetAll();
	public void Add(StoreItem storeItem);
	public void Update(StoreItem storeItem);
	public StoreItem GetById(int id);
	public void Delete(int id);
}
