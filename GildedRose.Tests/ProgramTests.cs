namespace GildedRose.Tests;
using GildedRose;

public class ProgramTests
{
    private readonly Program _program;
    private readonly IList<Item> _testItems;

    public ProgramTests()
    {
        var program = new Program() { Items = new List<Item>()};
        _testItems = program.Items;
        _program = program;
        
        
    }
    [Fact]
    public void brie_should_have_incremented_quality_and_decremented_Sellin()
    {
        _testItems.Add(new Item { Name = "Aged Brie", SellIn = 1, Quality = 10 });
        _program.UpdateQuality();
        _testItems.First().SellIn.Should().Be(0);
        _testItems.First().Quality.Should().Be(11);
    }

    public void brie_should_have_quality_of_2()
    {
        _testItems.Add(new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 });

        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();



        _testItems.First().Quality.Should().Be(4);
    }

    //[Fact]
    //public void TestTheTruth()
    //{
    //    true.Should().BeTrue();
    //}

    //[Fact]
    //public void TestTheTruth()
    //{
    //    true.Should().BeTrue();
    //}

    //[Fact]
    //public void TestTheTruth()
    //{
    //    true.Should().BeTrue();
    //}

    //[Fact]
    //public void TestTheTruth()
    //{
    //    true.Should().BeTrue();
    //}

    //[Fact]
    //public void TestTheTruth()
    //{
    //    true.Should().BeTrue();
    //}


}