using UnityEngine;

public class TabBarVisibilityManager : MonoBehaviour
{
    public GameObject TabController; // O objeto da tabbar (todo)
    public GameObject[] panelsWithTabBar; // Painéis onde a tab bar deve aparecer
    public float checkDelay = 0.1f; // Frequência para checar (em segundos)

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
