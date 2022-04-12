namespace GameLibraryApi.Models
{
    public class GameListPagination
    {
        public Game[]? Games { get; set; } 
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
