using UnityEngine;

public class EmotionSelector : MonoBehaviour
{
    private int selectedEmotion = -1; // Nenhuma emoção escolhida inicialmente
    public EmotionGraphManager graphManager; // Referência ao gráfico

    public void SelectEmotion(int emotionNumber)
    {
        selectedEmotion = emotionNumber - 1; // Ajusta de 1-9 para 0-8
    }

    public void ConfirmSelection()
    {
        if (selectedEmotion >= 0 && selectedEmotion < 9) // Garantir que seja válido
        {
            graphManager.UpdateSingleEmotion(selectedEmotion); // Atualiza o gráfico diretamente
        }
    }
}


