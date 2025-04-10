using UnityEngine;

public class TabBarVisibilityController : MonoBehaviour
{
    public GameObject tabBar; // A Tab Bar
    public GameObject[] panelsThatShowTabBar; // Os painéis que DEVEM mostrar a tab bar

    void Update()
    {
        bool shouldShow = false;

        foreach (GameObject panel in panelsThatShowTabBar)
        {
            if (panel.activeSelf)
            {
                shouldShow = true;
                break;
            }
        }

        tabBar.SetActive(shouldShow);
    }
}

