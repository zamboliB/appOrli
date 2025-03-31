using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowElements_sentirmentos : MonoBehaviour
{
    public GameObject[] elementosParaMostrar; // Bot�es e textos que aparecer�o
    public GameObject[] elementosParaEsconder; // Bot�o principal e textos que desaparecer�o

    private bool estaVisivel = false;

    public void AlternarVisibilidade()
    {
        estaVisivel = !estaVisivel;

        // Mostrar novos elementos
        foreach (GameObject elemento in elementosParaMostrar)
        {
            elemento.SetActive(estaVisivel);
        }

        // Esconder elementos (bot�o principal e textos iniciais)
        foreach (GameObject elemento in elementosParaEsconder)
        {
            elemento.SetActive(!estaVisivel);
        }
    }






    public Image screenBackground; // Fundo da tela
    public Sprite backgroundSprite; // Imagem de fundo da tela ao clicar no bot�o
    public Sprite buttonSprite; // Nova imagem do bot�o
    public Color textColor; // Nova cor do texto

    private Image buttonImage;
    private TextMeshProUGUI buttonText;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        GetComponent<Button>().onClick.AddListener(ChangeEmotion);
    }

    void ChangeEmotion()
    {
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
    }

}




