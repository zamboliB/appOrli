using UnityEngine;

public class TabBarVisibilityManager : MonoBehaviour
{
    public GameObject TabController; // O objeto da tabbar (todo)
    public GameObject[] panelsWithTabBar; // Pain�is onde a tab bar deve aparecer
    public float checkDelay = 0.1f; // Frequ�ncia para checar (em segundos)

    private void Start()
    {
        InvokeRepeating(nameof(UpdateVisibility), 0f, checkDelay);
    }

    void UpdateVisibility()
    {
        bool show = false;

        foreach (GameObject panel in panelsWithTabBar)
        {
            if (panel.activeInHierarchy)
            {
                show = true;
                break;
            }
        }

        TabController.SetActive(show);
    }
}
