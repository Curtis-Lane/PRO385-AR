using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RayCastSender : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
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
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 500);
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 500, Color.red);
            if (hit.rigidbody)
            {
                print("rigidbody hit");
                currentBlock = hit.rigidbody.gameObject.GetComponent<JengaBlock>();
                if (currentBlock != null)
                {
                    print("block hit");
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
