using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{

    public GameObject Mother;
    // Start is called before the first frame update
    void Start()
    {  
        bool x = true;
        while (x) {
            Instantiate(Mother);
            x = false;
        }
    }
}
