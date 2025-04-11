using UnityEngine;
using UnityEngine.UI;

public class TabBarController : MonoBehaviour
{
    [Header("Bot�es")]
    public Button homeButton;
    public Button orliButton;
    public Button musicButton;

    [Header("Pain�is")]
    public GameObject homePanel;
    public GameObject orliPanel;
    public GameObject musicPanel;

    [Header("Imagens dos bot�es")]
    public GameObject homeSelected;
    public GameObject homeUnselected;
    public GameObject orliSelected;
    public GameObject orliUnselected;
    public GameObject musicSelected;
    public GameObject musicUnselected;

    [Header("Pain�is que n�o devem ter TabBar")]
    public GameObject[] panelsWithoutTabBar;

    private void Start()
    {
        // Liga os bot�es
        homeButton.onClick.AddListener(() => SwitchToPanel(homePanel, "home"));
        orliButton.onClick.AddListener(() => SwitchToPanel(orliPanel, "orli"));
        musicButton.onClick.AddListener(() => SwitchToPanel(musicPanel, "music"));

        // Inicia com home selecionado
        SwitchToPanel(homePanel, "home");
    }

    void SwitchToPanel(GameObject targetPanel, string selected)
    {
        // Ativa/desativa os pain�is principais
        homePanel.SetActive(targetPanel == homePanel);
        orliPanel.SetActive(targetPanel == orliPanel);
        musicPanel.SetActive(targetPanel == musicPanel);

        // Ativa/desativa imagens
        homeSelected.SetActive(selected == "home");
        homeUnselected.SetActive(selected != "home");
        orliSelected.SetActive(selected == "orli");
        orliUnselected.SetActive(selected != "orli");
        musicSelected.SetActive(selected == "music");
        musicUnselected.SetActive(selected != "music");

        // Verifica se a TabBar deve aparecer
        CheckTabBarVisibility(targetPanel);
    }

    void CheckTabBarVisibility(GameObject currentPanel)
    {
        foreach (var panel in panelsWithoutTabBar)
        {
            if (panel == currentPanel)
            {
                gameObject.SetActive(false); // Esconde a TabBar
                return;
            }
        }
        gameObject.SetActive(true); // Mostra a TabBar
    }
}


