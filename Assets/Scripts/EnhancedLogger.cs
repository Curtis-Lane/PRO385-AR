using UnityEngine;

public class EnhancedLogger : MonoBehaviour
{
    [SerializeField] private bool position;
    [SerializeField] private bool rotation;
    [SerializeField] private bool scale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(position)
        {
            Debug.Log(transform.position);
        }
        if(rotation)
        {
            Debug.Log(transform.rotation);
        }
        if(scale)
        {
            Debug.Log(transform.localScale);
        }
    }
}
