using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowElements_sentirmentos : MonoBehaviour
{
    public GameObject[] elementosParaMostrar; // Botões e textos que aparecerão
    public GameObject[] elementosParaEsconder; // Botão principal e textos que desaparecerão

    private bool estaVisivel = false;

    public void AlternarVisibilidade()
    {
        estaVisivel = !estaVisivel;

        // Mostrar novos elementos
        foreach (GameObject elemento in elementosParaMostrar)
        {
            elemento.SetActive(estaVisivel);
        }

        // Esconder elementos (botão principal e textos iniciais)
        foreach (GameObject elemento in elementosParaEsconder)
        {
            elemento.SetActive(!estaVisivel);
        }
    }






    public Image screenBackground; // Fundo da tela
    public Sprite backgroundSprite; // Imagem de fundo da tela ao clicar no botão
    public Sprite buttonSprite; // Nova imagem do botão
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




