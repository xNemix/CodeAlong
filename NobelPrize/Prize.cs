namespace NobelPrize
{
    public class Prize
    {
        public string Year { get; set; }
        public string Category { get; set; }
        public List<Laureate> Laureates { get; set; }
        public string OverallMotivation { get; set; }

        
        public Prize()
        {
            Laureates = new List<Laureate>();
        }

        
        public void Show(string laureateId)
        {
            foreach (var laureate in Laureates.Where(l =>l.Id == laureateId))
            {
                var firstName = laureate.Firstname;
                var surName = laureate.Surname ?? "";
                var name = $"{firstName} {surName}";
                Console.WriteLine($"{Year} - {Category}: Winner {name}");
            }
        }
    }
}
