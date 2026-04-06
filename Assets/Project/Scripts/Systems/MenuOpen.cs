using UnityEngine;

public class MenuOpen : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas; // Reference to the menu canvas

    private void Start()
    {
        menuCanvas.SetActive(false); // Ensure the menu is initially hidden
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Check for the Escape key press
        {
            ToggleMenu(); // Toggle the menu visibility
        }
    }

    private void ToggleMenu()
    {
        if (menuCanvas != null)
        {
            bool isActive = menuCanvas.activeSelf; // Check current state
            menuCanvas.SetActive(!isActive); // Toggle the state
        }
    }
}
