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
    public void Plus_Five_Dexterity_Vest()
    {
        //Act
        testItem.Add(Program.Create("+5 Dexterity Vest",10,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
        Assert.Equal(19, testItem[0].Quality);
    }

    [Fact]
    public void Conjured_Plus_Five_Dexterity_Vest()
    {
        //Act
        testItem.Add(Program.Create("Conjured +5 Dexterity Vest",10,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
        Assert.Equal(18, testItem[0].Quality);
    }
    [Fact]
    public void Plus_Five_Dexterity_Vest_Past_sellIn()
    {
        //Act
        testItem.Add(Program.Create("+5 Dexterity Vest",0,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(-1,testItem[0].SellIn);
        Assert.Equal(18, testItem[0].Quality);
    }

    [Fact]
    public void Conjured_Plus_Five_Dexterity_Vest_Past_SellIn()
    {
        //Act
        testItem.Add(Program.Create("Conjured +5 Dexterity Vest",0,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(-1,testItem[0].SellIn);
        Assert.Equal(16, testItem[0].Quality);
    }

    [Fact]
    public void Plus_Five_Dexterity_Vest_Quality_0()
    {
        //Act
        testItem.Add(Program.Create("+5 Dexterity Vest",5,0 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(4,testItem[0].SellIn);
        Assert.Equal(0, testItem[0].Quality);
    }

    [Fact]
    public void Aged_brie()
    {
        //Act
        testItem.Add(Program.Create("Aged Brie",10,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
        Assert.Equal(21, testItem[0].Quality);
    }
    [Fact]
    public void Aged_brie_Past_SellIn()
    {
        //Act
        testItem.Add(Program.Create("Aged Brie",-1,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(-2,testItem[0].SellIn);
        Assert.Equal(22, testItem[0].Quality);
    }
    [Fact]
    public void Conjured_Aged_brie_Past_SellIn()
    {
        //Act
        testItem.Add(Program.Create("Conjured Aged Brie",-1,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(-2,testItem[0].SellIn);
        Assert.Equal(24, testItem[0].Quality);
    }

    [Fact]
    public void Conjured_Aged_brie()
    {
        //Act
        testItem.Add(Program.Create("Conjured Aged Brie",10,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
        Assert.Equal(22, testItem[0].Quality);
    }

    [Fact]
    public void Aged_brie_Quality_50()
    {
        //Act
        testItem.Add(Program.Create("Aged Brie",10,50 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
        Assert.Equal(50, testItem[0].Quality);
    }
    [Fact]
    public void Conjured_Aged_brie_Quality_50()
    {
        //Act
        testItem.Add(Program.Create("Conjured Aged Brie",10,50 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
        Assert.Equal(50, testItem[0].Quality);
    }

    [Fact]
    public void BackStage_Pass()
    {
        //Act
        testItem.Add(Program.Create("Backstage passes to a TAFKAL80ETC concert",50,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(49,testItem[0].SellIn);
        Assert.Equal(21, testItem[0].Quality);
    }

    [Fact]
    public void Conjured_BackStage_Pass()
    {
        //Act
        testItem.Add(Program.Create("Conjured Backstage passes to a TAFKAL80ETC concert",50,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(49,testItem[0].SellIn);
        Assert.Equal(22, testItem[0].Quality);
    }

    [Fact]
    public void BackStage_Pass_SellIn_10()
    {
        //Act
        testItem.Add(Program.Create("Backstage passes to a TAFKAL80ETC concert",10,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
        Assert.Equal(22, testItem[0].Quality);
    }

    [Fact]
    public void Conjured_BackStage_Pass_SellIn_10()
    {
        //Act
        testItem.Add(Program.Create("Conjured Backstage passes to a TAFKAL80ETC concert",10,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(9,testItem[0].SellIn);
        Assert.Equal(24, testItem[0].Quality);
    }


[Fact]
    public void BackStage_Pass_SellIn_4()
    {
        //Act
        testItem.Add(Program.Create("Backstage passes to a TAFKAL80ETC concert",4,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(3,testItem[0].SellIn);
        Assert.Equal(23, testItem[0].Quality);
    }
    [Fact]
    public void Conjured_BackStage_Pass_SellIn_4()
    {
        //Act
        testItem.Add(Program.Create("Conjured Backstage passes to a TAFKAL80ETC concert",4,20 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(3,testItem[0].SellIn);
        Assert.Equal(26, testItem[0].Quality);
    }
    [Fact]
    public void BackStage_Pass_Past_SellIn()
    {
        //Act
        testItem.Add(Program.Create("Backstage passes to a TAFKAL80ETC concert",0,20));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(-1,testItem[0].SellIn);
        Assert.Equal(0, testItem[0].Quality);
    }
    [Fact]
    public void Conjured_BackStage_Pass_Past_SellIn()
    {
        //Act
        testItem.Add(Program.Create("Conjured Backstage passes to a TAFKAL80ETC concert",0,20));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(-1,testItem[0].SellIn);
        Assert.Equal(0, testItem[0].Quality);
    }

    [Fact]
    public void sulfuras()
    {
        //Act
        testItem.Add(Program.Create("Sulfuras, Hand of Ragnaros",10,80));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(10,testItem[0].SellIn);
        Assert.Equal(80, testItem[0].Quality);
    }
    [Fact]
    public void Conjured_sulfuras()
    {
        //Act
        testItem.Add(Program.Create("Conjured Sulfuras, Hand of Ragnaros",10,80));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(10,testItem[0].SellIn);
        Assert.Equal(80, testItem[0].Quality);
    }

    [Fact]
    public void mana_Cake()
    {
        //Act
        testItem.Add(Program.Create("Mana Cake",3,6 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(2,testItem[0].SellIn);
        Assert.Equal(5, testItem[0].Quality);
    }
    [Fact]
    public void mana_Cake_After_SellIn()
    {
        //Act
        testItem.Add(Program.Create("Mana Cake",0,6 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(-1,testItem[0].SellIn);
        Assert.Equal(4, testItem[0].Quality);
    }

    [Fact]
    public void Conjured_mana_Cake()
    {
        //Act
        testItem.Add(Program.Create("Conjured Mana Cake",3,6 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(2,testItem[0].SellIn);
        Assert.Equal(4, testItem[0].Quality);
    }
    [Fact]
    public void Conjured_mana_Cake_After_SellIn()
    {
        //Act
        testItem.Add(Program.Create("Conjured Mana Cake",0,6 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(-1,testItem[0].SellIn);
        Assert.Equal(2, testItem[0].Quality);
    }

    [Fact]
    public void ElixirOfTheMoonGoose()
    {
        //Act
        testItem.Add(Program.Create("Elixir of the Mongoose",5,7 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(4,testItem[0].SellIn);
        Assert.Equal(6, testItem[0].Quality);
    }
    [Fact]
    public void Conjured_ElixirOfTheMoonGoose()
    {
        //Act
        testItem.Add(Program.Create("Conjured Elixir of the Mongoose",5,7 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(4,testItem[0].SellIn);
        Assert.Equal(5, testItem[0].Quality);
    }
    [Fact]
    public void ElixirOfTheMoonGoose_Past_SellIn()
    {
        //Act
        testItem.Add(Program.Create("Elixir of the Mongoose",0,7 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(-1,testItem[0].SellIn);
        Assert.Equal(5, testItem[0].Quality);
    }
    [Fact]
    public void Conjured_ElixirOfTheMoonGoose_Past_SellIn()
    {
        //Act
        testItem.Add(Program.Create("Conjured Elixir of the Mongoose",0,7 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(-1,testItem[0].SellIn);
        Assert.Equal(3, testItem[0].Quality);
    }
    [Fact]
    public void ElixirOfTheMoonGoose_BasicItemClass()
    {
        //Act
        testItem.Add(Program.Create("Elixir of the Mongoose",5,7 ));
        _program.UpdateQuality();
        //Assert
        Assert.Equal(4,testItem[0].SellIn);
        Assert.Equal(6, testItem[0].Quality);
    }
}
