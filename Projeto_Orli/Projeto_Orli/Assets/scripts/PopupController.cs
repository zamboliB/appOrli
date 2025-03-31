using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel; // Referência ao painel do pop-up
    public Button yesButton;      // Botão "Sim"
    public Button noButton;       // Botão "Não"

    void Start()
    {
        // Inicialmente, o pop-up deve estar oculto
        popupPanel.SetActive(false);

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
        // Lógica para apagar a configuração
        Debug.Log("Configuração apagada.");
        popupPanel.SetActive(false);
        // Adicione aqui a lógica para atualizar a interface ou estado após a deleção
    }

    // Ação ao clicar em "Não"
    void OnNoButtonClicked()
    {
        popupPanel.SetActive(false);
    }
}
