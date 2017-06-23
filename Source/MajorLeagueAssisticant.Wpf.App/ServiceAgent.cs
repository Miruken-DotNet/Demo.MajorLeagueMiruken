using MajorLeagueMiruken.Domain;

namespace MajorLeagueAssisticant.Wpf.App
{
    public class ServiceAgent
    {
        private readonly League _league;

        public ServiceAgent(League league)
        {
            _league = league;
        }
    }
}
