namespace PlaylistsApi.Domain;

public interface IProvideTheSongCatalog
{
    Task<SongSummaryItemResponse> AddSongAsync(SongCreateRequest request);
    Task<GetSongsResponse> GetAllSongsAsync();
}
