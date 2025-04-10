using UnityEngine;

public class TabBarVisibility : MonoBehaviour
{
    public GameObject tabBar;
    public GameObject[] panelsWithTabBar;

    void Update()
    {
        bool shouldShowTabBar = false;

        foreach (var panel in panelsWithTabBar)
        {
            if (panel.activeSelf)
            {
                shouldShowTabBar = true;
                break;
            }
        }

        tabBar.SetActive(shouldShowTabBar);
    }
}
