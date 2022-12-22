using System;

namespace Grid
{
    public struct Coord : IEquatable<Coord>
    {
        public int x;
        public int y;

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
            => obj is Coord position && x == position.x && y == position.y;

        public bool Equals(Coord other)
            => this == other;

        public override int GetHashCode()
            => HashCode.Combine(x, y);

        public override string ToString()
            => $"x: {x}; y: {y}";

        public static bool operator ==(Coord a, Coord b)
            => a.x == b.x && a.y == b.y;

        public static bool operator !=(Coord a, Coord b)
            => !(a == b);

        public static Coord operator +(Coord a, Coord b)
            => new Coord(a.x + b.x, a.y + b.y);

        public static Coord operator -(Coord a, Coord b)
            => new Coord(a.x - b.x, a.y - b.y);
    }
}