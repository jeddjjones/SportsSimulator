using SportsSimulator.Shared.Models;

namespace SportsSimulator.Server.Services {
	public interface ISlateService {
		public List<Slate> GetSlates();
		public void AddSlate(Slate slate);
		public void UpdateSlate(Slate slate);
		public Slate GetSlate(int slateId);
		public void DeleteSlate(int slateId);
	}
}
