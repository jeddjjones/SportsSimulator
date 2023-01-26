using SportsSimulator.Shared.Models;

namespace SportsSimulator.Server.Services {
	public interface INBA_StackService {
		public List<NBA_Stack> GetStacks();
		public void AddStack(NBA_Stack stack);
		public void UpdateStack(NBA_Stack stack);
		public NBA_Stack GetStack(int stackId);
		public void DeleteStack(int stackId);
	}
}
