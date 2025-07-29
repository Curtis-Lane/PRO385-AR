using UnityEngine;

public class RayCastSender : MonoBehaviour
{
    JengaBlock currentBlock;
    private bool available = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (available)
        {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 500);
            if (hit.rigidbody)
            {
                currentBlock = hit.rigidbody.gameObject.GetComponent<JengaBlock>();
                if (currentBlock != null)
                {
                    currentBlock.MarkHovered();
                }
            }
        }
    }

    public void Lock()
    {
        if(currentBlock != null)
        {
            currentBlock.Lock(transform);
            available = false;
        }
    }

    public void Unlock()
    {
        if (currentBlock != null)
        {
            available = true;
            currentBlock.Unlock();
        }
    }


    public void Send()
    {
        if(available)
        {
            Lock();
        }
        else
        {
            Unlock();
        }
    }
}
