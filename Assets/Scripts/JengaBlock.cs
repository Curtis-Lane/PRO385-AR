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
    private bool locked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        baseParent = transform.parent;
    }

    private void FixedUpdate()
    {
        if (rb.useGravity)
        {

            if (currentlyHovered)
            {
                mesh.material.color = hoveredColor;
            }
            else
            {
                mesh.material.color = unhoveredColor;
            }
            currentlyHovered = false;
            //rb.AddForce(Vector3.down * Time.deltaTime);
        }
    }


    public void Lock(Transform t)
    {
        if (!locked)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
            baseParent = transform.parent;
            transform.parent = t;
            mesh.material.color = selectedColor;
            locked = true;
        }
    }

    public void Unlock()
    {
        if (locked)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            transform.parent = baseParent;
            mesh.material.color = hoveredColor;
            locked = false;
        }
    }

    public void MarkHovered()
    {
        currentlyHovered = true;
    }

}
