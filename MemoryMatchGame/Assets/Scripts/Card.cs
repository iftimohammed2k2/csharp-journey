using System;

namespace MemoryMatchGame
{
    public class Card
    {
        public int ID { get; private set; }
        public bool IsFlipped { get; private set; }
        public bool IsMatched { get; private set; }

        public Card(int id)
        {
            ID = id;
            IsFlipped = false;
            IsMatched = false;
        }

        public void Flip()
        {
            if (IsMatched) return;
            IsFlipped = true;
            Console.WriteLine($"Card {ID} flipped.");
        }

        public void Hide()
        {
            if (IsMatched) return;
            IsFlipped = false;
            Console.WriteLine($"Card {ID} hidden.");
        }

        public void Match()
        {
            IsMatched = true;
            Console.WriteLine($"Card {ID} matched!");
        }
    }
}
