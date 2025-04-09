using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel;     // Painel do pop-up de confirma��o
    public GameObject homePanel;      // Painel que ser� ativado quando clicar "Sim"
    public Button yesButton;          // Bot�o "Sim"
    public Button noButton;           // Bot�o "N�o"

    void Start()
    {
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
        Debug.Log("Listeners adicionados.");
    }

    // M�todo para exibir o pop-up
    public void ShowPopup()
    {
        popupPanel.SetActive(true);
    }

    // A��o ao clicar em "Sim"
    void OnYesButtonClicked()
    {
        Debug.Log("Configura��o apagada.");

        popupPanel.SetActive(false);  // Fecha o pop-up
        homePanel.SetActive(true);    // Mostra o painel "home"
    }

    // A��o ao clicar em "N�o"
    void OnNoButtonClicked()
    {
        popupPanel.SetActive(false); // S� fecha o pop-up
    }
}
