using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowElements_sentirmentos : MonoBehaviour
{
    public GameObject[] elementosParaMostrar; // Botões e textos que aparecerão
    public GameObject[] elementosParaEsconder; // Botão principal e textos iniciais

    private bool estaVisivel = false;
    private static ShowElements_sentirmentos botaoAtivo = null; // Armazena o botão atualmente ativo

    public Image screenBackground; // Fundo da tela
    public Sprite backgroundSprite; // Imagem de fundo da tela ao clicar no botão
    public Sprite buttonSprite; // Nova imagem do botão
    public Color textColor; // Nova cor do texto

    private Image buttonImage;
    private TextMeshProUGUI buttonText;

    // Estado original do botão
    private Sprite originalButtonSprite;
    private Color originalTextColor;
    private bool isActive = false; // Verifica se este botão está ativo

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
        // Se este botão já está ativo, não faz nada
        if (isActive) return;

        // Resetar o botão ativo anterior (se houver)
        if (botaoAtivo != null)
        {
            botaoAtivo.ResetButton();
        }

        // Atualizar este botão como ativo
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




