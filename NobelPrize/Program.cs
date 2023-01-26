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


//Fetch the JSON Data and Deserialize it to a Prize[]
var prizesJson = File.ReadAllText("prizes.json");
var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
var prizes = JsonSerializer.Deserialize<Prize[]>(prizesJson, options)!;

//Find and show all prizes of a Laureate that has won more than once
var duplicatePrizeWinners = new DuplicatePrizeWinners(prizes);
duplicatePrizeWinners.Show();


