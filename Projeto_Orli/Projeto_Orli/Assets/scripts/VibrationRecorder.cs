using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VibrationRecorder : MonoBehaviour, IPointerClickHandler
{
    public GameObject imagePrefab; // Prefab da imagem que será instanciada
    public GameObject[] textsToHide; // Textos que desaparecerão no primeiro toque
    public RectTransform panelRectTransform; // Referência do RectTransform do Panel

    private GameObject currentImage; // A imagem que será instanciada
    private bool hasClicked = false; // Flag para garantir que o texto seja escondido apenas uma vez

    // Este método é chamado quando o usuário clica no Panel
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 clickPosition = eventData.position; // Posição do clique na tela

        // Converte a posição do clique da tela para a coordenada local do Panel
        Vector2 localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, clickPosition, null, out localPosition);

        // Se for o primeiro clique, esconde os textos explicativos
        if (!hasClicked)
        {
            foreach (GameObject text in textsToHide)
            {
                text.SetActive(false); // Esconde os textos explicativos
            }
            hasClicked = true; // Marca que o clique já aconteceu
        }

        // Remove a imagem anterior, caso já exista
        if (currentImage != null)
        {
            Destroy(currentImage);
        }

        // Instancia a nova imagem dentro do Panel
        currentImage = Instantiate(imagePrefab, panelRectTransform);

        // Ajusta a posição da nova imagem para o local do clique
        RectTransform rectTransform = currentImage.GetComponent<RectTransform>();
        rectTransform.localPosition = localPosition;
    }
}
