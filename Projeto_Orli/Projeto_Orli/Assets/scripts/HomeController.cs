using UnityEngine;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public Button fritzButton; // Refer�ncia ao bot�o "fritz"

    void Start()
    {
        // Verifica o estado salvo do bot�o "fritz"
        if (PlayerPrefs.GetInt("FritzButtonState", 1) == 0)
        {
            fritzButton.interactable = false;
        }
    }
}
