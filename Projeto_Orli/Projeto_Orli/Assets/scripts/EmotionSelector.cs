using UnityEngine;

public class EmotionSelector : MonoBehaviour
{
    private int selectedEmotion = -1;
    public EmotionGraphManager graphManager;
    public AuraButtonManager auraManager;

    public void SelectEmotion(int emotionNumber)
    {
        selectedEmotion = emotionNumber - 1;
    }

    public void ConfirmSelection()
    {
        if (selectedEmotion >= 0 && selectedEmotion < 9)
        {
            graphManager.UpdateSingleEmotion(selectedEmotion);

            if (auraManager != null)
            {
                auraManager.UpdateAuraState(selectedEmotion);
            }
        }
    }
}

