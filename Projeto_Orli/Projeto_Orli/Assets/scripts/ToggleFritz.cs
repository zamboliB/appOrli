using UnityEngine;
using UnityEngine.UI;

public class ToggleFritz : MonoBehaviour
{
    public Toggle toggleFritz;   // Toggle que controla o botão "Fritz"
    public Toggle togglePadrao;  // Toggle do botão "Padrão"
    public Toggle toggleMimi;    // Toggle do botão "Mimi"
    public Button botaoFritz;    // Botão "Fritz"

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

