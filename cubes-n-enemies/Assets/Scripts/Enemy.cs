using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float stopDistance = 2f;
    private TimeManager timeManager;
    [SerializeField] private GameObject deadEffectsEnemy;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > stopDistance && timeManager.gameOver == false && timeManager.gameFinished == false)
            {
                transform.position += transform.forward * enemySpeed * Time.deltaTime;
            }
        }
    }
    private void OnDisable()
    {
        DestroyEffects(deadEffectsEnemy, gameObject.transform);
    }
    private void DestroyEffects(GameObject effects, Transform effectsTransform)
    {
        Instantiate(effects, effectsTransform.position, effectsTransform.rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            timeManager.gameOver = true;
            
        }
    }
}
