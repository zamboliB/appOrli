using UnityEngine;
using UnityEngine.UI;

public class TogglePadrao : MonoBehaviour
{
    public Toggle togglePadrao;   // Toggle que controla o bot�o "Padr�o"
    public Toggle toggleFritz;    // Toggle do bot�o "Fritz"
    public Toggle toggleMimi;     // Toggle do bot�o "Mimi"
    public Button botaoPadrao;    // Bot�o "Padr�o"

    public Sprite filledSprite;   // Imagem quando ativado
    public Sprite emptySprite;    // Imagem quando desativado

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

        if (isOn)
        {
            if (toggleFritz.isOn)
                toggleFritz.isOn = false;

            if (toggleMimi.isOn)
                toggleMimi.isOn = false;
        }
    }
}

