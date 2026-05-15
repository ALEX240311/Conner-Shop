using TMPro;
using UnityEngine;

public class Shelf_Interact : MonoBehaviour, IInteractable
{
    private bool playerInrange = false;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject shelfCanvas;

    [SerializeField] private TMP_Text stockText;

    public int stock;

    public int amountToAdd = 1;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateStockUI();
    }

    public void Interact()
    {
        Debug.Log("Interacted with shelf " + gameObject.name);

        shelfCanvas.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInrange = false;
        }
    }

    public void AddStock(int amountToAdd)
    {
        stock += amountToAdd;

        Debug.Log("Added " + amountToAdd + " stock");

        UpdateStockUI();
    }

    public void AddOneStock()
    {
        AddStock(1);
    }

    void UpdateStockUI()
    {
        stockText.text = "Stock: " + stock; // + 1 value of stock
    }

    private void Update()
    {
        if (playerInrange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
}