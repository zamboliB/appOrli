using UnityEngine;
using UnityEngine.UI;

public class ToggleMimi : MonoBehaviour
{
    public Toggle toggleMimi;      // Toggle que controla o botão Mimi
    public Toggle toggleFritz;     // Referência ao toggle do Fritz
    public Toggle togglePadrao;    // Referência ao toggle do Padrão
    public Button botaoMimi;       // Botão Mimi

    public Sprite filledSprite;    // Imagem quando ativado
    public Sprite emptySprite;     // Imagem quando desativado

    private Image botaoImage;

    void Start()
    {
        botaoImage = botaoMimi.GetComponent<Image>();
        toggleMimi.onValueChanged.AddListener(UpdateButtonAppearance);
        UpdateButtonAppearance(toggleMimi.isOn);
    }

    void UpdateButtonAppearance(bool isOn)
    {
        botaoImage.sprite = isOn ? filledSprite : emptySprite;

        if (isOn)
        {
            toggleFritz.isOn = false;
            togglePadrao.isOn = false;
        }
    }
}
