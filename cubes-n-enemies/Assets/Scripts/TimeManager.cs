using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    public bool gameOver = false;
    public bool gameFinished = false;
    [SerializeField] private float levelFinished = 5f;
    [SerializeField] private TextMeshProUGUI timeText;
    public List<GameObject> destroyAfterGame = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    { 
        if (Time.timeSinceLevelLoad >= levelFinished && gameOver == false)
        {
            gameFinished = true;
            winPanel.SetActive(true);
            losePanel.SetActive(false);
            UpdateListTag("Objects");
            UpdateListTag("Enemy");
            foreach (GameObject allobjects in destroyAfterGame)
            {
                Destroy(allobjects);
            }
        }
        if (gameOver == true)
        {
            winPanel.SetActive(false);
            losePanel.SetActive(true);
            UpdateListTag("Objects");
            UpdateListTag("Enemy");
            foreach (GameObject allobjects in destroyAfterGame)
            {
                Destroy(allobjects);
            }
        }
        if (gameFinished == false && gameOver == false)
        {
            UpdateTheTimer();
        }

    }
    private void UpdateListTag(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag("Objects"));
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }


    private void UpdateTheTimer()
    {
        timeText.text = "Time: " + ((int)Time.timeSinceLevelLoad+1);
    }
}
