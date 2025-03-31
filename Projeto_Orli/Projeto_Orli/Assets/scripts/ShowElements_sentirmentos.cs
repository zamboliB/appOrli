using UnityEngine;

public class ShowElements_sentirmentos : MonoBehaviour
{
    public GameObject[] elementosParaMostrar; // Bot�es e textos que aparecer�o
    public GameObject[] elementosParaEsconder; // Bot�o principal e textos que desaparecer�o
    public GameObject botaoVoltar; // Bot�o de voltar

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

        // Ativar o bot�o de voltar quando os novos elementos aparecerem
        if (botaoVoltar != null)
        {
            botaoVoltar.SetActive(estaVisivel);
        }
    }

    public void Voltar()
    {
        // Esconde os elementos mostrados
        foreach (GameObject elemento in elementosParaMostrar)
        {
            elemento.SetActive(false);
        }

        // Reaparece os elementos escondidos antes
        foreach (GameObject elemento in elementosParaEsconder)
        {
            elemento.SetActive(true);
        }

        // Esconde o bot�o de voltar
        if (botaoVoltar != null)
        {
            botaoVoltar.SetActive(false);
        }

        estaVisivel = false;
    }
}
