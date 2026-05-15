using UnityEngine;
using TMPro;
public class text_add_stock : MonoBehaviour
{
    public TMP_Text textComponent; // text component to display the stock amount
    public Shelf_Interact shelfInteract; // Reference to the Shelf_Interact script


    public void Start()
    {
        UpdateStockText(); // Initialize the text with the current stock amount
    }


    public void AddStock(int amount)
    {
        shelfInteract.AddStock(amount); // Call the AddStock method in Shelf_Interact to update the stock
        UpdateStockText(); // Update the text to reflect the new stock amount
    }
    public void UpdateStockText()
    {
        textComponent.text = "Stock: " + shelfInteract.stock; // Update the text to show the current stock amount
    }
}
