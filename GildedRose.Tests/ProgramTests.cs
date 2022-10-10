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

    [Fact]
    public void Brie_should_have_quality_of_4_with_sellin_of4_4()
    {
        _testItems.Add(new Item { Name = "Aged Brie", SellIn = 4, Quality = 0 });

        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();

        _testItems.First().Quality.Should().Be(4);
    }

    [Fact]
    public void Brie_should_have_quality_of_4_with_sellin_of_0()
    {
        _testItems.Add(new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 });

        _program.UpdateQuality();
        _program.UpdateQuality();

        _testItems.First().Quality.Should().Be(4);
    }


    [Fact]
    public void Brie_should_have_quality_of_10_with_sellin_of_10()
    {
        _testItems.Add(new Item { Name = "Aged Brie", SellIn = 10, Quality = 5 });

        _program.UpdateQuality();
        _program.UpdateQuality();

        _testItems.First().Quality.Should().Be(7);
    }

    [Fact]

    public void Brie_quality_cannot_exceed_50()
    {
        _testItems.Add(new Item { Name = "Aged Brie", SellIn = 4, Quality = 49 });
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();

        _testItems.First().Quality.Should().Be(50);
    }

    [Fact]
    public void Elixsir_should_have_quality_of_3_with_sellin_of_10()
    {
        _testItems.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 10, Quality = 10 });

        _program.UpdateQuality(); 
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();

        _testItems.First().Quality.Should().Be(0);
    }

    [Fact]
    public void Sulfuras_should_have_Sellin_at_minus_1_and_quality_of_10()
    {
        _testItems.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 10 });

        _program.UpdateQuality();

        _testItems.First().Quality.Should().Be(10);
    }


    [Fact]
    public void Back_stage_pass_should_have_quality_100_with_sellin_5()
    {
        _testItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 10 });

        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();
        _program.UpdateQuality();

        _testItems.First().Quality.Should().Be(0);
    }


    [Fact]
    public void Item_count_should_be_1()
    {
        _testItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 });

        _testItems.Count().Should().Be(1);
    }









    // Backstage passes to a TAFKAL80ETC concert
    //new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80}




}