using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel;     // Painel do pop-up de confirmação
    public GameObject homePanel;      // Painel que será ativado quando clicar "Sim"
    public Button yesButton;          // Botão "Sim"
    public Button noButton;           // Botão "Não"

    void Start()
    {
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
        Debug.Log("Listeners adicionados.");
    }

    // Método para exibir o pop-up
    public void ShowPopup()
    {
        popupPanel.SetActive(true);
    }

    // Ação ao clicar em "Sim"
    void OnYesButtonClicked()
    {
        Debug.Log("Configuração apagada.");

        popupPanel.SetActive(false);  // Fecha o pop-up
        homePanel.SetActive(true);    // Mostra o painel "home"
    }

    // Ação ao clicar em "Não"
    void OnNoButtonClicked()
    {
        popupPanel.SetActive(false); // Só fecha o pop-up
    }
}
