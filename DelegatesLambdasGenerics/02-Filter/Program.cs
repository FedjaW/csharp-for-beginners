var heroes = new List<Hero>
{
    new("Wade", "Wilson", "Deadpool", false),
    new(string.Empty, string.Empty, "Homelander", true),
    new("Bruce", "Wayne", "Batman", false),
    new(string.Empty, string.Empty, "Stromfront", true),
};

var result  = Filter(heroes, (hero) => hero.CanFly);
var heroesFiltered = string.Join(", ", result);
Console.WriteLine(heroesFiltered);

// Old version (Step 1)
// IEnumerable<Hero> FilterHeroesObsolete(IEnumerable<Hero> heroes, Filter f)
// {
//     var resultList = new List<Hero>();
//     foreach (var hero in heroes)
//     {
//         if(f(hero))
//         {
//             resultList.Add(hero);
//         }
//     }

//     return resultList;
// }

// Better version with yield syntax (Step 2)
// IEnumerable<Hero> FilterHeroes(IEnumerable<Hero> heroes, Filter f)
// {
//     foreach (var hero in heroes)
//     {
//         if(f(hero))
//         {
//             yield return hero;
//         }
//     }
// }

// WOW! This is very close to the "where" clause from LINQ!
// IEnumerable<T> Filter<T>(IEnumerable<T> items, Filter<T> f)
// {
//     foreach (var item in items)
//     {
//         if(f(item))
//         {
//             yield return item;
//         }
//     }
// }

// WOW! This is even more close to the "where" clause from LINQ!
IEnumerable<T> Filter<T>(IEnumerable<T> items, Func<T, bool> f)
{
    foreach (var item in items)
    {
        if(f(item))
        {
            yield return item;
        }
    }
}

// delegate bool Filter<T>(T h); // used in step1 and step2 (see above)

record Hero(string FirstName, string LastName, string HeroName, bool CanFly);