namespace NobelPrize;

public class DuplicatePrizeWinners
{
    private readonly List<PrizeCount> _prizeCountList;
    private readonly List<Prize> _filteredPrizes;
    private readonly List<Prize> _prizesFromJson;


    public DuplicatePrizeWinners(Prize[] prizes)
    {
        _prizeCountList = new List<PrizeCount>();
        _filteredPrizes = new List<Prize>();
        _prizesFromJson = new List<Prize>();
        _prizesFromJson.AddRange(prizes);
    }


    public void Show()
    {
        AddToPrizeCountOrIncrease();
        ShowDuplicateWinners();
    }

    private void AddToPrizeCountOrIncrease()
    {
        foreach (var prize in _prizesFromJson)
        {
            foreach (var laureate in prize.Laureates.Where(laureate => laureate.Id != ""))
            {
                var isAlreadyAddedToPrizeCountList = CheckIfAlreadyAddedToPrizeCountList(laureate.Id);
                if (isAlreadyAddedToPrizeCountList)
                {
                    var existingPrizeCount = _prizeCountList.FirstOrDefault(p => p._laureateId == laureate.Id);
                    existingPrizeCount?.IncreasePrizeCount();
                }
                else
                {
                    _prizeCountList.Add(new PrizeCount(laureate.Id));
                }
            }
        }
    }

    private void ShowDuplicateWinners()
    {
        foreach (var prizeCount in _prizeCountList)
        {
            if (prizeCount._prizeCount <= 1) continue;
            if (_prizesFromJson != null)
            {
                var wonPrizes = _prizesFromJson.Where(p => p.Laureates.Any(l => l.Id == prizeCount._laureateId));
                _filteredPrizes.AddRange(wonPrizes);
            }
            ShowPrizes(prizeCount._laureateId);
        }
    }
    
    private void ShowPrizes(string laureateId)
    {
        foreach (var prize in _filteredPrizes)
        {
            prize.Show(laureateId);
        }
    }
    
    private bool CheckIfAlreadyAddedToPrizeCountList(string laureateId)
    {
        foreach (var prizeCount in _prizeCountList)
        {
            if (prizeCount._laureateId == laureateId) return true;
        }

        return false;
    }
    
}