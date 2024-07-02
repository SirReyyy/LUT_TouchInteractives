using UnityEngine;

public class PoleSpawner : MonoBehaviour
{
    private PoleGestureListener poleGestureListener;
    private bool isReseting = false;

    public GameObject prefab; // Prefab to spawn
    public int rows, columns; // Number of columns
    private float maxX = 2.2f, minX = -2.2f;
    private float maxY = 1.2f, minY = -1.2f;

    void Start()
    {
        poleGestureListener = PoleGestureListener.Instance;

        SpawnPrefabs();
    }

    void Update()
    {
        if (!poleGestureListener)
            return;

        if(!isReseting) {
            if(poleGestureListener)
            {
                if(poleGestureListener.IsSwipeLeft()) {
                    DeleteAllChildObjects();
                    SpawnPrefabs();
                } else if(poleGestureListener.IsSwipeRight()) {
                    DeleteAllChildObjects();
                    SpawnPrefabs();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            DeleteAllChildObjects();
            SpawnPrefabs();
        }
    }

    void SpawnPrefabs()
    {
        float xSpacing = (maxX - minX) / (columns - 1);
        float ySpacing = (maxY - minY) / (rows - 1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                float xPosition = minX + j * xSpacing;
                float yPosition = minY + i * ySpacing;
                Vector3 spawnPosition = new Vector3(xPosition, yPosition, 4.4f);

                GameObject newPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);
                newPrefab.transform.SetParent(transform);
            }
        }

        isReseting = false;
    }

    public void DeleteAllChildObjects() {
        isReseting = true;

        if(transform.childCount != 0) {
            foreach (Transform child in transform) {
                Destroy(child.gameObject);
            }
        }
    }
}
