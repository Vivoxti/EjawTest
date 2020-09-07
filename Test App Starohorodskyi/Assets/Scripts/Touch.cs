using UnityEngine;

public class Touch : MonoBehaviour
{
    private Camera _mainCamera;

    // Start is called before the first frame update
    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 7f);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.tag == "Prefab")
                    hit.transform.GetComponent<GeometryObjectModel>().Click();
                else
                    PrefabObjects.prefabObjects.ObjectInstantiate(hit.point);
            }
        }
    }
}