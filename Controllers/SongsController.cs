using ApiMusic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private static List<Song> _songs = new List<Song> {

              new Song
            {
                Id = 1,
                TiTle = "Kids with Guns",
                Language = "English"
            },
            new Song
            {
                Id = 2,
                TiTle = "Karma",
                Language = "English"
            },
            new Song
            {
                Id = 3,
                TiTle = "Iglesia",
                Language = "Español"
            },

            new Song
            {
                Id = 4,
                TiTle = "мой мармеладный",
                Language = "Ruso"
            }

        };

        [HttpGet]//Mediante este controlador podemos hacer la petición
        public IEnumerable<Song> GetAllSongs()
        {
            return _songs;
        }

        //GET api/Songs/0
        [HttpGet("{id}")]
        public Song GetSongById(int id)
        {
            return _songs.Find(song => song.Id == id);
        }

        [HttpPost()]
        public IActionResult SaveSong([FromBody] Song newSong)
        {
            _songs.Add(newSong);
            return Ok();
        }


        //PUT api/Songs/0/ABC
        [HttpPut("{id}/{newTitle}")]
        public IActionResult UpdateSongTitle(int id, String newTitle)
        {

            var song = _songs.Find(song => song.Id == id);
            song.TiTle = newTitle;

            return Ok();
        }

        //PUT api/Songs/0
        [HttpPut("{id}")]
        public IActionResult UpdateSong(int id, [FromBody] Song updatedSong)
        {

            var song = _songs.Find(song => song.Id == id);
            song.TiTle = updatedSong.TiTle;
            song.Language = updatedSong.Language;

            return Ok();
        }

        // DELETE api/Songs/0
        [HttpDelete("{id}")]
        public IActionResult DeleteSong(int id)
        {
            var songDelete = _songs.Find(song => song.Id == id);

            if (songDelete == null)
            {
                return NotFound();
            }

            _songs.Remove(songDelete);

            return Ok("Se ha eliminado la canción");
        }

    }
}
