using System;

public struct Coord : IEquatable<Coord>
{
    public int x { get; set; }
    public int y { get; set; }

    public static Coord zero  { get => new Coord(0, 0); }
    public static Coord up    { get => new Coord(0, 1); }
    public static Coord down  { get => new Coord(0, -1); }
    public static Coord right { get => new Coord(1, 0); }
    public static Coord left  { get => new Coord(-1, 0); }

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
