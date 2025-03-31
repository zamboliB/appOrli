using UnityEngine;
using UnityEngine.UI;

public class ToggleBiometria : MonoBehaviour
{
    public Toggle toggle; // O botão Toggle
    public Image fundoToggle; // O fundo do Toggle
    public RectTransform checkmark; // A bolinha que se move

    public Color corDesligado = Color.gray; // Cor quando está desligado
    public Color corLigado = Color.green; // Cor quando está ligado

    private Vector2 posInicial = new Vector2(-12, 0); // Ajuste para posição inicial (mais à esquerda)
    private Vector2 posFinal = new Vector2(12, 0); // Ajuste para posição final (mais à direita)

    void Start()
    {
        // Adiciona a função ao evento do Toggle
        toggle.onValueChanged.AddListener(MudarEstado);

        // Atualiza a aparência inicial
        AtualizarVisual();
    }

    void MudarEstado(bool estado)
    {
        // Muda a cor do fundo
        fundoToggle.color = estado ? corLigado : corDesligado;

        // Move a bolinha para a posição correta
        checkmark.anchoredPosition = estado ? posFinal : posInicial;
    }

    void AtualizarVisual()
    {
        // Define a aparência inicial do Toggle
        MudarEstado(toggle.isOn);
    }
}
