using UnityEngine;
using UnityEngine.UI;

public class ToggleFritz : MonoBehaviour
{
    public Toggle toggleFritz; // Toggle que controla o botão "Fritz"
    public Toggle togglePadrao; // Referência ao outro toggle
    public Button botaoFritz; // Botão "Fritz"

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

        if (isOn && togglePadrao.isOn)
        {
            togglePadrao.isOn = false;
        }
    }
}
