using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeometryObjectModel : MonoBehaviour
{
    [SerializeField] private string _objectType = "";
    [SerializeField] private int _clickCount;

    [SerializeField] private Color _cubeColor;

    private CompositeDisposable _disposables;
    private Material _objectMaterial;

    private void OnEnable()
    {
        _disposables = new CompositeDisposable();
    }

    private void OnDisable()
    {
        _disposables?.Dispose();
    }

    public void ChangeColorFromTimer()
    {
        _cubeColor = Random.ColorHSV();
    }

    public void StartTimer(int repeatTime)
    {
        // create timer Observable
        Observable.Timer(TimeSpan.FromSeconds(repeatTime))
            .Repeat()
            .Subscribe(_ => { ChangeColorFromTimer(); }).AddTo(_disposables);

        _objectMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        _objectMaterial.color = Color.Lerp(_objectMaterial.color, _cubeColor, Time.deltaTime * 3f);
    }

    public void ChangeColor()
    {
       
        var colorDataIndex =
            PrefabObjects.prefabObjects.colorData.FindIndex(x => x.objectType == _objectType && CheckBorder(x));
        if (colorDataIndex != -1) _cubeColor = PrefabObjects.prefabObjects.colorData[colorDataIndex].color;
    }

    public bool CheckBorder(GeometryObjectData.ClickColorData borders)
    {
        return borders.minClicksCount <= _clickCount && borders.maxClicksCount > _clickCount;
    }

    public void Click()
    {
        _clickCount++;
        ChangeColor();
    }
}