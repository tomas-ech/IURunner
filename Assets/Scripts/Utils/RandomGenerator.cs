using UnityEngine;

public static class RandomGenerator
{
    public static int GetRandomInt(int min, int max)
    {
        int randomNumber = Random.Range(min, max + 1);

        return randomNumber;
    }

    public static T GetRandomElement<T>(T[] elements)
    {
        if (elements == null || elements.Length == 0) return default;

        return elements[GetRandomInt(0, elements.Length)];
    }
    
}
