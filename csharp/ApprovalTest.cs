using System.Collections.Generic;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace csharp
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void UpdateQuality_InitialState_ApprovalTest()
        {
            // Arrange
            var items = new List<Item>
            {
                new() {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new() {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new() {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new() {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var gildedRose = new GildedRose(items);

            // Act
            gildedRose.UpdateQuality();

            var updatedItemsStringBuilder = new StringBuilder();
            foreach (var item in items)
            {
                updatedItemsStringBuilder.AppendLine($"{item.Name}, {item.SellIn}, {item.Quality}");
            }

            // Assert
            Approvals.Verify(updatedItemsStringBuilder.ToString());
        }
    }
}
