using UnityEngine;
using System.Collections.Generic;
public class BackupBackupClosestFinder : MonoBehaviour
{
    JengaBlock[] blocks;
    Collider[] colliders;
    bool available = true;
    JengaBlock currentBlock;
    [SerializeField] private float maxImperfectionSelectable = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(blocks == null || blocks.Length == 0 || blocks[0] == null)
        {
            blocks = FindObjectsByType<JengaBlock>(FindObjectsSortMode.None);
            colliders = new Collider[blocks.Length];
            for(int i = 0; i < blocks.Length; i++)
            {
                colliders[i] = blocks[i].gameObject.GetComponent<Collider>();
            }
        }
        else
        {
            if(available)
            {
                Vector3 cameraPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));
                (int, float) cur = (-1, float.PositiveInfinity);
                for(int i = 0; i < colliders.Length; i++)
                {
                    float dist = Vector3.Distance(colliders[i].ClosestPoint(cameraPos), cameraPos);
                    Vector3 detectionPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, dist));
                    if(Vector3.Distance(detectionPos, colliders[i].ClosestPoint(cameraPos)) < maxImperfectionSelectable && dist < cur.Item2)
                    {
                        cur = (i, dist);
                    }
                }
                if(cur.Item1 != -1)
                {
                    currentBlock = blocks[cur.Item1];
                    currentBlock.MarkHovered();
                }
                else
                {
                    currentBlock = null;
                }
            }
        }
    }


    public void Lock()
    {
        if (currentBlock != null)
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
        if (available)
        {
            Lock();
        }
        else
        {
            Unlock();
        }
    }


}
