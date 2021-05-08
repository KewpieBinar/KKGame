using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public float moveSpeed;
    public float rotSpeed;
    public float gravity;
    public float jumpPower;

    PickupSystem pickup;

    private float y;

/*    private Transform pickableObject = null;
    private Transform pickedObject = null;
    [SerializeField]
    private Transform playerHolder;
    [SerializeField]
    private Transform playerDrop;*/

    Vector3 velocity;

    void Start()
    {
        pickup = GetComponent<PickupSystem>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") *Time.deltaTime;
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        if(controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        


        Vector3 dir = transform.forward * z * moveSpeed;
        controller.Move(dir);
        transform.Rotate(Vector3.up * x * rotSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
        }

        controller.Move(velocity * Time.deltaTime);
        

        if(Input.GetKeyDown(KeyCode.O))
        {
            pickup.PickupOrDrop();
        }


        /*if(Input.GetKeyDown(KeyCode.O) && (pickableObject != null ||pickedObject == true))
        {
            if(pickedObject == null)
            {
                PickUpObject();

            }
            else
            {
                DropObject();
            }


        }*/
        
    }

    /*private void DropObject()
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
        
    }*/
}
