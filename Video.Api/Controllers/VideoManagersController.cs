using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Video.Domain;
using Video.Infrastructure;
using Video.Domain;
using Video.Infrastructure;

namespace Video.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoManagersController : ControllerBase
    {
        private readonly VideoRepository repository;

        public VideoManagersController(VideoContext context)
        {
            repository = new VideoRepository(context);
        }

        // GET: api/VideoManagers
        [HttpGet]
        public async Task<List<VideoManager>> GetVideosAsync()
        {
            return await repository.GetAllVideosAsync();
        }

        // GET: api/VideoManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoManager>> GetVideoManagerAsync(Guid id)
        {
            var VideoManager = await repository.GetByIdVideoAsync(id);

            if (VideoManager == null)
            {
                return NotFound();
            }

            return VideoManager;
        }

        // PUT: api/VideoManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoManagerAsync(Guid id, VideoManager VideoManager)
        {
            if (id != VideoManager.Id)
            {
                return BadRequest();
            }
            await repository.UpdateVideoAsync(VideoManager);
            return NoContent();
        }

        // POST: api/VideoManagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VideoManager>> PostVideoManagerAsync(VideoManager VideoManager)
        {
            await repository.AddVideoAsync(VideoManager);
            return CreatedAtAction("GetVideoManager", new { id = VideoManager.Id }, VideoManager);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVideoManagerRange(List<Guid> ids)
        {
            List<Guid> NoneDeleteGuid = new();
            int i = 0;
            try
            {
                for (; i < ids.Count; i++)
                {
                    await repository.DeleteVideoAsync(ids[i]);
                }
            }
            catch (Exception)
            {
                NoneDeleteGuid.Add(ids[i]);
            }

            if (NoneDeleteGuid.Count != 0)
            {
                return NotFound(NoneDeleteGuid);
            }
            return NoContent();
        }

        // DELETE: api/VideoManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoManager(Guid id)
        {
            try
            {
                await repository.DeleteVideoAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
