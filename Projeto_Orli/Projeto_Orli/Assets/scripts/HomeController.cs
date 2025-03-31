using UnityEngine;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public Button fritzButton; // Referência ao botão "fritz"

    void Start()
    {
        // Verifica o estado salvo do botão "fritz"
        if (PlayerPrefs.GetInt("FritzButtonState", 1) == 0)
        {
            fritzButton.interactable = false;
        }
    }
}
