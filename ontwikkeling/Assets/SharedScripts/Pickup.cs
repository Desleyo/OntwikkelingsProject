using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Key>())
        {
            if (collision.gameObject.GetComponent<Key>().normalKey)
            {
                //add key to key inventory
                Debug.Log("key added");
                //destroy key
            }

            if (collision.gameObject.GetComponent<Key>().fakeKey)
            {
                //take off 20 seconds or something
                Debug.Log("time taken off");
                //destroy key
            }
        }
    }
}
