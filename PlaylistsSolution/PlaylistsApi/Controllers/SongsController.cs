namespace PlaylistsApi.Controllers;

[ApiController]
public class SongsController: ControllerBase
{
    private readonly IProvideTheSongCatalog _songCatalog;

    public SongsController(IProvideTheSongCatalog songCatalog)
    {
        _songCatalog = songCatalog;
    }

    [HttpGet("/songs")]
    public async Task<ActionResult<GetSongsResponse>> GetAllSongs()
    {
        GetSongsResponse response = await _songCatalog.GetAllSongsAsync();

        return Ok(response);
    }

    [HttpPost("/songs")]
    [ProducesResponseType(201)]
    public async Task<ActionResult<SongSummaryItemResponse>> AddSongs([FromBody] SongCreateRequest request)
    {
        SongSummaryItemResponse response = await _songCatalog.AddSongAsync(request);
        return StatusCode(201, request);
    }
}
