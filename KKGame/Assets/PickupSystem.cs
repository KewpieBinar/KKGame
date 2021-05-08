
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    private Transform pickableObject = null;
    private Transform pickedObject = null;
    [SerializeField]
    private Transform playerHolder;
    [SerializeField]
    private Transform playerDrop;

    public void PickupOrDrop()
    {
        if ((pickableObject != null || pickedObject == true))
        {
            if (pickedObject == null)
            {
                PickUpObject();

            }
            else
            {
                DropObject();
            }


        }
    }

    private void DropObject()
    {
        pickedObject.parent = null;
        pickedObject.GetComponent<BahanMakanan>().Drop();
        pickedObject.position = playerDrop.position;
        pickedObject = null;
    }

    private void PickUpObject()
    {

        pickedObject = pickableObject;
        Debug.Log("pickup " + pickableObject.name);
        pickedObject.parent = playerHolder;
        pickedObject.localPosition = Vector3.zero;
        pickedObject.rotation = Quaternion.identity;
        pickedObject.GetComponent<BahanMakanan>().Pickup();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") return;
        pickableObject = other.transform;
        Debug.Log("can pickup " + pickableObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("cannot pickup " + pickableObject.name);
        pickableObject = null;

    }
}