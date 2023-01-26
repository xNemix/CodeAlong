using NobelPrize;
using System.Text.Json;

/*
Oppskrift:
1: Egen klasse for opptelling PrizeCount
    Felt:
    - int _prizeCount 
    - int _laureateId 
2: En List<PrizeCount>
3: Gå gjennom alle vinnere i alle priser og oppdater listen (hvis ikke listen har id fra før, lag nytt objekt - hvis den har fra før, bruk det som er => tell opp count med 1) 
4: Gå gjennom alle i listen, hvis prizeCount > 1 - egen metode som viser alle priser for denne laureateId
 */

var prizesJson = File.ReadAllText("prizes.json");
var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
var prizes = JsonSerializer.Deserialize<Prize[]>(prizesJson, options);

var prizeCountList = new List<PrizeCount>();
var filteredLaureatesList = new List<Laureate>();

//This works.....
// for (int i = 0; i < prizes.Length; i++)
// {
//     prizes[i].Show();
// }

//But not this....
// //Add all Laureates to prizeCountList if Id does not exist, but increase prizeCount if id already exists.
foreach (var prize in prizes)
{
    var laureateIds = prize.GetLaureateIds();
    AddPrizeLaureateIds(laureateIds);
}

//Or this....
// Loop through all prizeCounts, show all prizes of a laureate that has more than 1 price
foreach (var prizeCount in prizeCountList)
{
    if (prizeCount._prizeCount > 1)
    {
        AddLaureatePrizes(prizeCount._laureateId);
        var laureatePrizes = FetchLaureatePrizesById(prizeCount._laureateId);
        ShowLaureatePrizes(laureatePrizes);
    }
}


//filteredLaureatesList METHODS

//Loops through all prizes, filters all laureates by id, and adds them to filteredLaureatesList
void AddLaureatePrizes(string laureateId)
{
    foreach (var prize in prizes)
    {
        var filteredLaureates = prize.FilterLaureates(laureateId);
        AddToFilteredLaureatesList(filteredLaureates);
    }
}


//Gets all laureates in filteredLaureatesList with specified ID
Laureate[] FetchLaureatePrizesById(string laureateId)
{
    var laureatePrizeList = new List<Laureate>();
    foreach (var laureate in filteredLaureatesList)
    {
        if (laureate.Id == laureateId)
        {
            laureatePrizeList.Add(laureate);
        }
    }

    return laureatePrizeList.ToArray();
}

//Shows all filtered laureates from filteredLaureatesList that matches the given Id in FetchLaureatePrizesById
void ShowLaureatePrizes(Laureate[] laureates)
{
    foreach (var laureate in laureates)
    {
        Console.WriteLine($"{laureate.Firstname} {laureate.Surname}");
    }
    
}

//Adds all filtered laureates to filteredLaureatesList
void AddToFilteredLaureatesList(Laureate[]? laureates)
{
    foreach (var laureate in laureates)
    {
        filteredLaureatesList.Add(laureate);
    }
}

//prizeCountList METHODS

//Loops through all PrizeLaureates, adds them to the filteredLaureatesList if ID does not exist. If it does exist it increases the prizeCount by 1
void AddPrizeLaureateIds(string[]? laureateIds)
{
    foreach (var id in laureateIds)
    {
        var alreadyExists = CheckIfIdAlreadyExist(id);
        if (!alreadyExists)
        {
            prizeCountList.Add(new PrizeCount(id));
            return;
        }
        var index = FindIndexOfWinnerId(id);
        prizeCountList[index].IncreasePrizeCount();
    }
}

//Checks if id already exists in prizeCountList
bool CheckIfIdAlreadyExist(string id)
{
    foreach (var prizeCount in prizeCountList)
    {
        if (prizeCount._laureateId == id) return true;
    }

    return false;
}

//Finds index of specified laureateID
int FindIndexOfWinnerId(string id)
{
    var index = 0;
    for (var i = 0; i < prizeCountList.Count; i++)
    {
        if (prizeCountList[i]._laureateId == id)
        {
            index = i;
        }
    }

    return index;
}