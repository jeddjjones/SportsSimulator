using Microsoft.EntityFrameworkCore;
using SportsSimulator.Server.Models;
using SportsSimulator.Shared.Models;

namespace SportsSimulator.Server.Services {
	public class NBA_StackService : INBA_StackService {
		readonly SportsSimulatorContext _dbContext = new();

		public NBA_StackService(SportsSimulatorContext dbContext) {
			_dbContext = dbContext;
		}

		public List<NBA_Stack> GetStacks() {
			return _dbContext.NBA_Stacks.ToList();
		}

		public void AddStack(NBA_Stack stack) {
			_dbContext.NBA_Stacks.Add(stack);
			_dbContext.SaveChanges();
		}

		public void UpdateStack(NBA_Stack stack) {
			_dbContext.NBA_Stacks.Update(stack);
			_dbContext.SaveChanges();
		}

		public NBA_Stack GetStack(int stackId) {
			NBA_Stack? stack = _dbContext.NBA_Stacks.Find(stackId);
			if (stack != null) {
				return stack;
			} else {
				return new NBA_Stack();
			}
		}

		public void DeleteStack(int stackId) {
			NBA_Stack? stack = _dbContext.NBA_Stacks.Find(stackId);
			if (stack != null) {
				_dbContext.NBA_Stacks.Remove(stack);
				_dbContext.SaveChanges();
			}
		}

	}
}
