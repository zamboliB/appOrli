using UnityEngine;
using UnityEngine.UI;

public class TogglePadrao : MonoBehaviour
{
    public Toggle togglePadrao; // Toggle que controla o bot�o "Padr�o"
    public Toggle toggleFritz; // Refer�ncia ao outro toggle
    public Button botaoPadrao; // Bot�o "Padr�o"

    public Sprite filledSprite;  // Imagem quando ativado
    public Sprite emptySprite;   // Imagem quando desativado

    private Image botaoImage;

    void Start()
    {
        botaoImage = botaoPadrao.GetComponent<Image>();

        togglePadrao.onValueChanged.AddListener(UpdateButtonAppearance);
        UpdateButtonAppearance(togglePadrao.isOn);
    }

    void UpdateButtonAppearance(bool isOn)
    {
        botaoImage.sprite = isOn ? filledSprite : emptySprite;

        if (isOn && toggleFritz.isOn)
        {
            toggleFritz.isOn = false;
        }
    }
}

