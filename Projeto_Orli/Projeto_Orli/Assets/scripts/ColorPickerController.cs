using UnityEngine;
using UnityEngine.UI;

public class ColorPickerController : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private Image colorDisplay; // A imagem que vai exibir a cor selecionada
    [SerializeField] private Button[] colorButtons; // Todos os botões de cor
    [SerializeField] private Color[] colors; // Cores disponíveis para os botões
    [SerializeField] private int initialColorIndex = 0; // Índice da cor inicial

    private void Start()
    {
        // Verifica se temos o mesmo número de botões e cores
        if (colorButtons.Length != colors.Length)
        {
            Debug.LogError("O número de botões e cores não coincide!");
            return;
        }

        // Configura os botões com as cores
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i; // Necessário para evitar problemas com o loop
            colorButtons[i].onClick.AddListener(() => OnColorButtonClicked(index));
            colorButtons[i].GetComponent<Image>().color = colors[i]; // Define a cor do botão
        }

        // Define a cor inicial
        UpdateColorDisplay(initialColorIndex); // Inicia com a cor correta
    }

    // Atualiza a cor exibida na imagem
    private void UpdateColorDisplay(int index)
    {
        colorDisplay.color = colors[index]; // Altera a cor da imagem de exibição
    }

    // Função chamada ao clicar em qualquer botão de cor
    private void OnColorButtonClicked(int index)
    {
        UpdateColorDisplay(index); // Atualiza a cor de exibição com a cor do botão clicado
    }
}
