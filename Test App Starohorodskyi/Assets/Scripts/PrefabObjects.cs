using System.Collections.Generic;
using UnityEngine;

public class PrefabObjects : MonoBehaviour
{
    public static PrefabObjects prefabObjects;

    public List<GeometryObjectData.ClickColorData> colorData;
    public Object[] objectPrefabs;

    private int _observableTime;

    private void Awake()
    {
        prefabObjects = this;
        _observableTime = Resources.Load<GameData>("Game Data").GetObservableTime();
        colorData = Resources.Load<GeometryObjectData>("GeometryObjectData").GetClicksData();
    }

    public void ObjectInstantiate(Vector3 spawnPosition)
    {
        try
        {
            var prefab = Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length)], spawnPosition + Vector3.up,
                Quaternion.identity, transform) as GameObject;
            prefab?.GetComponent<GeometryObjectModel>().StartTimer(_observableTime);
        }
        catch
        {
            Debug.LogError("Prefab assets is null");
        }
    }
}