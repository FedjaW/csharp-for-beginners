using Xunit;

namespace RecordsInsideOut;

public class Basics
{
    #region Naive Hero class
    private class HeroNaive
    {
        public HeroNaive() { }
        public string Name { get; set; } = string.Empty;
        public string Universe { get; set; } = string.Empty;
        public bool CanFly { get; set; }
    }

    [Fact]
    public void Work_With_Naive_Hero()
    {
        // Can initialize props when creating the object.
        // Everybody can set props as he likes (might be bad!).
        // And we can NOT enforce initialization of props (bad!).
        var h = new HeroNaive
        {
            Name = "FedjaW",
            Universe = "Erde",
            CanFly = false
        };
        Assert.Equal("FedjaW", h.Name);

        // Class is mutable, but should it be? -> No!
        h.Name = "Radioactiveman";
        Assert.Equal("Radioactiveman", h.Name);
    }
    #endregion

    #region Hero with ctor
    private class HeroWithCtor
    {
        // Let´s add a constructor to enforce initialization of certain props
        public HeroWithCtor(string name, string universe, bool canFly)
            => (Name, Universe, CanFly) = (name, universe, canFly); // Syntactic sugar tupel assignment (no impact to story)

        // We also make the props read-only by removing the setters
        public string Name { get; }
        public string Universe { get; }
        public bool CanFly { get; }
    }

    [Fact]
    public void Work_With_Ctor_Hero()
    {
        var h = new HeroWithCtor("FedjaW", "Earth", false);
        Assert.Equal("Earth", h.Universe);

        // That does not work, class is immutable
        // h.Name = "Radioactiveman";
    }
    #endregion

    #region Comparing Heros
    private class CompareableHero : IEquatable<CompareableHero>
    {
        public CompareableHero(string name = "", string universe = "", bool canFly = false)
            => (Name, Universe, CanFly) = (name, universe, canFly);

        // Note that we switch from read-only props to init-only. By giving
        // default values to ctor parameters, the user of the record can choose
        // between ctor params and prop initializers.
        public string Name { get; init; } // using init properties -> caller can set propertie when creating it initially
        public string Universe { get; init;  }
        public bool CanFly { get; init; }

        public bool Equals(CompareableHero? other)
            => other != null && 
            Name == other.Name && 
            Universe == other.Universe && 
            CanFly == other.CanFly;

        public override bool Equals(object? obj)
            => obj != null && obj is CompareableHero h && Equals(h);

        // We also implement GetHashCode for quick comparison, hash-based collections ect.
        public override int GetHashCode() => HashCode.Combine(Name, Universe, CanFly);
    }

    [Fact]
    public void Work_With_Compareable_Hero()
    {
        // Initializers are allowed
        var h1 = new CompareableHero("Spider Man", "Marvel", false);
        var h2 = new CompareableHero()
        {
            Name = "Spider Man",
            Universe = "Marvel",
            CanFly = false
        };

        Assert.Equal(h1, h2);

        // Not possible, object is immutable
        // h1.Name = "Spider Pig";
    }
    #endregion

    #region Cloning Heros
    #endregion

    #region Deconstruction
    #endregion

    #region Pure magic
    #endregion
}
