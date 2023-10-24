using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://www.youtube.com/watch?v=tz2fRF2GnqY
public class InstantiateObject : MonoBehaviour
{
    // Gives us a place to drag and drop the prefab object
    public GameObject myPrefabObject = null;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate (
            myPrefabObject, // use the prefab object
            transform.position, // positions the prefab in the center
            Quaternion.identity // gives no rotation to the prefab
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
