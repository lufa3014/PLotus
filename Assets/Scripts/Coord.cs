using System;
using UnityEngine;

[Serializable]
public struct Coord : IEquatable<Coord>
{
    public int x;
    public int y;

    public static Coord Zero  { get => new(0, 0); }
    public static Coord Up    { get => new(0, 1); }
    public static Coord Down  { get => new(0, -1); }
    public static Coord Right { get => new(1, 0); }
    public static Coord Left  { get => new(-1, 0); }

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

    public Vector2Int ToVector2Int()
        => new(x, y);

    public static float Distance(Coord a, Coord b)
    {
        var diff = a - b;
        return Mathf.Sqrt(diff.x * diff.x + diff.y * diff.y);
    }

    public static bool operator ==(Coord a, Coord b)
        => a.x == b.x && a.y == b.y;

    public static bool operator !=(Coord a, Coord b)
        => !(a == b);

    public static Coord operator +(Coord a, Coord b)
        => new(a.x + b.x, a.y + b.y);

    public static Coord operator -(Coord a, Coord b)
        => new(a.x - b.x, a.y - b.y);
}
