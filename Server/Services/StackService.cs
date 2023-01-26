using Microsoft.EntityFrameworkCore;
using SportsSimulator.Server.Models;
using SportsSimulator.Shared.Models;

namespace SportsSimulator.Server.Services {
	public class StackService : IStackService {
		readonly SportsSimulatorContext _dbContext = new();

		public StackService(SportsSimulatorContext dbContext) {
			_dbContext = dbContext;
		}

		public List<Stack> GetStacks() {
			return _dbContext.Stacks.ToList();
		}

		public void AddStack(Stack stack) {
			_dbContext.Stacks.Add(stack);
			_dbContext.SaveChanges();
		}

		public void UpdateStack(Stack stack) {
			_dbContext.Entry(stack).State = EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public Stack GetStack(int stackId) {
			Stack? stack = _dbContext.Stacks.Find(stackId);
			if (stack != null) {
				return stack;
			} else {
				return new Stack();
			}
		}

		public void DeleteStack(int stackId) {
			Stack? stack = _dbContext.Stacks.Find(stackId);
			if (stack != null) {
				_dbContext.Stacks.Remove(stack);
				_dbContext.SaveChanges();
			}
		}

	}
}
