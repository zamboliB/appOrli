using UnityEngine;
using TMPro;

public class EmotionGraphManager : MonoBehaviour
{
    public GameObject[] emotionBars;  // Array para armazenar os 9 grupos de emoções
    public TextMeshProUGUI[] dayTexts;  // Array para armazenar os textos de contagem
    private int[] emotionValues = new int[9];  // Array para armazenar os valores (0 a 7) de cada emoção

    void Start()
    {
        // Definir valores iniciais de teste
        SetEmotionData(new int[9]);
    }

    // Função para atualizar os valores do gráfico
    public void UpdateGraph()
    {
        for (int i = 0; i < emotionBars.Length; i++)
        {
            UpdateEmotionBar(i, emotionValues[i]);
        }
    }
    public void UpdateSingleEmotion(int emotionIndex)
    {
        if (emotionIndex >= 0 && emotionIndex < emotionValues.Length)
        {
            emotionValues[emotionIndex]++; // Aumenta o valor dessa emoção
            if (emotionValues[emotionIndex] > 7)
            {
                emotionValues[emotionIndex] = 7; // Garante que não passe de 7
            }
            UpdateGraph(); // Atualiza o gráfico com o novo valor
        }
    }
    // Atualiza uma única barra de emoção
    void UpdateEmotionBar(int index, int value)
    {
        // Desativa todas as partes da barra
        for (int j = 0; j < 8; j++)
        {
            emotionBars[index].transform.GetChild(j).gameObject.SetActive(false);
        }

        // Ativa a barra correspondente ao valor
        if (value >= 0 && value < 8)
        {
            emotionBars[index].transform.GetChild(value).gameObject.SetActive(true);
        }

        // Atualiza o texto com a contagem de dias
        dayTexts[index].text = value.ToString() + "D";
    }

    // Função para receber os dados externos (exemplo: vindos do app)
    public void SetEmotionData(int[] newValues)
    {
        emotionValues = newValues;
        UpdateGraph();

    }

    // **Nova função para ativar/desativar o gráfico**
    public void SetGraphVisibility(bool isVisible)
    {
        foreach (var bar in emotionBars)
        {
            bar.SetActive(isVisible);
        }

        foreach (var text in dayTexts)
        {
            text.gameObject.SetActive(isVisible);
        }
    }
}

