using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowElements_sentirmentos : MonoBehaviour
{
    public GameObject[] elementosParaMostrar; // Bot�es e textos que aparecer�o
    public GameObject[] elementosParaEsconder; // Bot�o principal e textos iniciais

    private bool estaVisivel = false;
    private static ShowElements_sentirmentos botaoAtivo = null; // Armazena o bot�o atualmente ativo

    public Image screenBackground; // Fundo da tela
    public Sprite backgroundSprite; // Imagem de fundo da tela ao clicar no bot�o
    public Sprite buttonSprite; // Nova imagem do bot�o
    public Color textColor; // Nova cor do texto

    private Image buttonImage;
    private TextMeshProUGUI buttonText;

    // Estado original do bot�o
    private Sprite originalButtonSprite;
    private Color originalTextColor;
    private bool isActive = false; // Verifica se este bot�o est� ativo

    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        if (buttonImage != null) originalButtonSprite = buttonImage.sprite;
        if (buttonText != null) originalTextColor = buttonText.color;

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
        // Se este bot�o j� est� ativo, n�o faz nada
        if (isActive) return;

        // Resetar o bot�o ativo anterior (se houver)
        if (botaoAtivo != null)
        {
            botaoAtivo.ResetButton();
        }

        // Atualizar este bot�o como ativo
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




