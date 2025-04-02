using UnityEngine;
using TMPro;

public class EmotionGraphManager : MonoBehaviour
{
    public GameObject[] emotionBars;  // Array para armazenar os 9 grupos de emo��es
    public TextMeshProUGUI[] dayTexts;  // Array para armazenar os textos de contagem
    private int[] emotionValues = new int[9];  // Array para armazenar os valores (0 a 7) de cada emo��o

    void Start()
    {
        // Definir valores iniciais de teste
        SetEmotionData(new int[9]);
    }

    // Fun��o para atualizar os valores do gr�fico
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
            emotionValues[emotionIndex]++; // Aumenta o valor dessa emo��o
            if (emotionValues[emotionIndex] > 7)
            {
                emotionValues[emotionIndex] = 7; // Garante que n�o passe de 7
            }
            UpdateGraph(); // Atualiza o gr�fico com o novo valor
        }
    }
    // Atualiza uma �nica barra de emo��o
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

    // Fun��o para receber os dados externos (exemplo: vindos do app)
    public void SetEmotionData(int[] newValues)
    {
        emotionValues = newValues;
        UpdateGraph();

    }

    // **Nova fun��o para ativar/desativar o gr�fico**
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

