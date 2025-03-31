using UnityEngine;
using UnityEngine.UI;

public class ToggleBiometria : MonoBehaviour
{
    public Toggle toggle; // O bot�o Toggle
    public Image fundoToggle; // O fundo do Toggle
    public RectTransform checkmark; // A bolinha que se move

    public Color corDesligado = Color.gray; // Cor quando est� desligado
    public Color corLigado = Color.green; // Cor quando est� ligado

    private Vector2 posInicial = new Vector2(-12, 0); // Ajuste para posi��o inicial (mais � esquerda)
    private Vector2 posFinal = new Vector2(12, 0); // Ajuste para posi��o final (mais � direita)

    void Start()
    {
        // Adiciona a fun��o ao evento do Toggle
        toggle.onValueChanged.AddListener(MudarEstado);

        // Atualiza a apar�ncia inicial
        AtualizarVisual();
    }

    void MudarEstado(bool estado)
    {
        // Muda a cor do fundo
        fundoToggle.color = estado ? corLigado : corDesligado;

        // Move a bolinha para a posi��o correta
        checkmark.anchoredPosition = estado ? posFinal : posInicial;
    }

    void AtualizarVisual()
    {
        // Define a apar�ncia inicial do Toggle
        MudarEstado(toggle.isOn);
    }
}
