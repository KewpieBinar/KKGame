using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BahanMakanan : MonoBehaviour
{
    public void Pickup()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
    }

    public void Drop()
    {
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
