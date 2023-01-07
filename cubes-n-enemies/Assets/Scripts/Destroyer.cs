using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float Time =  3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,Time);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
