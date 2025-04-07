using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class deslizarmusica : MonoBehaviour
{

    public GameObject painelParaMostrar;
    public GameObject[] paineisParaEsconder;

    public Image buttonImage;
    public Sprite buttonSpriteAtivo;
    public Sprite buttonSpriteInativo;

    public TextMeshProUGUI buttonText;
    public Color textoCorAtivo;
    public Color textoCorInativo;

    private static deslizarmusica botaoAtivo;

    private Sprite spriteOriginal;
    private Color corTextoOriginal;
    private bool isActive = false;

    void Start()
    {
        if (buttonImage != null)
            spriteOriginal = buttonImage.sprite;

        if (buttonText != null)
            corTextoOriginal = buttonText.color;

        GetComponent<Button>().onClick.AddListener(AtivarAba);
    }

    public void AtivarAba()
    {
        if (isActive) return;

        // Resetar o anterior
        if (botaoAtivo != null)
        {
            botaoAtivo.ResetarBotao();
        }

        // Ativar novo
        isActive = true;
        botaoAtivo = this;

        // Mostrar painel ativo e esconder os outros
        if (painelParaMostrar != null)
            painelParaMostrar.SetActive(true);

        foreach (GameObject painel in paineisParaEsconder)
        {
            if (painel != null)
                painel.SetActive(false);
        }

        // Alterar aparência do botão ativo
        if (buttonImage != null && buttonSpriteAtivo != null)
            buttonImage.sprite = buttonSpriteAtivo;

        if (buttonText != null)
            buttonText.color = textoCorAtivo;
    }

    public void ResetarBotao()
    {
        isActive = false;

        if (painelParaMostrar != null)
            painelParaMostrar.SetActive(false);

        if (buttonImage != null && buttonSpriteInativo != null)
            buttonImage.sprite = buttonSpriteInativo;

        if (buttonText != null)
            buttonText.color = textoCorInativo;
    }
}





