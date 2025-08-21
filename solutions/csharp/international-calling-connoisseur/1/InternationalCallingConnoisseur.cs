using System;
using System.Collections.Generic;
using System.Linq;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary() => new();

    public static Dictionary<int, string> GetExistingDictionary() =>
        new(new[]
        {
            new KeyValuePair<int, string>(1, "United States of America"),
            new KeyValuePair<int, string>(55, "Brazil"),
            new KeyValuePair<int, string>(91, "India"),
        });

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName) =>
        new(new[] { new KeyValuePair<int, string>(countryCode, countryName) });

    public static Dictionary<int, string> AddCountryToExistingDictionary(Dictionary<int, string> existingDictionary,
        int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode) =>
        existingDictionary.TryGetValue(countryCode, out var countryName) ? countryName : string.Empty;

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) => existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.TryGetValue(countryCode, out _))
        {
            existingDictionary[countryCode] = countryName;
        }

        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.TryGetValue(countryCode, out _))
        {
            existingDictionary.Remove(countryCode);
        }

        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        var values = existingDictionary.Values.ToArray();

        return values.Length == 0 ? string.Empty : values.MaxBy(x => x.Length);
    }
}