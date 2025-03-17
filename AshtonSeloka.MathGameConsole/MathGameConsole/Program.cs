using Calculator;
double? score;
string userInput = string.Empty;
string? playerName= string.Empty;
List<string> History = new List<string>();

Calculations calculator = new Calculations();


Console.WriteLine("What is your Name");
playerName  = Console.ReadLine();

while (true) 
{
	Console.Clear();

	//Displays menu item  5 history only when history is present
	if (History == null)
	{
		Console.WriteLine($"\nWhat Game Would you like to play {playerName}: \n a) Addition \n s) Subtraction \n d) Division \n m) Multiplication\n r) Random");
	}
	else 
	{
		Console.WriteLine($"\nWhat Game Would you like to play {playerName}: \n a) Addition \n s) Subtraction \n d) Division \n m) Multiplication\n r) Random \n h) View History");
	}

	//Checks if user selected random and then selects a valid selection
	string selection = Console.ReadLine();
	if (selection == "r")
	{
		Random dice = new Random();
		int selected = dice.Next(1, 4);

		switch (selected)
		{
			case 1:
				userInput = "a";
				break;

			case 2:
				userInput = "s";
				break;

			case 3:
				userInput = "d";

				break;

			case 4:
				userInput = "m";
				break;
		}
	}
	else 
	{
	 userInput =selection;
	}



	if (userInput == "h") 
	{
		Console.Clear();
		foreach (string userSCore in History) 
		{
			Console.WriteLine(userSCore);
		}

		Console.WriteLine("Enter any key to exit");
		if (Console.ReadLine() != null) 
		{
			continue;
		}
	
	}

	Console.WriteLine($"\nSelect difficulty\n e) Easy \n m) Medium \n h) Hard");
	string difficultyAsString = Console.ReadLine();
	int difficulty=0;

	switch (difficultyAsString)
	{
		case "e":
			difficulty = 5;
			break;

		case "m":
			difficulty = 10;
			break;

		case "h":
			difficulty = 15;
			break;
	}

	 score = calculator.Operations(userInput, difficulty);

	History.Add($"Player:{playerName}, Score:{score} out of {difficulty} ");











}

