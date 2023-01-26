namespace NobelPrize;

public class PrizeCount
{
    public int _prizeCount { get; private set; }
    public string _laureateId{ get; }
    
    
    public PrizeCount(string laureateId)
    {
        _laureateId = laureateId;
        _prizeCount = 1;
    }
    
    
    public void IncreasePrizeCount()
    {
        _prizeCount++;
    }
    
}