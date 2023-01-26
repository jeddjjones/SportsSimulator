using SportsSimulator.Shared.Models;

namespace SportsSimulator.Server.Services {
	public interface IStackService {
		public List<Stack> GetStacks();
		public void AddStack(Stack stack);
		public void UpdateStack(Stack stack);
		public Stack GetStack(int stackId);
		public void DeleteStack(int stackId);
	}
}
