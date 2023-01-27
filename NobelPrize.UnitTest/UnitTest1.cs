using System.Text.Json;

namespace NobelPrize.UnitTest
{
    public class Tests
    {

        [Test]
        public void TestPrizesLaureate()
        {
            var prizesJson = File.ReadAllText("C:\\Users\\oscar\\source\\repos\\CodeAlong\\NobelPrize.UnitTest\\prizesUnitTest.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var prizes = JsonSerializer.Deserialize<Prize[]>(prizesJson, options)!;


            var id = "1015";
            var prize1 = prizes[0];


            //act
            prize1.Show(id);

            //assert
            Assert.That(prize1.Laureates.Count > 0);

        }
        [Test]
        public void TestPrizesLaureateHandlesNull()
        {
            var prizesJson = File.ReadAllText("C:\\Users\\oscar\\source\\repos\\CodeAlong\\NobelPrize.UnitTest\\prizesUnitTest.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var prizes = JsonSerializer.Deserialize<Prize[]>(prizesJson, options)!;


            var id = "1015";
            var prize1 = prizes[1];

            //act
            prize1.Show(id);


            //assert

            //Check if missing laureates property from JSON gets handled by ctor
            Assert.That(prize1.Laureates != null);

        }
    }
}