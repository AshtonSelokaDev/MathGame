using System.Timers;
using System;

namespace Calculator
{

	public class Calculations
	{
		public int result;
		public int correctAnswer;
		public int firstNumber;
		public int secondNumber;
		public int score;
		Random random = new Random();
		string operationSymbol;
		public static int gameTimer;
		bool complete;
	
		/// <summary>
		/// A methode to control game play
		/// </summary>
		/// <param name="operation">The selected type of game</param>
		/// <param name="difficulty">The length of game play</param>
		/// <returns> Returns the score</returns>
		public double Operations(string? operation, int? difficulty) 
		{
			Console.Clear();
			bool stopped = false;
	
			
			Thread StopWatch = new Thread(() => {

				while (!stopped)
				{
					Timer();
				}
			});
			

			StopWatch.Start();

			//The game difficulty is used as the value controlling the length of play
			for (int i = 0; i < difficulty;i++) 
			{
				firstNumber = random.Next(0, 100);
				secondNumber = random.Next(0, 100);

				switch (operation) 
				{
					case "a":
						correctAnswer = firstNumber + secondNumber;
						operationSymbol = " + ";
						break;

					case "s":
						correctAnswer = firstNumber - secondNumber;
						operationSymbol = " - ";
						break;

					case "m":
						correctAnswer = firstNumber * secondNumber;
						operationSymbol = " * ";
						break;

					case "d":
	
						while (firstNumber % secondNumber != 0)
						{
							firstNumber = random.Next(0, 100);
							secondNumber = random.Next(1, 100);
						}
						correctAnswer = firstNumber / secondNumber;
						operationSymbol = " / ";
						break;
				}


				Console.WriteLine("\nWhat is " + firstNumber + operationSymbol + secondNumber);
				result = int.Parse(Console.ReadLine());

				if (result == correctAnswer)
				{
					Console.WriteLine("Congratulations");
					score++;
				}
				else
				{
					Console.WriteLine("Better luck next time");
				}
			}

			//Stops thread
			stopped = true;


			Console.WriteLine($"\n Your score is: {score} out of {difficulty}, you completed the game in {gameTimer} seconds");
			Console.WriteLine($"\n press any key and enter to return");
			if (Console.ReadLine() == null)
			{
				complete = false;

			}
			return score;
		}

		//Implements a game timer
		public static void Timer() 
		{

			while (true) 
			{
				gameTimer++;
				Thread.Sleep(1000);
			}
		
		}

	}
}
