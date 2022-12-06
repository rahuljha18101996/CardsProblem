

using CardsProblem;

CardSet set = new CardSet(2);
//set.DisplayCard();
set.SuffleCard();
//set.DisplayCard();

Console.WriteLine();
Console.WriteLine();

CardGame game = new CardGame(set, 4, 4);
game.Deal();
game.DisplayPlayerCard();
//Console.WriteLine();
//game.DisplayRemainingCard();

//game.DealAgain();
//game.DisplayPlayerCard();

game.GetWinner();
game.showWinner();

Console.WriteLine();
Console.WriteLine();