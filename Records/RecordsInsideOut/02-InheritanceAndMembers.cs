public class InheritanceAndMembers
{
    private interface IAmHero
    {
        string Name { get; }
        string Universe { get; }
    }

    // Record implementing an inteface
    private record Hero(string Name = "", string Universe = "", bool CanFly = false) : IAmHero;

    [Fact]
    public void Work_With_Hero_Interface()
    {
        IAmHero h = new Hero("Groot", "Marvel", false);
        Assert.Equal("Groot", h.name)
    } 
}