using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel; // Refer�ncia ao painel do pop-up
    public Button yesButton;      // Bot�o "Sim"
    public Button noButton;       // Bot�o "N�o"

    void Start()
    {
        // Inicialmente, o pop-up deve estar oculto
        popupPanel.SetActive(false);

        // Adiciona ouvintes aos bot�es
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
    }

    // M�todo para exibir o pop-up
    public void ShowPopup()
    {
        popupPanel.SetActive(true);
    }

    // A��o ao clicar em "Sim"
    void OnYesButtonClicked()
    {
        // L�gica para apagar a configura��o
        Debug.Log("Configura��o apagada.");
        popupPanel.SetActive(false);
        // Adicione aqui a l�gica para atualizar a interface ou estado ap�s a dele��o
    }

    // A��o ao clicar em "N�o"
    void OnNoButtonClicked()
    {
        popupPanel.SetActive(false);
    }
}
