using GildedRose;

namespace GildedRose.Tests;

public class ProgramTests
{
    //dotnet test /p:CollectCoverage=true
    public readonly Program _program;
    private readonly IList<Item> testItem;
    public ProgramTests()
    {
        var program = new Program() {Items  = new List<Item>()};
        _program = program;
        testItem = program.Items;
    }

    [Fact]
    public void Plus_Five_Dexterity_Vest_Test()
    {
        //
        
        //Act
        testItem.Add(new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 });
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
    }

    [Fact]
    public void Conjured_Plus_Five_Dexterity_Vest_Test()
    {
        //
        //Act
        testItem.Add(new Item { Name = "+5 Conjured Dexterity Vest", SellIn = 10, Quality = 20 });
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
    }

    [Fact]
    public void Conjured_brie_Test()
    {
        //
        //Act
        testItem.Add(new Item { Name = "Conjured Aged Brie", SellIn = 10, Quality = 20 });
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
        Assert.Equal(22, testItem[0].Quality);
    }

    [Fact]
    public void BackStage_Pass_Test()
    {
        //
        //Act
        testItem.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 });
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
        Assert.Equal(22, testItem[0].Quality);
    }

    [Fact]
    public void Conjured_BackStage_Pass_Test()
    {
        //
        //Act
        testItem.Add(new Item { Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 });
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
        Assert.Equal(24, testItem[0].Quality);
    }

    [Fact]
    public void Conjured_BackStage_Pass_MaxValue_Test()
    {
        //
        //Act
        testItem.Add(new Item { Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 20 });
        _program.UpdateQuality();
        //Assert
        Assert.Equal(3,testItem[0].SellIn);
        Assert.Equal(26, testItem[0].Quality);
    }
    [Fact]
    public void BackStage_Pass_Over_dueDate()
    {
        //
        //Act
        testItem.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 });
        _program.UpdateQuality();
        //Assert
        Assert.Equal(-1,testItem[0].SellIn);
        Assert.Equal(0, testItem[0].Quality);
    }
    [Fact]
    public void sulfuras_Test()
    {
        //
        //Act
        testItem.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80  });
        _program.UpdateQuality();
        //Assert
        Assert.Equal(10,testItem[0].SellIn);
        Assert.Equal(80, testItem[0].Quality);
    }
    // [Fact]
    // public void t()
    // {
    //     //
    //     //Act
    //     testItem.Add(new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 });
    //     _program.UpdateQuality();
    //     //Assert
    //     Assert.Equal(2,testItem[0].SellIn);
    //     Assert.Equal(4, testItem[0].Quality);
    // }
}
