using UnityEngine;
using UnityEngine.UI;
public class TabController : MonoBehaviour
{
    public Image[] tabs; // Array to hold references to the tab GameObjects
    public GameObject[] pages;

    private void Start()
    {
        ActiveTab(0);
    }



    //if the mouse clicks on the tab, it will call this function and pass the index of the tab to activate
    private void ActiveTab(int tabNo)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            if (i == tabNo)
            {
                tabs[i].color = Color.white; // Set the active tab color to white
                pages[i].SetActive(true); // Show the corresponding page
            }
            else
            {
                tabs[i].color = Color.gray; // Set the inactive tab color to gray
                pages[i].SetActive(false); // Hide the other pages
            }
        }

    }
}
