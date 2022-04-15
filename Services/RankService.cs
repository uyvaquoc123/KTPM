using StudentApp.Models;

namespace StudentApp.Services
{
    public class RankService : IRankService
    {
        private readonly DataContext _context;
        public RankService(DataContext context)
        {
            _context = context;
        }

        public void AddRank(Rank rank)
        {
            _context.Ranks.Add(rank);
            _context.SaveChanges();
        }

        public void DeleteRank(int RankId)
        {
            var rank = GetRankById(RankId);
            if (rank == null) return;
            _context.Ranks.Remove(rank);
            _context.SaveChanges();
        }

        public Rank? GetRankById(int RankId)
        {
            var rank = _context.Ranks.FirstOrDefault(r => r.Id == RankId);
            if (rank == null) return null;
            return rank;
        }

        public List<Rank> GetRanks()
        {
            return _context.Ranks.ToList();
        }

        public void UpdateRank(Rank rank)
        {
            var currentRank = GetRankById(rank.Id);
            if (currentRank == null) return;
            currentRank.Name = currentRank.Name;
            _context.SaveChanges();
        }
    }
}