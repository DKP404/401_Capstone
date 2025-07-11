using UnityEngine;
using UnityEditor;
using System.Linq;

public class LargeAssetScanner
{
    [MenuItem("Tools/Scan Large Assets")]
    public static void FindLargeAssets()
    {
        string[] allAssets = AssetDatabase.GetAllAssetPaths();
        var largeAssets = allAssets
            .Where(path => !AssetDatabase.IsValidFolder(path))
            .Select(path => new System.IO.FileInfo(path))
            .Where(file => file.Exists && file.Length > 10 * 1024 * 1024) // >10MB
            .OrderByDescending(file => file.Length);

        foreach (var file in largeAssets)
        {
            Debug.LogWarning($"📦 Large Asset: {file.Name} — {(file.Length / (1024f * 1024f)):0.00} MB\nPath: {file.FullName}");
        }
    }
}