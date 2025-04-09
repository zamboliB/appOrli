using UnityEngine;
using UnityEngine.UI;

public class BotaoBio : MonoBehaviour
{

    public Color corDesligado = new Color32(104,107,107,255); // Cor quando est� desligado
    public Color corLigado = new Color32(248, 151, 209, 255); // Cor quando est� ligado
    public Image fundoToggle; // O fundo do Toggle
    public RectTransform checkmark; // A bolinha que se move

    private Vector2 posInicial = new Vector2(-8.5f, 0); // Ajuste para posi��o inicial (mais � esquerda)
    private Vector2 posFinal = new Vector2(8.499994f, 0); // Ajuste para posi��o final (mais � direita)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TrocaEstado()
    {
        if(fundoToggle.color == new Color32(104, 107, 107, 255))
        {
            checkmark.anchoredPosition = posFinal;
            fundoToggle.color = new Color32(248, 151, 209, 255); // Cor quando est� ligado
;
        }
        else
        {
            checkmark.anchoredPosition = posInicial;
            fundoToggle.color = new Color32(104, 107, 107, 255);
        }
        

    }
}
