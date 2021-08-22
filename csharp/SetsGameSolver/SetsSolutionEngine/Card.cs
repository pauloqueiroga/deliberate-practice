using System;

namespace pauloq.SetsSolutionEngine
{
    public class Card : IEquatable<Card>, IComparable<Card>
    {
        private static readonly Random randomizer = new(DateTime.UtcNow.Millisecond);

        public Colors Color { get; }

        public Shapes Shape { get; }

        public Fills Fill { get; }

        public Numbers Number { get; }

        public Card() : this(Rand<Colors>(), Rand<Shapes>(), Rand<Fills>(), Rand<Numbers>())
        {
        }

        public Card(Colors color, Shapes shape, Fills fill, Numbers number)
        {
            Color = color;
            Shape = shape;
            Fill = fill;
            Number = number;
        }

        public bool Equals(Card other)
        {
            return (this.Color == other.Color
                && this.Shape == other.Shape
                && this.Fill == other.Fill
                && this.Number == other.Number);
        }

        public int CompareTo(Card other)
        {
            int soFar = Color.CompareTo(other.Color);

            if (soFar != 0)
            {
                return soFar;
            }

            soFar = Shape.CompareTo(other.Shape);

            if (soFar != 0)
            {
                return soFar;
            }

            soFar = Fill.CompareTo(other.Fill);

            if (soFar != 0)
            {
                return soFar;
            }

            return Number.CompareTo(other.Fill);
        }

        public override int GetHashCode()
        {
            return (byte)Color * 1000 + (byte)Shape * 100 + (byte)Fill * 10 + (byte)Number;
        }

        private static T Rand<T>() where T: Enum
        {
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(randomizer.Next(values.Length));
        }
    }
}
