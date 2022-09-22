namespace PlaylistsApi.Controllers;

public class SongsController: ControllerBase
{
    private readonly IProvideTheSongCatalog _songCatalog;

    public SongsController(IProvideTheSongCatalog songCatalog)
    {
        _songCatalog = songCatalog;
    }

    [HttpGet("/songs")]
    public async Task<ActionResult> GetAllSongs()
    {
        GetSongsResponse response = await _songCatalog.GetAllSongsAsync();

        return Ok(response);
    }

    [HttpPost("/songs")]
    public async Task<ActionResult> AddSongs()
    {
        return StatusCode(201);
    }
}
