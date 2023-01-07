using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        TimeManager timeManager = FindObjectOfType<TimeManager>();
        if (collision.gameObject.CompareTag("Player"))
        {
            timeManager.gameOver = true;
        }
        Destroy(collision.gameObject);
    }
}
