using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {


    GameObject player;

    public float speed = 2.0f;

    public Vector3 offset;


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }


    void Update()
    {

        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp((this.transform.position.y - offset.y), player.transform.position.y, interpolation);
        position.x = Mathf.Lerp((this.transform.position.x - offset.x), player.transform.position.x, interpolation);

        this.transform.position = position;



    }

}
