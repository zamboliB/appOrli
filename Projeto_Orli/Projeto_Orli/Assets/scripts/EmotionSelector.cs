using UnityEngine;

public class EmotionSelector : MonoBehaviour
{
    private int selectedEmotion = -1; // Nenhuma emo��o escolhida inicialmente
    public EmotionGraphManager graphManager; // Refer�ncia ao gr�fico

    public void SelectEmotion(int emotionNumber)
    {
        selectedEmotion = emotionNumber - 1; // Ajusta de 1-9 para 0-8
    }

    public void ConfirmSelection()
    {
        if (selectedEmotion >= 0 && selectedEmotion < 9) // Garantir que seja v�lido
        {
            graphManager.UpdateSingleEmotion(selectedEmotion); // Atualiza o gr�fico diretamente
        }
    }
}


