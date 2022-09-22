namespace PlaylistsApi.Models;

public record GetSongsResponse
{
    public List<SongSummaryItemResponse> Data { get; set; } = new();
}

public record SongSummaryItemResponse
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public string? Album { get; set; }
}
