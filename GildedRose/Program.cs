namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                Create("+5 Dexterity Vest",10,20),
                Create("Aged Brie",2,0 ),
                Create("Elixir of the Mongoose",5,7),
                Create("Sulfuras, Hand of Ragnaros",0,80),
                Create("Sulfuras, Hand of Ragnaros",-1,80),
                Create("Backstage passes to a TAFKAL80ETC concert",15,20),
                Create("Backstage passes to a TAFKAL80ETC concert",10,49),
                Create("Backstage passes to a TAFKAL80ETC concert", 5,49),
				Create("Conjured Mana Cake",3,6),
                }
            };

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.DecreaseSellIn();
            }
        }
        public static Item Create(String name, int sellIn, int quality)
        {
            if(name.Contains("Sulfuras, Hand of Ragnaros"))
            {
                if(name.Contains("Conjured"))
                {
                    return new ConjuerdLegendaryItem{Name = name, SellIn = sellIn, Quality = quality};
                }
                return new LegendaryItem{Name = name, SellIn = sellIn, Quality = quality};
            }
            if(name.Contains("Aged Brie"))
            {
                if(name.Contains("Conjured"))
                {
                    return new ConjuredAgedBrie{Name = name, SellIn = sellIn, Quality = quality};
                }
                return new AgedBrie{Name = name, SellIn = sellIn, Quality = quality};
            }
            if(name.Contains("Backstage passes to a TAFKAL80ETC concert"))
            {
                if(name.Contains("Conjured"))
                {
                    return new ConjuredBackStagePass{Name = name, SellIn = sellIn, Quality = quality};
                }

                return new BackStagePass{Name = name, SellIn = sellIn, Quality = quality};
            }
            //BasicItems
            if(name.Contains("Conjured"))
            {
                return new ConjuredBasicItem{Name = name, SellIn = sellIn, Quality = quality};
            }
            else
            {
                return new BasicItem{Name = name, SellIn = sellIn, Quality = quality};
            }
        }
    }
    public class Item
    {
        public virtual void DecreaseSellIn(){} //This method has been added to Item in order to support a solution that uses polymorphism
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
    public class BasicItem : Item
    {
        public override void DecreaseSellIn()
        {
            SellIn = SellIn - 1;
            int decreaseValue = 1;
            if(SellIn <0)
            {
                decreaseValue = 2;
            }
            CalculateQuality(decreaseValue);
        }
        protected void CalculateQuality(int decreaseValue)
        {
            if(Quality==0 || Quality <0)
            {
                Quality=0;
            }
            else
            {
                Quality = Quality - decreaseValue;
            }
        }
    }
    public class ConjuredBasicItem : BasicItem 
    {
        public override void DecreaseSellIn()
        {
            SellIn = SellIn - 1;
            int decreaseValue = 2;
            if(SellIn <0)
            {
                decreaseValue = 4;
            }
            CalculateQuality(decreaseValue);
        }
    }
    public class AgedBrie : Item
    {
        public override void DecreaseSellIn()
        {
            SellIn = SellIn - 1;
            int IncreaseValue = 1;
            if(SellIn <0)
            {
                IncreaseValue = 2;
            }
            CalculateQuality(IncreaseValue);
        }
        protected void CalculateQuality(int IncreaseValue)
        {
            if(Quality==50 || Quality >50)
            {
                Quality=50;
            }
            else
            {
                Quality = Quality + IncreaseValue;
            }
        }
    }
    public class ConjuredAgedBrie : AgedBrie
    {
        public override void DecreaseSellIn()
        {
            SellIn = SellIn - 1;
            int IncreaseValue = 2;
            if(SellIn <0)
            {
                IncreaseValue = 4;
            }
            CalculateQuality(IncreaseValue);
        }
    }
    public class BackStagePass : Item
    {
        public override void DecreaseSellIn()
        {
            SellIn = SellIn - 1;
            int IncreaseValue = 1;

            if(SellIn < 11)
            {
                IncreaseValue = IncreaseValue +1;
            }
            if(SellIn < 6)
            {
                IncreaseValue = IncreaseValue +1;
            }
            if(SellIn < 0)
            {
                IncreaseValue = 0;
                Quality = 0;
            }

            CalculateQuality(IncreaseValue);
        }
        protected void CalculateQuality(int IncreaseValue)
        {
            if(Quality==50 || Quality >50)
            {
                Quality=50;
            }
            else
            {
                Quality = Quality + IncreaseValue;
            }
        }
    }
    public class ConjuredBackStagePass : BackStagePass
    {
        public override void DecreaseSellIn()
        {
            SellIn = SellIn - 1;
            int IncreaseValue = 2;
            if(SellIn < 11)
            {
                IncreaseValue = IncreaseValue +2;
            }
            if(SellIn < 6)
            {
                IncreaseValue = IncreaseValue +2;
            }
            if(SellIn < 0)
            {
                IncreaseValue = 0;
                Quality = 0;
            }
            CalculateQuality(IncreaseValue);
        }
    }
    public class LegendaryItem : Item {}
    public class ConjuerdLegendaryItem : LegendaryItem{}
}    