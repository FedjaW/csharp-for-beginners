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
        public string Universe { get; init; }
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
    private class CloneableHero : IEquatable<CloneableHero>
    {
        public CloneableHero(string name = "", string universe = "", bool canFly = false)
            => (Name, Universe, CanFly) = (name, universe, canFly);

        public string Name { get; init; } // using init properties -> caller can set propertie when creating it initially
        public string Universe { get; init; }
        public bool CanFly { get; init; }

        public bool Equals(CloneableHero? other)
            => other != null &&
            Name == other.Name &&
            Universe == other.Universe &&
            CanFly == other.CanFly;

        public override bool Equals(object? obj)
            => obj != null && obj is CloneableHero h && Equals(h);

        public override int GetHashCode() => HashCode.Combine(Name, Universe, CanFly);

        // We add a convinience funcation to the class that makes it simple to clone objects
        public CloneableHero Clone() => new(Name, Universe, CanFly);
    }

    [Fact]
    public void Work_With_Cloneable_Hero()
    {
        var h1 = new CloneableHero("Black Noir", "DC", false);
        var h2 = h1.Clone();
        Assert.Equal(h1, h2);

        // This doesn't work because Name is init-only property
        // h2.Name = "Lamplighter";
    }
    #endregion

    #region Deconstruction
    private class DeconstructableHero : IEquatable<DeconstructableHero>
    {
        public DeconstructableHero(string name = "", string universe = "", bool canFly = false)
            => (Name, Universe, CanFly) = (name, universe, canFly);
        public string Name { get; init; }
        public string Universe { get; init; }
        public bool CanFly { get; init; }
        public bool Equals(DeconstructableHero? other)
            => other != null && Name == other.Name && Universe == other.Universe && CanFly == other.CanFly;
        public override bool Equals(object? obj)
            => obj != null && obj is DeconstructableHero h && Equals(h);
        public override int GetHashCode() => HashCode.Combine(Name, Universe, CanFly);
        public DeconstructableHero Clone() => new(Name, Universe, CanFly);

        // We add a deconstructor to the class.
        // Be aware: this is a de-con-stuctor and not a de-structor, both do exist in csharp.
        public void Deconstruct(out string name, out string universe, out bool canFly)
            => (name, universe, canFly) = (Name, Universe, CanFly);
    }

    [Fact]
    public void Work_With_Deconstructable_Hero()
    {
        var h1 = new DeconstructableHero("Translucent", "DC", false);
        var (name, _, canFly) = h1; // _ means ignore
        Assert.Equal("Translucent", name);
        Assert.False(canFly);
    }
    #endregion

    #region Records
    // RECORDS SOLVES ALL THAT PROBLEMS!
    private record MightyHero(string Name = "", string Universe = "", bool CanFly = false);

    [Fact]
    public void Work_With_RecordHero()
    {
        // Creation using ctor
        var h1 = new MightyHero("Homelander", "DC", true);

        // Creation with property initializations
        var h2 = new MightyHero { Name = "The Deep", Universe = "DC" };

        // Deconstruction
        var (name, _, canFly) = h2;
        Assert.Equal("The Deep", name);
        Assert.False(canFly);

        // Cloning with changes
        var h3 = h1 with { Name = "Stormfront" };
        Assert.Equal("DC", h3.Universe);

        // Creating and initializing collections
        MightyHero tick;
        _ = new[]
        {
            tick = new MightyHero("The Tick", CanFly: false),
            tick with { Name = "The Terror" }
        };

        // Value-based equality
        var anotherH1 = new MightyHero("Homelander", "DC", true);
        Assert.Equal(h1, anotherH1);

        // Instances of records are still immutable, so this doesn't work:
        // h1.Name = "Starlight";
    }
    #endregion
}
