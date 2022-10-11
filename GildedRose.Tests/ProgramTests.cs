namespace GildedRose.Tests;

public class ProgramTests
{
    private Program _program;
    private List<Item> testList;
    
    public ProgramTests()
    {
        _program = new Program();
        _program.Items = new List<Item>();
    }

    [Fact]
    public void brie_should_have_quality_of_1()
    {
        _program.Items.Add(new GildedRose.Item { Name = "Aged Brie", SellIn = 2, Quality = 0 });
        _program.UpdateQuality();

        var result = new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 };
        var resultBrie = _program.Items[0];

        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void item_cannot_have_quality_of_51()
    {
        _program.Items.Add(new GildedRose.Item { Name = "Aged Brie", SellIn = 2, Quality = 50 });
        _program.UpdateQuality();

        var result = new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 };
        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void item_cannot_have_negative_quality()
    {
        _program.Items.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 0 });
        _program.UpdateQuality();

        var result = new Item { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 0 };
        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void sulfuras_cannot_have_negative_quality()
    {
        _program.Items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
        _program.UpdateQuality();


        var result = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void quality_drops_twice_as_fast()
    {
        _program.Items.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 10 });
        _program.UpdateQuality();

        var result = new Item { Name = "Elixir of the Mongoose", SellIn = -1, Quality = 8 };
        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void backstagepass_increases_in_value_with_1()
    {
        _program.Items.Add(new Item {Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20});
        _program.UpdateQuality();

        var result = new Item { Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 14,
                    Quality = 21};

        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void backstagepass_increases_in_value_with_2()
    {
        _program.Items.Add(new Item {Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 8,
                    Quality = 20});
        _program.UpdateQuality();
       

        var result = new Item { Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 7,
                    Quality = 22};

        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void backstagepass_increases_in_value_with_3()
    {
        _program.Items.Add(new Item {Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 3,
                    Quality = 20});
        _program.UpdateQuality();
       

        var result = new Item { Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 2,
                    Quality = 23};

        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void backstagepass_has_quality_of_0_when_sellin_0()
    {
        _program.Items.Add(new Item {Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 20});
        _program.UpdateQuality();

        var result = new Item { Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = -1,
                    Quality = 0};

        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }


    [Fact]
    public void conjured_brie_should_have_quality_of_1()
    {
        _program.Items.Add(new GildedRose.Item { Name = "Conjured Aged Brie", SellIn = 2, Quality = 0 });
        _program.UpdateQuality();

        var result = new Item { Name = "Conjured Aged Brie", SellIn = 1, Quality = 2 };
        var resultBrie = _program.Items[0];

        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void conjured_brie_should_have_quality_of_10()
    {
        _program.Items.Add(new GildedRose.Item { Name = "Conjured Aged Brie", SellIn = 5, Quality = 8 });
        _program.UpdateQuality();

        var result = new Item { Name = "Conjured Aged Brie", SellIn = 4, Quality = 10 };
        var resultBrie = _program.Items[0];

        resultBrie.Should().BeEquivalentTo(result);
    }
    
    [Fact]
    public void conjured_backstagepass_has_quality_of_20_when_sellin_5()
    {
        _program.Items.Add(new Item {Name = "Conjured Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 20});
        _program.UpdateQuality();

        var result = new Item { Name = "Conjured Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 4,
                    Quality = 26};

        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }
    
    [Fact]
    public void conjured_backstagepass_has_quality_of_24_when_sellin_7()
    {
        _program.Items.Add(new Item {Name = "Conjured Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 7,
                    Quality = 20});
        _program.UpdateQuality();

        var result = new Item { Name = "Conjured Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 6,
                    Quality = 24};

        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void Conjured_sulfuras_cannot_have_negative_quality()
    {
        _program.Items.Add(new Item { Name = "Conjured Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
        _program.UpdateQuality();


        var result = new Item { Name = "Conjured Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void conjured_item_cannot_have_quality_of_51()
    {
        _program.Items.Add(new GildedRose.Item { Name = "Conjured Aged Brie", SellIn = 2, Quality = 50 });
        _program.UpdateQuality();

        var result = new Item { Name = "Conjured Aged Brie", SellIn = 1, Quality = 50 };
        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void conjured_item_cannot_have_negative_quality()
    {
        _program.Items.Add(new Item { Name = "Conjured Elixir of the Mongoose", SellIn = 5, Quality = 0 });
        _program.UpdateQuality();

        var result = new Item { Name = "Conjured Elixir of the Mongoose", SellIn = 4, Quality = 0 };
        var resultBrie = _program.Items[0];
        resultBrie.Should().BeEquivalentTo(result);
    }


    // [Fact]
    // public void testMain()
    // {
    //     Program.Main(new string[0]);
    //     true.Should.BeTrue();
    // }
    
}