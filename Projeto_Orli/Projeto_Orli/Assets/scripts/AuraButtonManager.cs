using UnityEngine;
using UnityEngine.UI;

public class AuraButtonManager : MonoBehaviour
{
    public Button auraButton;
    public Sprite[] auraSprites;

    public void UpdateAuraState(int emotionIndex)
    {
        Debug.Log("Tentando atualizar a aura para emo��o: " + emotionIndex); // Teste

        if (auraButton != null && auraButton.image != null && emotionIndex >= 0 && emotionIndex < auraSprites.Length)
        {
            auraButton.image.sprite = auraSprites[emotionIndex]; // Atualiza a imagem
            Debug.Log("Imagem da aura alterada para: " + auraSprites[emotionIndex].name);
        }
        else
        {
            Debug.LogWarning("Erro ao atualizar a aura: �ndice inv�lido ou bot�o n�o atribu�do.");
        }
    }
}
