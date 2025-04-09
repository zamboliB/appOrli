using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorPick : MonoBehaviour, IPointerClickHandler
{
    private Image image;
    private RectTransform rectTransform;
    public Image objeto;
    private void Start()
    {
        // Get the Image component and RectTransform
        image = GetComponent<Image>();

        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Make sure the image has a sprite
        if (image.sprite != null)
        {
            // Get the texture of the sprite
            Texture2D texture = image.sprite.texture;

            // Get the click position in local UI space
            Vector2 localPosition = GetLocalPointerPosition(eventData);

            // Convert that position into texture space coordinates
            Vector2 textureCoords = GetTextureCoordinates(localPosition, rectTransform, texture);

            // Sample the color from the texture at that point
            Color clickedColor = texture.GetPixel((int)textureCoords.x, (int)textureCoords.y);
            objeto.GetComponent<Image>().color = clickedColor;
            // Log the color
            Debug.Log("Clicked sprite color: " + clickedColor);
        }
        else
        {
            Debug.Log("No sprite assigned to Image component.");
        }
    }

    private Vector2 GetLocalPointerPosition(PointerEventData eventData)
    {
        // Convert the pointer position from screen space to local UI space
        Vector2 localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localPosition);
        return localPosition;
    }

    private Vector2 GetTextureCoordinates(Vector2 localPosition, RectTransform rectTransform, Texture2D texture)
    {
        // Convert the local position to normalized coordinates (0-1 range)
        Vector2 normalizedCoords = new Vector2(
            Mathf.InverseLerp(-rectTransform.rect.width / 2f, rectTransform.rect.width / 2f, localPosition.x),
            Mathf.InverseLerp(-rectTransform.rect.height / 2f, rectTransform.rect.height / 2f, localPosition.y)
        );

        // Convert normalized coordinates to pixel coordinates in the texture
        Vector2 textureCoords = new Vector2(
            normalizedCoords.x * texture.width,
            normalizedCoords.y * texture.height
        );

        return textureCoords;
    }
}