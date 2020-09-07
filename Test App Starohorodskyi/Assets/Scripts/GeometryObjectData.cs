using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeometryObjectData", menuName = "GeometryObjectData", order = 2)]
public class GeometryObjectData : ScriptableObject
{
    [SerializeField] private List<ClickColorData> _clicksData = new List<ClickColorData>();

    public List<ClickColorData> GetClicksData()
    {
        return _clicksData;
    }

    [Serializable]
    public class ClickColorData
    {
        public string objectType;
        public Color color;
        public int minClicksCount;
        public int maxClicksCount;
    }
}