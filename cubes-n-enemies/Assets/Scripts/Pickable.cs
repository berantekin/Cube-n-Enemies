using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private GameObject deadEffectsCoin;
    public int ScoreAmount = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDisable()
    {
        DestroyEffects(deadEffectsCoin, gameObject.transform);
    }
    private void DestroyEffects(GameObject effects, Transform effectsTransform)
    {
        Instantiate(effects, effectsTransform.position, effectsTransform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += ScoreAmount;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += ScoreAmount;
            Destroy(gameObject);
        }
    }
}
