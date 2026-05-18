using UnityEngine;

public class builderManager : MonoBehaviour
{
    public GameObject shelfPrefab;

    private GameObject previewObject;

    public float gridSize = 1f;

    private void Start()
    {
        previewObject = Instantiate(shelfPrefab);
    }


    private void Update()
    {
        followMouse();

        if (Input.GetMouseButtonDown(0))
        {
            PlaceObject();
        }
    }
    
    void PlaceObject()
    {
        Instantiate(shelfPrefab, previewObject.transform.position, Quaternion.identity);
    }
    void followMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 snapMouse = new Vector3
            (Mathf.Round(mousePosition.x / gridSize) * gridSize,
             Mathf.Round(mousePosition.y / gridSize) * gridSize,
             0f);
        previewObject.transform.position = snapMouse;
    }
}

