using UnityEngine;

public class pickUpAble : MonoBehaviour, IInteractable
{
    private bool playerInRange = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered range of " + gameObject.name);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player exited range of " + gameObject.name);
        }
    }
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public void Interact()
    {
        Debug.Log("Picked up " + gameObject.name);
        Destroy(gameObject); // Destroy the object after picking it up
    }

}
