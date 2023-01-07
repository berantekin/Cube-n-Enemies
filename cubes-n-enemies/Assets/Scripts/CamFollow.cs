using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 offset;
    [SerializeField] private float camfollowspeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            MoveTheCamera();
        }

    }

    public void MoveTheCamera()
    {

        Vector3 targetb = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetb, camfollowspeed * Time.deltaTime);
        transform.LookAt(playerTransform.transform.position);
    }

    //public Vector3 MoveTheCamv3()

}
