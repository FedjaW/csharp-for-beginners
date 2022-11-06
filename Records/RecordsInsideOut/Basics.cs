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
    #endregion

    #region Comparing Heros
    #endregion

    #region Cloning Heros
    #endregion

    #region Deconstruction
    #endregion

    #region Pure magic
    #endregion
}
