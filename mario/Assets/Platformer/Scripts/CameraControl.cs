using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // To get the Player posision
    public GameObject player;

    //To get camera offset from player
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
        {
            // camera transfrom postion - player tranform position
            _offset = transform.position - player.transform.position;
        }
    }

    // Late Update is called once per frame but after all the other updates are done
    void LateUpdate()
    {
        if (player != null)
        {
            // aligns the camera to where the player is, but not the rotation so that's why it's not a child
            transform.position = new Vector3(player.transform.position.x + _offset.x,7.37f,player.transform.position.z + _offset.z);

        }
    }
}
