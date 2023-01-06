using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class JsonHelper
{
    public static T FromJson<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }

    public static string ToJson<T>(T obj, bool prettyPrint = true)
    {
        return JsonUtility.ToJson(obj, prettyPrint);
    }

    /// <summary>
    /// Flattens a 2D array into an enumerable of elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array2D">The 2D array to flatten.</param>
    /// <returns>An enumerable of elements in the array.</returns>
    public static IEnumerable<T> FlattenArray<T>(T[,] array2D)
    {
        for (int y = 0; y < array2D.GetLength(1); y++)
        {
            for (int x = 0; x < array2D.GetLength(0); x++)
            {
                yield return array2D[x, y];
            }
        }
    }

    /// <summary>
    /// Converts an enumerable of elements into a 2D array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="enumerable">The enumerable to convert.</param>
    /// <param name="firstDimLength">The length of the first dimension of the array.</param>
    /// <param name="secondDimLength">The length of the second dimension of the array.</param>
    /// <returns>The enumerable converted into a 2D array.</returns>
    public static T[,] ToArray2D<T>(IEnumerable<T> enumerable, int firstDimLength, int secondDimLength)
    {
        var array2D = new T[firstDimLength, secondDimLength];

        for (int i = 0; i < enumerable.Count(); i++)
        {
            array2D[i % firstDimLength, i / secondDimLength] = enumerable.ElementAt(i);
        }
        return array2D;
    }
}