using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent robotAgent;
    [SerializeField]
    private NavMeshAgent squishiesAgent;
    [SerializeField]
    private NavMeshSurface robotSurface;
    [SerializeField]
    private NavMeshModifierVolume waterVolume;

    private new Camera camera;

    // Start is called before the first frame update
    void Start() => camera = Camera.main;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera where we clicked on the screen to the world
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                robotAgent.SetDestination(hit.point);
                squishiesAgent.SetDestination(hit.point);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            waterVolume.enabled = !waterVolume.enabled;
            robotSurface.BuildNavMesh();
        }
    }
}
