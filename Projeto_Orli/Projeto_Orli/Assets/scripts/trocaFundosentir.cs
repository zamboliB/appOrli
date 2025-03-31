using UnityEngine;
using UnityEngine.UI; // Para acessar o Button e o Text

public class trocaFundosentir : MonoBehaviour
{
    public Button[] botoesSentimentos; // Lista de bot�es dos sentimentos
    public Image fundoImagem; // A imagem de fundo que vai mudar
    public Text textoBotao; // O texto do bot�o
    public Sprite[] imagensFundo; // Imagens para cada sentimento
    public Color[] coresTexto; // Cores para cada sentimento

    private void Start()
    {
        // Inicializa os bot�es com a fun��o de altera��o de cor e imagem
        foreach (Button botao in botoesSentimentos)
        {
            botao.onClick.AddListener(() => MudarSentimento(botao));
        }
    }

    void MudarSentimento(Button botaoSelecionado)
    {
        // Encontra o �ndice do bot�o pressionado
        int indiceSentimento = System.Array.IndexOf(botoesSentimentos, botaoSelecionado);

        // Muda a imagem de fundo do bot�o
        fundoImagem.sprite = imagensFundo[indiceSentimento];

        // Muda a cor do texto
        textoBotao.color = coresTexto[indiceSentimento];

        // Aqui, voc� pode adicionar mais l�gica para personalizar ainda mais o comportamento, como trocar a cor de fundo do pr�prio bot�o se necess�rio
        botaoSelecionado.image.color = coresTexto[indiceSentimento]; // Altera a cor do fundo do bot�o tamb�m
    }
}