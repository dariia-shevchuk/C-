using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstWebApi.Interfaces;
using MyFirstWebApi.Models;
using System.Collections.Generic;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SongController : ControllerBase
    {
        private readonly ILogger<SongController> _logger;
        private readonly ISongService _songService;

        public SongController(ILogger<SongController> logger, ISongService songService)
        {
            _logger = logger;
            _songService = songService;
        }

        /// <summary>
        /// Pobieranie wszystkich piosenek
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get()
        {
            var result = _songService.GetAllSongs();
            return Ok(result);
        }

        /// <summary>
        /// Pobieranie piosenki po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetSongById")]
        public ActionResult<Song> GetSongById([FromQuery] int id)
        {
            var result = _songService.GetSongById(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// dodawanie nowej piosenki
        /// </summary>
        /// <param name="newSong"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Song newSong)
        {
            _songService.AddNewSong(newSong);
            return Created("", newSong);
        }

        [HttpDelete]
        public ActionResult DeleteSongById([FromQuery] int id)
        {
            var result = _songService.DeleteSongById(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateSong([FromBody] Song songToUpdate)
        {
            _songService.UpdateSong(songToUpdate);
            return Ok();
        }
    }
}