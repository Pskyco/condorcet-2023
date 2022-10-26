namespace Enum;

public class Film
{
    public FilmCategoryEnum CategoryEnum { get; set; }
    // public List<FilmCategoryEnum> CategoryEnums { get; set; }
    public DateOnly LaunchDate { get; set; }
    public string Name { get; set; }
}