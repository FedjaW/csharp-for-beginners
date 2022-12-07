var heroes = new List<Hero>
{
    new("Wade", "Wilson", "Deadpool", false),
    new(string.Empty, string.Empty, "Homelander", true),
    new("Bruce", "Wayne", "Batman", false),
    new(string.Empty, string.Empty, "Stromfront", true),
};

var result  = FilterHeroes(heroes, (hero) => hero.CanFly);
var heroesFiltered = string.Join(", ", result);
Console.WriteLine(heroesFiltered);

List<Hero> FilterHeroes(List<Hero> heroes, Filter f)
{
    var resultList = new List<Hero>();
    foreach (var hero in heroes)
    {
        if(f(hero))
        {
            resultList.Add(hero);
        }
    }

    return resultList;
}

delegate bool Filter(Hero h);

record Hero(string FirstName, string LastName, string HeroName, bool CanFly);