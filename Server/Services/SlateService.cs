using Microsoft.EntityFrameworkCore;
using SportsSimulator.Server.Models;
using SportsSimulator.Shared.Models;

namespace SportsSimulator.Server.Services {
	public class SlateService : ISlateService {
		readonly SportsSimulatorContext _dbContext = new();

		public SlateService(SportsSimulatorContext dbContext) {
			_dbContext = dbContext;
		}

		public List<Slate> GetSlates() {
			return _dbContext.Slates.ToList();
		}

		public void AddSlate(Slate slate) {
			_dbContext.Slates.Add(slate);
			_dbContext.SaveChanges();
		}

		public void UpdateSlate(Slate slate) {
			_dbContext.Entry(slate).State = EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public Slate GetSlate(int slateId) {
			Slate? slate = _dbContext.Slates.Find(slateId);
			if (slate != null) {
				return slate;
			} else {
				return new Slate();
			}
		}

		public void DeleteSlate(int slateId) {
			Slate? slate = _dbContext.Slates.Find(slateId);
			if (slate != null) {
				_dbContext.Slates.Remove(slate);
				_dbContext.SaveChanges();
			}
		}

	}
}
