using Microsoft.EntityFrameworkCore;

namespace PlaylistsApi.Adapters;

public class PlaylistsDataContext : DbContext
{
    public PlaylistsDataContext(DbContextOptions<PlaylistsDataContext> options) : base(options)
    {

    }
    public DbSet<SongEntity> Songs { get; set; }
}
