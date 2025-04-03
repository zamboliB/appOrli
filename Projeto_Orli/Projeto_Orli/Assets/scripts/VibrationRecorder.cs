using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VibrationRecorder : MonoBehaviour, IPointerClickHandler
{
    public GameObject imagePrefab; // Prefab da imagem que ser� instanciada
    public GameObject[] textsToHide; // Textos que desaparecer�o no primeiro toque
    public RectTransform panelRectTransform; // Refer�ncia do RectTransform do Panel

    private GameObject currentImage; // A imagem que ser� instanciada
    private bool hasClicked = false; // Flag para garantir que o texto seja escondido apenas uma vez

    // Este m�todo � chamado quando o usu�rio clica no Panel
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 clickPosition = eventData.position; // Posi��o do clique na tela

        // Converte a posi��o do clique da tela para a coordenada local do Panel
        Vector2 localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, clickPosition, null, out localPosition);

        // Se for o primeiro clique, esconde os textos explicativos
        if (!hasClicked)
        {
            foreach (GameObject text in textsToHide)
            {
                text.SetActive(false); // Esconde os textos explicativos
            }
            hasClicked = true; // Marca que o clique j� aconteceu
        }

        // Remove a imagem anterior, caso j� exista
        if (currentImage != null)
        {
            Destroy(currentImage);
        }

        // Instancia a nova imagem dentro do Panel
        currentImage = Instantiate(imagePrefab, panelRectTransform);

        // Ajusta a posi��o da nova imagem para o local do clique
        RectTransform rectTransform = currentImage.GetComponent<RectTransform>();
        rectTransform.localPosition = localPosition;
    }
}
