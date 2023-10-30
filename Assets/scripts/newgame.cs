using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class newgame : MonoBehaviour
{

    player Player;
    GameManager gm;
 
    
    void OnMouseDown() {
        if (gm.Move == true){
        RestartGame();
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene(0);
       
    }
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        Player = FindObjectOfType<player>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
