using UnityEngine;
using UnityEngine.UI;

public class ColorPickerController : MonoBehaviour
{
    [Header("Refer�ncias")]
    [SerializeField] private Image colorDisplay; // A imagem que vai exibir a cor selecionada
    [SerializeField] private Button[] colorButtons; // Todos os bot�es de cor
    [SerializeField] private Color[] colors; // Cores dispon�veis para os bot�es
    [SerializeField] private int initialColorIndex = 0; // �ndice da cor inicial

    private void Start()
    {
        // Verifica se temos o mesmo n�mero de bot�es e cores
        if (colorButtons.Length != colors.Length)
        {
            Debug.LogError("O n�mero de bot�es e cores n�o coincide!");
            return;
        }

        // Configura os bot�es com as cores
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i; // Necess�rio para evitar problemas com o loop
            colorButtons[i].onClick.AddListener(() => OnColorButtonClicked(index));
            colorButtons[i].GetComponent<Image>().color = colors[i]; // Define a cor do bot�o
        }

        // Define a cor inicial
        UpdateColorDisplay(initialColorIndex); // Inicia com a cor correta
    }

    // Atualiza a cor exibida na imagem
    private void UpdateColorDisplay(int index)
    {
        colorDisplay.color = colors[index]; // Altera a cor da imagem de exibi��o
    }

    // Fun��o chamada ao clicar em qualquer bot�o de cor
    private void OnColorButtonClicked(int index)
    {
        UpdateColorDisplay(index); // Atualiza a cor de exibi��o com a cor do bot�o clicado
    }
}
