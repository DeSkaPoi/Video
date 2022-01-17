using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Video.Domain;

namespace Video.Infrastructure
{
    public class VideoRepository
    {
        private readonly VideoContext context;
        public VideoRepository(VideoContext context)
        {
            this.context = context;
        }

        public async Task<List<VideoManager>> GetAllVideosAsync()
        {
            return await context.Videos.Where(video => video.BelongDocument == false).ToListAsync();
        }

        public async Task<VideoManager> GetByIdVideoAsync(Guid idVideo)
        {
            return await context.Videos.FindAsync(idVideo);
        }

        public async Task AddVideoAsync(VideoManager video)
        {
            video.CreationTime = DateTime.Now;
            await context.AddAsync(video);
            await context.SaveChangesAsync();
        }

        public async Task DeleteVideoAsync(Guid idVideo)
        {
            VideoManager Video = await context.Videos.FindAsync(idVideo);
            if (Video == null)
            {
                throw new Exception("Video is not exist");
            }
            context.Remove(Video);
            await context.SaveChangesAsync();
        }
        public async Task UpdateVideoAsync(VideoManager video)
        {
            video.LastUpdate = DateTime.Now;
            context.Update(video);
            await context.SaveChangesAsync();
        }
    }
}
