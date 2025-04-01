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
        // bot�o est� ativo
        if (isActive) return;

        // Reseta o bot�o ativo
        if (botaoAtivo != null)
        {
            botaoAtivo.ResetButton();
        }

        // Colocar este bot�o como ativo
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

        // Salva a emo��o no PlayerPrefs (armazenamento tempor�rio)
        PlayerPrefs.SetString("SelectedEmotion", buttonSprite.name);
        PlayerPrefs.Save();
    }

    void ResetButton()
    {
        isActive = false; // Marca que o bot�o n�o est� mais ativo

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




