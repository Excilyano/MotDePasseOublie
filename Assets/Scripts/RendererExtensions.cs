using UnityEngine;
    
public static class RendererExtensions
{
    /// <summary>
    /// Counts the bounding box corners of the given RectTransform that are visible from the given Camera in screen space.
    /// </summary>
    /// <returns>The amount of bounding box corners that are visible from the Camera.</returns>
    /// <param name="rectTransform">Rect transform.</param>
    /// <param name="camera">Camera.</param>
    private static int CountCornersVisibleFrom(this RectTransform rectTransform, Camera camera, Vector3 delta)
    {
        Rect myScreenBounds = GameObject.FindGameObjectWithTag("Screen").GetComponent<RectTransform>().rect;
        Rect screenBounds = new Rect(0f, 0f, myScreenBounds.width, myScreenBounds.height); // Screen space bounds (based on desktop in MotDePasseOublie)
        Vector3[] objectCorners = new Vector3[4];
        rectTransform.GetWorldCorners(objectCorners);
    
        int visibleCorners = 0;
        for (var i = 0; i < objectCorners.Length; i++) // For each corner in rectTransform
        {
            if (screenBounds.Contains(objectCorners[i] + delta)) // If the corner is inside the screen
            {
                visibleCorners++;
            }
        }
        return visibleCorners;
    }
    
    /// <summary>
    /// Determines if this RectTransform is fully visible from the specified camera.
    /// Works by checking if each bounding box corner of this RectTransform is inside the cameras screen space view frustrum.
    /// </summary>
    /// <returns><c>true</c> if is fully visible from the specified camera; otherwise, <c>false</c>.</returns>
    /// <param name="rectTransform">Rect transform.</param>
    /// <param name="camera">Camera.</param>
    public static bool IsFullyVisibleFrom(this RectTransform rectTransform, Camera camera)
    {
        return CountCornersVisibleFrom(rectTransform, camera, Vector2.zero) == 4; // True if all 4 corners are visible
    }

    /// <summary>
    /// Determines if this RectTransform is fully visible from the specified camera, even with the delta translation.
    /// Works by checking if each bounding box corner of this RectTransform is inside the cameras screen space view frustrum.
    /// </summary>
    /// <returns><c>true</c> if is fully visible from the specified camera; otherwise, <c>false</c>.</returns>
    /// <param name="rectTransform">Rect transform.</param>
    /// <param name="camera">Camera.</param>
    /// <param name="delta">Translation</param>
    public static bool IsFullyVisibleFromWithDelta(this RectTransform rectTransform, Camera camera, Vector2 delta)
    {
        Debug.Log("delta : " + delta);
        return CountCornersVisibleFrom(rectTransform, camera, new Vector3(delta.x, delta.y, 0f)) == 4; // True if all 4 corners are visible
    }
}