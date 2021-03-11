using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private Node prefab;

    [SerializeField, Min(0.1f)]
    private float spacing = 1;
    [SerializeField]
    private Vector3Int size = Vector3Int.one * 20;

    // Runs everytime a variable is updated within the inspector.
    private void OnValidate()
    {
        // Clamp prevents the passed value from going outside the bounds passed
        size.x = Mathf.Clamp(size.x, 1, 100);
        size.y = Mathf.Clamp(size.y, 1, 100);
        size.z = Mathf.Clamp(size.z, 1, 100);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int z = 0; z < size.z; z++)
                {
                    Vector3 position = new Vector3((x * spacing) + 0.5f, (y * spacing) + 0.5f, (z * spacing) + 0.5f);
                    Transform newNode = Instantiate(prefab, position, Quaternion.identity, transform).transform;

                    newNode.localScale = Vector3.one * spacing;
                }
            }
        }
    }
}
