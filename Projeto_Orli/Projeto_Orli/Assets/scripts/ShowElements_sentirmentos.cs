using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowElementsSentimentos : MonoBehaviour
{
    public GameObject[] elementosParaMostrar;
    public GameObject[] elementosParaEsconder;

    public Image screenBackground;
    public Sprite backgroundSprite;
    public Sprite buttonSprite;
    public Color textColor;

    private bool estaVisivel = false;
    private static ShowElementsSentimentos botaoAtivo = null;

    private Image buttonImage;
    private TextMeshProUGUI buttonText;

    private Sprite originalButtonSprite;
    private Color originalTextColor;
    private bool isActive = false;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        if (buttonImage != null) 
            originalButtonSprite = buttonImage.sprite;

        if (buttonText != null) 
            originalTextColor = buttonText.color;

        GetComponent<Button>().onClick.AddListener(ChangeEmotion);
    }

    public void AlternarVisibilidade()
    {
        estaVisivel = !estaVisivel;

        foreach (GameObject elemento in elementosParaMostrar)
        {
            elemento.SetActive(estaVisivel);
        }

        foreach (GameObject elemento in elementosParaEsconder)
        {
            elemento.SetActive(!estaVisivel);
        }
    }

    void ChangeEmotion()
    {
        // botão está ativo
        if (isActive) return;

        // Reseta o botão ativo
        if (botaoAtivo != null)
        {
            botaoAtivo.ResetButton();
        }

        // Colocar este botão como ativo
        isActive = true;
        botaoAtivo = this;

        if (screenBackground != null)
        {
            screenBackground.sprite = backgroundSprite;
        }

        if (buttonImage != null)
        {
            buttonImage.sprite = buttonSprite;
        }

        if (buttonText != null)
        {
            buttonText.color = textColor;
        }

        // Salva a emoção no PlayerPrefs (armazenamento temporário)
        PlayerPrefs.SetString("SelectedEmotion", buttonSprite.name);
        PlayerPrefs.Save();
    }

    void ResetButton()
    {
        isActive = false; // Marca que o botão não está mais ativo

        if (buttonImage != null)
        {
            buttonImage.sprite = originalButtonSprite;
        }

        if (buttonText != null)
        {
            buttonText.color = originalTextColor;
        }
    }
}




