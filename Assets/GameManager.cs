using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] GameObject columnPrefab;
    public bool start = false;
    public bool Move = false;
    public int score = 0;
    public int best;
    [SerializeField] TMP_Text scoreTMP;
    [SerializeField] TMP_Text scoreTMPBOARD;
    [SerializeField] TMP_Text bestScore;
    void Awake() {
        if (PlayerPrefs.HasKey("Best"))
        {
            best = PlayerPrefs.GetInt("Best");
        }
    }
    void spawnCollumn() {
        GameObject column = Instantiate(columnPrefab);
        column.transform.position = new Vector2(topRight.x + 5, 0);
    }
    public Vector2 bottomLeft, topRight;
    public Vector2 BottomLeft {
        get; private set;

    }
    public Vector2 TopRight {
        get; private set;

    }
    public int Score {
        get {return score;} 
        set {
            score = value;
            scoreTMP.text = score.ToString();
            if (best < score) {
                best = value;
            }
        }
    }
    
    void Start()
    {
        
        Camera Camera = GetComponent<Camera>();
        bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        
        

    }
    public void startColumn(){
        if (start == true){
            InvokeRepeating(nameof(spawnCollumn), 2, 2f);
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
       if (Move) {
            CancelInvoke();
       }
       scoreTMPBOARD.text = $"{score}";
       bestScore.text = best.ToString();
    }
}
