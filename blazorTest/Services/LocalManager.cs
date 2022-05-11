using blazorTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Client.Services
{
    public class LocalEpisodeManager : IEpisodeDataManager
    {
        List<Episode> episodes = new List<Episode>();
        public LocalEpisodeManager()
        {
            episodes.Add(new Episode
            {
                Id = 1,
                Title = "Video 1",
                Description = "Video 1.",
            });

            episodes.Add(new Episode
            {
                Id = 2,
                Title = "Video 2",
                Description = "Video 2",
            });

        }

        public async Task<List<Episode>> GetAllEpisodes()
        {
            await Task.Delay(1);
            return episodes;
        }

        public async Task<Episode> GetEpisode(int Id)
        {
            await Task.Delay(1);
            return (from x in episodes
                    where x.Id == Id
                    select x).FirstOrDefault();
        }

        public async Task<List<Episode>> SearchEpisodes(string Title)
        {
            await Task.Delay(1);
            return (from x in episodes
                    where x.Title.ToLower().Contains(Title.ToLower())
                    select x).ToList();
        }

        public async Task<Episode> AddEpisode(Episode Episode)
        {
            await Task.Delay(1);
            episodes.Add(Episode);
            return Episode;
        }

        public async Task<Episode> UpdateEpisode(Episode Episode)
        {
            await Task.Delay(1);
            var thisEpisode = (from x in episodes
                               where x.Id == Episode.Id
                               select x).FirstOrDefault();

            if (thisEpisode != null)
            {
                // update just the Title field
                thisEpisode.Title = Episode.Title;
            }
            return thisEpisode;
        }

        public async Task DeleteEpisode(string Title)
        {
            await Task.Delay(1);
            var thisEpisode = (from x in episodes
                               where x.Title == Title
                               select x).FirstOrDefault();
            if (thisEpisode != null)
            {
                episodes.Remove(thisEpisode);
            }
        }

    }
}
