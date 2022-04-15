using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApp.Models;

namespace StudentApp.Services
{
    public interface IRankService
    {
        List<Rank> GetRanks();

        Rank? GetRankById (int RankId);

        void AddRank (Rank rank);

        void UpdateRank (Rank rank);

        void DeleteRank (int RankId);
    }
}