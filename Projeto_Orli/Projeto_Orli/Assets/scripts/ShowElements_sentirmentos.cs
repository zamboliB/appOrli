using UnityEngine;

public class ShowElements_sentirmentos : MonoBehaviour
{
    public GameObject[] elementosParaMostrar; // Bot�es e textos que aparecer�o
    public GameObject[] elementosParaEsconder; // Bot�o principal e textos que desaparecer�o

    private bool estaVisivel = false;

    public void AlternarVisibilidade()
    {
        estaVisivel = !estaVisivel;

        // Mostrar os novos elementos
        foreach (GameObject elemento in elementosParaMostrar)
        {
            elemento.SetActive(estaVisivel);
        }

        // Esconder os elementos (bot�o principal e textos)
        foreach (GameObject elemento in elementosParaEsconder)
        {
            elemento.SetActive(!estaVisivel);
        }
    }
}
