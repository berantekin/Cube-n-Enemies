using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks : MonoBehaviour
{
    MeshRenderer Meshrend;
    //private bool isColided = false;
    // Start is called before the first frame update
    void Start()
    {
        Meshrend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (isColided == false)
        //{
        //    Meshrend.material.color = Color.red;
        //    ScoreManager scoremanager = FindObjectOfType<ScoreManager>();
        //    scoremanager.score--;
        //    isColided = true;
        //}
        if (collision.gameObject.CompareTag("Player"))
        {
            Meshrend.material.color = Color.red;
            ScoreManager scoremanager = FindObjectOfType<ScoreManager>();
            scoremanager.score--;
        }
        

    }
}
