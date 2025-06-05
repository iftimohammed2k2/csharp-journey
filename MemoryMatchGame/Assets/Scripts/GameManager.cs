using System;
using System.Collections.Generic;
using System.Threading;

namespace MemoryMatchGame
{
    public class GameManager
    {
        private List<Card> cards;
        private Card firstCard = null;
        private Card secondCard = null;

        public void StartGame()
        {
            Console.WriteLine("Starting Memory Match Game...\n");

            // Initialize 4 pairs (8 cards total)
            cards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                cards.Add(new Card(i));
                cards.Add(new Card(i));
            }

            // Shuffle
            var rng = new Random();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }

            RunGameLoop();
        }

        private void RunGameLoop()
        {
            int moves = 0;

            while (!IsGameOver())
            {
                DisplayCards();

                Console.Write("Select first card index (0–7): ");
                int firstIndex = int.Parse(Console.ReadLine());

                firstCard = cards[firstIndex];
                firstCard.Flip();

                Console.Write("Select second card index (0–7): ");
                int secondIndex = int.Parse(Console.ReadLine());

                secondCard = cards[secondIndex];
                secondCard.Flip();

                moves++;
                Thread.Sleep(1000);

                if (firstCard.ID == secondCard.ID && firstCard != secondCard)
                {
                    firstCard.Match();
                    secondCard.Match();
                }
                else
                {
                    firstCard.Hide();
                    secondCard.Hide();
                }

                firstCard = null;
                secondCard = null;
                Console.WriteLine();
            }

            Console.WriteLine($"🎉 Game completed in {moves} moves!");
        }

        private bool IsGameOver()
        {
            foreach (var card in cards)
            {
                if (!card.IsMatched) return false;
            }
            return true;
        }

        private void DisplayCards()
        {
            Console.WriteLine("\nCards:");
            for (int i = 0; i < cards.Count; i++)
            {
                var card = cards[i];
                string display = card.IsMatched ? $"[{card.ID}✔]" :
                                 card.IsFlipped ? $"[{card.ID}]" : "[X]";
                Console.Write($"{i}:{display}  ");
            }
            Console.WriteLine("\n");
        }
    }
}
