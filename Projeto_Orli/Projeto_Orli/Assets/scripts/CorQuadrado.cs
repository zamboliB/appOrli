using UnityEngine;
using UnityEngine.UI;

public class CorQuadrado : MonoBehaviour
{
    public Image quadrado;

    // Função que muda a cor do quadrado, com parâmetro
    public void MudarCor(Color novaCor)
    {
        quadrado.color = novaCor;
    }

    // Função sem parâmetros, para ser usada no Unity Button
    public void MudarCorSemParametros(Color novaCor)
    {
        quadrado.color = novaCor;
    }
}
