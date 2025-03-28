using UnityEngine;
using UnityEngine.UI;

public class CorQuadrado : MonoBehaviour
{
    public Image quadrado;

    // Fun��o que muda a cor do quadrado, com par�metro
    public void MudarCor(Color novaCor)
    {
        quadrado.color = novaCor;
    }

    // Fun��o sem par�metros, para ser usada no Unity Button
    public void MudarCorSemParametros(Color novaCor)
    {
        quadrado.color = novaCor;
    }
}
