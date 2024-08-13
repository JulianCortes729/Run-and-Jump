using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaAdjuster : MonoBehaviour
{
   private RectTransform panelSafeArea;
    private Rect lastSafeArea = new Rect(0, 0, 0, 0);
    private Vector2Int lastScreenSize = new Vector2Int(0, 0);
    private ScreenOrientation lastOrientation = ScreenOrientation.AutoRotation;

    void Awake()
    {
        panelSafeArea = GetComponent<RectTransform>();

        if (panelSafeArea == null)
        {
            Debug.LogError("SafeAreaAdjuster script must be attached to a UI element with a RectTransform.");
            return;
        }

        ApplySafeArea();
    }

    void Update()
    {
        // Only apply if something changed
        if (lastSafeArea != Screen.safeArea
            || lastScreenSize.x != Screen.width
            || lastScreenSize.y != Screen.height
            || lastOrientation != Screen.orientation)
        {
            ApplySafeArea();
        }
    }

    void ApplySafeArea()
    {
        Rect safeArea = Screen.safeArea;

        // Convert safe area rectangle from absolute pixels to relative anchors
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        panelSafeArea.anchorMin = anchorMin;
        panelSafeArea.anchorMax = anchorMax;

        // Store variables to detect changes
        lastSafeArea = Screen.safeArea;
        lastScreenSize.x = Screen.width;
        lastScreenSize.y = Screen.height;
        lastOrientation = Screen.orientation;

        Debug.Log("Safe Area applied: " + safeArea);
    }
}
