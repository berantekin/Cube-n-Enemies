using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    public Vector3 move;
    Rigidbody rigidb;
    private TimeManager timeManager;
    [SerializeField]private GameObject deadEffects;


    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();

        if (timeManager.gameOver == true || timeManager.gameFinished == true)
        {
            rigidb.isKinematic = true;
        }


    }

    private void OnDisable()
    {
        DestroyEffects(deadEffects, gameObject.transform);
    }
    private void DestroyEffects(GameObject effects, Transform effectsTransform)
    {
        Instantiate(effects,effectsTransform.position,effectsTransform.rotation);
    }
    public void MoveThePlayer()
    {
        float variablex = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float variablez = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        move = new Vector3(variablex, 0f, variablez);
        //transform.position += move;
        rigidb.AddForce(move);
    }
}
