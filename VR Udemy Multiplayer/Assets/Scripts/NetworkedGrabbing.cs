using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedGrabbing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectEnter()
    {
        Debug.Log("Grabbed");
    }

    public void OnSelectExited()
    {
        Debug.Log("Released");
    }
}
