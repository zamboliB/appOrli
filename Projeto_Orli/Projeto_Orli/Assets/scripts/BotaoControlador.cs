using UnityEngine;
using UnityEngine.UI;

public class BotaoControlador : MonoBehaviour
{
    public Image fundoBotao; // A imagem de fundo do botão
    public Button outroBotao1; // Outro botão que será desativado quando este for ativado
    public Button outroBotao2; // O terceiro botão que será desativado
    public Color corAtivo; // Cor quando o botão estiver ativo
    public Color corInativo; // Cor quando o botão estiver inativo

    private void Start()
    {
        // Inicializa o estado do botão (se não estiver selecionado, fica inativo)
        fundoBotao.color = corInativo;
    }

    public void AlterarEstado()
    {
        // Desativa os outros dois botões (torna as cores deles inativas)
        outroBotao1.GetComponent<BotaoControlador>().AtualizarBotao(false);
        outroBotao2.GetComponent<BotaoControlador>().AtualizarBotao(false);

        // Ativa o botão atual
        AtualizarBotao(true);
    }

    public void AtualizarBotao(bool ativo)
    {
        // Atualiza a cor do fundo com base no estado
        fundoBotao.color = ativo ? corAtivo : corInativo;
    }
}
