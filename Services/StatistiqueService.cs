using HelpDeskAPI.Data;
using HelpDeskAPI.Models;

namespace HelpDeskAPI.Services
{
    public class StatistiqueService
    {
        private readonly HelpDeskContext _context;

        public StatistiqueService(HelpDeskContext context)
        {
            _context = context;
        }

        // 📊 Rapport GLOBAL
        public object GetGlobalStats()
        {
            var total = _context.StatistiquesTickets.Count();

            var aTemps = _context.StatistiquesTickets
                .Count(s => s.Statut == StatutPerformance.ATemps);

            var retard = _context.StatistiquesTickets
                .Count(s => s.Statut == StatutPerformance.Retard);

            var tempsTotal = _context.StatistiquesTickets.Sum(s => s.Duree);

            var efficacite = total == 0 ? 0 : (double)aTemps / total * 100;

            return new
            {
                TotalTickets = total,
                ATemps = aTemps,
                Retard = retard,
                TempsTotal = tempsTotal,
                Efficacite = efficacite
            };
        }

        // 📊 Rapport PAR SERVICE
        public object GetStatsParService()
        {
            return _context.StatistiquesTickets
                .GroupBy(s => s.Service)
                .Select(g => new
                {
                    Service = g.Key,
                    Total = g.Count(),
                    TempsTotal = g.Sum(x => x.Duree),
                    ATemps = g.Count(x => x.Statut == StatutPerformance.ATemps),
                    Retard = g.Count(x => x.Statut == StatutPerformance.Retard)
                })
                .ToList();
        }

        // 📊 Rapport PAR AGENT
        public object GetStatsParAgent()
        {
            return _context.StatistiquesTickets
                .GroupBy(s => s.NomAgent)
                .Select(g => new
                {
                    Agent = g.Key,
                    Total = g.Count(),
                    TempsTotal = g.Sum(x => x.Duree),
                    ATemps = g.Count(x => x.Statut == StatutPerformance.ATemps),
                    Retard = g.Count(x => x.Statut == StatutPerformance.Retard)
                })
                .ToList();
        }
    }
}
