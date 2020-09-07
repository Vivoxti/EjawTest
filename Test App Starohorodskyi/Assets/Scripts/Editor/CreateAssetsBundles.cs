using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    public class CreateAssetsBundles
    {
        private static readonly AssetsBundlesLoader.PrefabNames PrefabNames = new AssetsBundlesLoader.PrefabNames();
        private const string BuildPath = "StreamingAssets/AssetsBundles";

        [MenuItem("Assets/Build Assets Bundles")]
        private static void BuildAssetsBundles()
        {
            SavePrefabNamesToJson();
            BuildPipeline.BuildAssetBundles(Path.Combine("Assets", BuildPath), BuildAssetBundleOptions.ChunkBasedCompression,
                BuildTarget.StandaloneWindows64);
        }

        private static void SavePrefabNamesToJson()
        {
            PrefabNames.path = BuildPath;
            PrefabNames.names = new string[3];
            PrefabNames.names[0] = "capsule";
            PrefabNames.names[1] = "cube";
            PrefabNames.names[2] = "sphere";
            try
            {
                var jsonNames = EditorJsonUtility.ToJson(PrefabNames, true);
                File.WriteAllText(Path.Combine(Application.dataPath, AssetsBundlesLoader.jsonPath), jsonNames);
            }
            catch
            {
                Debug.LogError("Serialization error");
            }
        }
    }
}