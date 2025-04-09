using UnityEngine;
using UnityEngine.UI;

public class BotaoBio : MonoBehaviour
{

    public Color corDesligado = new Color32(104,107,107,255); // Cor quando está desligado
    public Color corLigado = new Color32(248, 151, 209, 255); // Cor quando está ligado
    public Image fundoToggle; // O fundo do Toggle
    public RectTransform checkmark; // A bolinha que se move

    private Vector2 posInicial = new Vector2(-8.5f, 0); // Ajuste para posição inicial (mais à esquerda)
    private Vector2 posFinal = new Vector2(8.499994f, 0); // Ajuste para posição final (mais à direita)
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
            fundoToggle.color = new Color32(248, 151, 209, 255); // Cor quando está ligado
;
        }
        else
        {
            checkmark.anchoredPosition = posInicial;
            fundoToggle.color = new Color32(104, 107, 107, 255);
        }
        

    }
}
