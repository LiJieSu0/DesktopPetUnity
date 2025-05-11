using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UISpawner : MonoBehaviour
{
    [SerializeField] private GameObject uiPrefab; // UI prefab (e.g., Button)
    [SerializeField] private Canvas canvas; // Reference to the Canvas

    private void Update()
    {
        // Check for left mouse button click
        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame&& Pet.instance.isMouseInside)
        {
            // Get mouse position in screen coordinates
            Vector2 mousePosition = Mouse.current.position.ReadValue();

            // Convert screen position to local position in Canvas
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                mousePosition,
                canvas.worldCamera, // Set to null if using Screen Space - Overlay
                out localPoint
            );

            // Instantiate UI prefab
            // GameObject uiInstance = Instantiate(uiPrefab, canvas.transform);
            // Set UI position
            uiPrefab.gameObject.SetActive(true);
            RectTransform rectTransform = uiPrefab.GetComponent<RectTransform>();
            localPoint= new Vector2(localPoint.x+100, localPoint.y-120);
            rectTransform.anchoredPosition = localPoint;
            //TODO detect click space and disable the menu
        }
    }
}