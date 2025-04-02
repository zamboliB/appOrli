using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel; // Refer�ncia ao painel do pop-up
    public Button yesButton;      // Bot�o "Sim"
    public Button noButton;       // Bot�o "N�o"

    void Start()
    {
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
        // L�gica para apagar a configura��o, se necess�rio
        Debug.Log("Configura��o apagada.");

        // Carrega a cena "home"
        SceneManager.LoadScene("home");
    }

    // A��o ao clicar em "N�o"
    void OnNoButtonClicked()
    {
        popupPanel.SetActive(false);
    }
}
