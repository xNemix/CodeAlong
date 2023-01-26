namespace NobelPrize
{
    public class Prize
    {
        

        public string Year { get; }
        public string Category { get; }
        private Laureate[] Laureates { get; }

        public string OverallMotivation { get; }
        
        
        public string[]? GetLaureateIds()
        {
            var prizeLaureateIdList = new List<string>();
            if (Laureates.Length <= 0) return null;
            foreach (var laureate in Laureates)
            {
                prizeLaureateIdList.Add(laureate.Id);
            }

            return prizeLaureateIdList.ToArray();
        }


        public Laureate[]? FilterLaureates(string id)
        {
            var laureateList = new List<Laureate>();
            if (Laureates.Length <= 0) return null;
            foreach (var laureate in Laureates)
            {
                if (laureate.Id == id)
                {
                    laureateList.Add(laureate);
                }
            }

            return laureateList.ToArray();
        }
    }
}
