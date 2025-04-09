using UnityEngine;
using UnityEngine.UI;

public class ToggleFritz : MonoBehaviour
{
    public Toggle toggleFritz;   // Toggle que controla o bot�o "Fritz"
    public Toggle togglePadrao;  // Toggle do bot�o "Padr�o"
    public Toggle toggleMimi;    // Toggle do bot�o "Mimi"
    public Button botaoFritz;    // Bot�o "Fritz"

    public Sprite filledSprite;  // Imagem quando ativado
    public Sprite emptySprite;   // Imagem quando desativado

    private Image botaoImage;

    void Start()
    {
        botaoImage = botaoFritz.GetComponent<Image>();
        toggleFritz.onValueChanged.AddListener(UpdateButtonAppearance);
        UpdateButtonAppearance(toggleFritz.isOn);
    }

    void UpdateButtonAppearance(bool isOn)
    {
        botaoImage.sprite = isOn ? filledSprite : emptySprite;

        if (isOn)
        {
            if (togglePadrao.isOn)
                togglePadrao.isOn = false;

            if (toggleMimi.isOn)
                toggleMimi.isOn = false;
        }
    }
}

