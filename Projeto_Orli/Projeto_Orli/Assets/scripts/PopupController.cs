using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel; // Referência ao painel do pop-up
    public Button yesButton;      // Botão "Sim"
    public Button noButton;       // Botão "Não"

    void Start()
    {
        // Adiciona ouvintes aos botões
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
    }

    // Método para exibir o pop-up
    public void ShowPopup()
    {
        popupPanel.SetActive(true);
    }

    // Ação ao clicar em "Sim"
    void OnYesButtonClicked()
    {
        // Lógica para apagar a configuração, se necessário
        Debug.Log("Configuração apagada.");

        // Carrega a cena "home"
        SceneManager.LoadScene("home");
    }

    // Ação ao clicar em "Não"
    void OnNoButtonClicked()
    {
        popupPanel.SetActive(false);
    }
}
