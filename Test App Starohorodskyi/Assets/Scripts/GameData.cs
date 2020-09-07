using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName = "GameData", order = 1)]
public class GameData : ScriptableObject
{
    [SerializeField] [Range(1, 60)] private int _observableTime = 1;

    public int GetObservableTime()
    {
        return _observableTime;
    }
}