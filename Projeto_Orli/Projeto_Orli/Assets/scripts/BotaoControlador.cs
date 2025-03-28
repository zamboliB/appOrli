using UnityEngine;
using UnityEngine.UI;

public class BotaoControlador : MonoBehaviour
{
    public Image fundoBotao; // A imagem de fundo do bot�o
    public Button outroBotao1; // Outro bot�o que ser� desativado quando este for ativado
    public Button outroBotao2; // O terceiro bot�o que ser� desativado
    public Color corAtivo; // Cor quando o bot�o estiver ativo
    public Color corInativo; // Cor quando o bot�o estiver inativo

    private void Start()
    {
        // Inicializa o estado do bot�o (se n�o estiver selecionado, fica inativo)
        fundoBotao.color = corInativo;
    }

    public void AlterarEstado()
    {
        // Desativa os outros dois bot�es (torna as cores deles inativas)
        outroBotao1.GetComponent<BotaoControlador>().AtualizarBotao(false);
        outroBotao2.GetComponent<BotaoControlador>().AtualizarBotao(false);

        // Ativa o bot�o atual
        AtualizarBotao(true);
    }

    public void AtualizarBotao(bool ativo)
    {
        // Atualiza a cor do fundo com base no estado
        fundoBotao.color = ativo ? corAtivo : corInativo;
    }
}
