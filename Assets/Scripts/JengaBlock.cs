using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class JengaBlock : MonoBehaviour
{
    private Rigidbody rb;
    private Transform baseParent;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private Color unhoveredColor;
    [SerializeField] private Color hoveredColor;
    [SerializeField] private Color selectedColor;
    private bool currentlyHovered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.useGravity)
        {

            if (currentlyHovered)
            {
                mesh.material.color = hoveredColor;
            }
            else
            {
                mesh.material.color = hoveredColor;
            }
            currentlyHovered = false;
            rb.AddForce(Vector3.down * Time.deltaTime);
        }
    }


    public void Lock(Transform t)
    {
        rb.isKinematic = true;
        rb.useGravity = false;
        baseParent = transform.parent;
        transform.parent = t;
        mesh.material.color = selectedColor;
    }

    public void Unlock()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        transform.parent = baseParent;
        mesh.material.color = hoveredColor;
    }

    public void MarkHovered()
    {
        currentlyHovered = true;
    }

}
