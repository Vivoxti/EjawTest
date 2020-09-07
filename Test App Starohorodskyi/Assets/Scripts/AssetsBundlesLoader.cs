using System.IO;
using UnityEngine;

public class AssetsBundlesLoader : MonoBehaviour
{
    private const string JsonName = "prefabNames";

    public static string jsonPath = Path.Combine("Resources", JsonName + ".json");

    private readonly PrefabNames _loadNames = new PrefabNames();

    private AssetBundle _prefabAssets;

    private void Start()
    {
        var json = Resources.Load<TextAsset>(JsonName);
        if (!json) return;
        JsonUtility.FromJsonOverwrite(json.text, _loadNames);
        LoadAssetsBundles(Path.Combine(Application.dataPath, _loadNames.path, "prefab"));
    }

    private void LoadAssetsBundles(string url)
    {
        PrefabObjects.prefabObjects.objectPrefabs = new Object[_loadNames.names.Length];
        for (var i = 0; i < _loadNames.names.Length; i++)
            try
            {
                _prefabAssets = AssetBundle.LoadFromFile(Path.Combine(url, _loadNames.names[i]));
                PrefabObjects.prefabObjects.objectPrefabs[i] = _prefabAssets.LoadAsset(_loadNames.names[i]);
            }
            catch
            {
                Debug.LogError("Load assets build error");
            }
    }

    public class PrefabNames
    {
        public string[] names;
        public string path;
    }
}