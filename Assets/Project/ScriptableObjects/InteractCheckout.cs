using UnityEngine;
using UnityEngine.UIElements;

public class InteractCheckout : MonoBehaviour, IInteractable
{
    private bool playerInrange = false;
    [SerializeField] GameObject arrowObject; // Reference to the arrow GameObject
    public void Interact()
    {
        Debug.Log("Interacted with checkout" + gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInrange = true;
            activeArrow();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInrange = false;
            inactiveArrow();
        }
    }

    private void Update()
    {
        if (playerInrange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    // Optional: Visual feedback for interaction (e.g., show an arrow when the player is in range of the collider and turn off when out of range)
   private void activeArrow()
    {
        if (arrowObject != null)
        {
            arrowObject.SetActive(true); // Show the arrow when the player is in range
        }
    }
    private void inactiveArrow()
    {
        if (arrowObject != null)
        {
            arrowObject.SetActive(false); // Hide the arrow when the player is out of range
        }
    }
}
