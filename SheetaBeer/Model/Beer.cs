namespace SheetaBeer.Model;

public record Beer(
    string Name,
    float PriceBottle,
    float PriceHalf,
    float PriceThird,
    float AlcoholVolume,
    string Description,
    string Notes,
    Uri Image,
    Uri Background,
    List<string> Ingredients);
