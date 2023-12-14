using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;

    private Transform[] backgroundObjects;
    private float[] objectWidths;

    void Start()
    {
        // Get all background objects
        backgroundObjects = new Transform[transform.childCount];
        objectWidths = new float[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            backgroundObjects[i] = transform.GetChild(i);

            // Check if the current child has a SpriteRenderer
            SpriteRenderer spriteRenderer = backgroundObjects[i].GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                objectWidths[i] = spriteRenderer.bounds.size.x;
            }
            else
            {
                Debug.LogError($"Child object {i} is missing a SpriteRenderer component!");
            }
        }
    }

    void Update()
    {
        MoveBackground();
        CheckAndReposition();
    }

    void MoveBackground()
    {
        if (backgroundObjects != null)
        {
            float moveAmount = scrollSpeed * Time.deltaTime;

            // Move each background object individually
            for (int i = 0; i < backgroundObjects.Length; i++)
            {
                if (backgroundObjects[i] != null)
                {
                    backgroundObjects[i].Translate(Vector3.left * moveAmount);
                }
            }
        }
    }

    void CheckAndReposition()
    {
        if (backgroundObjects != null && objectWidths != null)
        {
            // Check if each background object is off-screen and reposition if needed
            for (int i = 0; i < backgroundObjects.Length; i++)
            {
                if (backgroundObjects[i] != null && objectWidths[i] > 0f)
                {
                    if (backgroundObjects[i].position.x < -objectWidths[i])
                    {
                        RepositionBackground(i);
                        Debug.Log($"Repositioning object {i}");
                    }
                }
            }
        }
    }

    void RepositionBackground(int index)
    {
        if (backgroundObjects != null && objectWidths != null)
        {
            // Reposition the specified background object to the opposite side
            Vector3 newPos = backgroundObjects[index].position;
            newPos.x += 2 * objectWidths[index];
            backgroundObjects[index].position = newPos;
        }
    }
}