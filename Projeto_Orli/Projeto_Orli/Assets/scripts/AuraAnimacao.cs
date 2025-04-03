using UnityEngine;
using UnityEngine.UI;

public class AuraAnimacao : MonoBehaviour
{
    public Image auraImage;
    public float velocidade = 1f;
    public float tamanhoMin = 1f, tamanhoMax = 1.2f;
    public Button botaoConectar; // Arraste o bot�o "Conectar" no Unity
    private bool animacaoAtiva = true; // Controla se a anima��o est� rodando

    void Start()
    {
        // Adiciona o evento de clique do bot�o
        botaoConectar.onClick.AddListener(PararAnimacao);
    }

    void Update()
    {
        if (!animacaoAtiva) return; // Se a anima��o foi parada, n�o faz nada

        // Faz a aura crescer e diminuir suavemente
        float scale = Mathf.Lerp(tamanhoMin, tamanhoMax, (Mathf.Sin(Time.time * velocidade) + 1) / 2);
        transform.localScale = Vector3.one * scale;

        // Suaviza a opacidade para criar efeito de brilho
        float alpha = Mathf.Lerp(0.8f, 1.2f, (Mathf.Sin(Time.time * velocidade) + 1) / 2);
        auraImage.color = new Color(1, 1, 1, alpha);
    }

    void PararAnimacao()
    {
        animacaoAtiva = false; // Desativa a anima��o ao clicar no bot�o
    }
}
