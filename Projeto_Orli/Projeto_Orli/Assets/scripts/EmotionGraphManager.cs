using UnityEngine;
using TMPro;

public class EmotionGraphManager : MonoBehaviour
{
    public GameObject[] emotionBars;  // Array para armazenar os 9 grupos de emo��es
    public TextMeshProUGUI[] dayTexts;  // Array para armazenar os textos de contagem
    private int[] emotionValues = new int[9];  // Array para armazenar os valores (0 a 7) de cada emo��o

    void Start()
    {
        if (emotionValues == null || emotionValues.Length == 0)
        {
            emotionValues = new int[9]; // Inicializa um array de 9 emo��es com 0
        }
        UpdateGraph(); // Atualiza o gr�fico sem sobrescrever os valores
    }

    // Fun��o para atualizar os valores do gr�fico
    public void UpdateGraph()
    {
        for (int i = 0; i < emotionBars.Length; i++)
        {
            UpdateEmotionBar(i, emotionValues[i]);
        }
    }

    // Atualiza uma �nica barra de emo��o
    void UpdateEmotionBar(int index, int value)
    {
        if (index < 0 || index >= emotionBars.Length) return; // Evita erros de �ndice fora do limite

        // Desativa todas as partes da barra antes de ativar a correta
        for (int j = 0; j < 8; j++)
        {
            emotionBars[index].transform.GetChild(j).gameObject.SetActive(false);
        }

        // Ativa a barra correspondente ao valor
        if (value >= 0 && value < 8)
        {
            emotionBars[index].transform.GetChild(value).gameObject.SetActive(true);
        }

        // Atualiza o texto para mostrar o valor correto com "D"
        if (dayTexts[index] != null)
        {
            dayTexts[index].text = value.ToString() + "D";
        }
    }

    // Fun��o para receber os dados externos (exemplo: vindos do app)
    public void SetEmotionData(int[] newValues)
    {
        if (newValues.Length != emotionValues.Length) return; // Evita erro caso o array tenha tamanho errado

        emotionValues = newValues;
        UpdateGraph();
    }
    public void UpdateSingleEmotion(int emotionIndex)
    {
        if (emotionIndex >= 0 && emotionIndex < 9)
        {
            emotionValues[emotionIndex]++; // Aumenta a contagem da emo��o escolhida
            UpdateGraph(); // Atualiza o gr�fico
        }
    }
}
