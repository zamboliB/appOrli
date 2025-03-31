using UnityEngine;
using UnityEngine.UI; // Para acessar o Button e o Text

public class trocaFundosentir : MonoBehaviour
{
    public Button[] botoesSentimentos; // Lista de botões dos sentimentos
    public Image fundoImagem; // A imagem de fundo que vai mudar
    public Text textoBotao; // O texto do botão
    public Sprite[] imagensFundo; // Imagens para cada sentimento
    public Color[] coresTexto; // Cores para cada sentimento

    private void Start()
    {
        // Inicializa os botões com a função de alteração de cor e imagem
        foreach (Button botao in botoesSentimentos)
        {
            botao.onClick.AddListener(() => MudarSentimento(botao));
        }
    }

    void MudarSentimento(Button botaoSelecionado)
    {
        // Encontra o índice do botão pressionado
        int indiceSentimento = System.Array.IndexOf(botoesSentimentos, botaoSelecionado);

        // Muda a imagem de fundo do botão
        fundoImagem.sprite = imagensFundo[indiceSentimento];

        // Muda a cor do texto
        textoBotao.color = coresTexto[indiceSentimento];

        // Aqui, você pode adicionar mais lógica para personalizar ainda mais o comportamento, como trocar a cor de fundo do próprio botão se necessário
        botaoSelecionado.image.color = coresTexto[indiceSentimento]; // Altera a cor do fundo do botão também
    }
}