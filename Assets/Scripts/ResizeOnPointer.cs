using UnityEngine;
using UnityEngine.EventSystems;

public class ResizeOnPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Vector2 originalSize;
    private Vector2 targetSize;
    public float resizeSpeed = 5f;

    private bool isResizing = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta;
        targetSize = originalSize;
    }

    private void Update()
    {
        if (isResizing)
        {
            rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, targetSize, Time.deltaTime * resizeSpeed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isResizing = true;
        targetSize = originalSize * 1.15f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isResizing = true;
        targetSize = originalSize;
    }
}
