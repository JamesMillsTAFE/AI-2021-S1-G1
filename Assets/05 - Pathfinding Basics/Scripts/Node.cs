using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody), typeof(MeshRenderer))]
public class Node : MonoBehaviour
{
    [SerializeField, Tooltip("The color the node will be when it is not colliding with anything.")]
    private Color safe = Color.green;
    [SerializeField, Tooltip("The color the node will be when it is colliding with blockable object.")]
    private Color ignored = Color.red;

    private new Rigidbody rigidbody;
    private new BoxCollider collider;
    private new MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        collider = gameObject.GetComponent<BoxCollider>();
        collider.isTrigger = true;

        renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material.color = safe;
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider _other)
    {
        TryChangeColor(_other, ignored, false);
    }

    // OnTriggerExit is called when the Collider other has stopped touching the trigger
    private void OnTriggerExit(Collider _other)
    {
        TryChangeColor(_other, safe, true);
    }

    private void TryChangeColor(Collider _other, Color _color, bool _show)
    {
        if(_other.GetComponent<Node>() || !_other.CompareTag("Pathfinding Obstacle"))
            return;

        renderer.material.color = _color;
        renderer.enabled = _show;
    }
}
