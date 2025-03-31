using UnityEngine;

public class ShowElements_sentirmentos : MonoBehaviour
{
    public GameObject[] elementosParaMostrar; // Botões e textos que aparecerão
    public GameObject[] elementosParaEsconder; // Botão principal e textos que desaparecerão
    public GameObject botaoVoltar; // Botão de voltar

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

        // Ativar o botão de voltar quando os novos elementos aparecerem
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

        // Esconde o botão de voltar
        if (botaoVoltar != null)
        {
            botaoVoltar.SetActive(false);
        }

        estaVisivel = false;
    }
}
