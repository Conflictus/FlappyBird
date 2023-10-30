using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float rotationUp = 25f; 
    [SerializeField] float rotationDown = -30f; 
    [SerializeField] float rotationSpeed = 200f; 
    float currentAngle;
    float newAngle;
    public Rigidbody2D playerRigid;
    public bool run = false;
    GameManager gm;
    float targetAngle = 0f;
    private Animator animator;

    pipe Pipe;
    hitS hit;
    banner lose;
    private bool hasCollidedWithBorder = false;
    bool Hitchecker = true;
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        Pipe = FindObjectOfType<pipe>();
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerRigid.simulated = false;
        hit = FindObjectOfType<hitS>();
        lose = FindObjectOfType<banner>();
        
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.Equals("border")){
            playerRigid.simulated = false;
            hasCollidedWithBorder = true;
            gm.Move = true;
            // Сохранение счета
            
            
        }
        if (collision.name.Equals("Square")) {
            playerRigid.velocity = Vector2.zero;
        }
        if (collision.CompareTag("player") && Hitchecker) 
        {   
            hit.playSoud();
            gm.Move = true;
            Hitchecker = false;
         
        }
    }
    void MoveUp()
    {   
        targetAngle = rotationUp;
        playerRigid.velocity = Vector2.up * speed;
        playerRigid.simulated = true;
        
    }
    void MoveDown() {
        targetAngle = rotationDown;
    }
    void Update()
    {
        if (hasCollidedWithBorder && gm.Move == true)
        {
            lose.MoveDown(); // Выполнять действия, связанные со столкновением с "border"
        }
        if (Input.GetMouseButtonDown(0) && gm.Move==false)
        {
            
            animator.SetBool("ClickAnimation", true);
            MoveUp(); 
            if (gm.start == false){
              gm.start = true;
              gm.startColumn();
            }
            
            
            
            
        }
        else if (Vector2.Dot(playerRigid.velocity.normalized, Vector2.up) < 0f)
        {
            MoveDown();
            
        }
            currentAngle = transform.rotation.eulerAngles.z;
            newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
            Vector3 currentPosition = transform.position;
            currentPosition.x = -1f;
            transform.position = currentPosition;
    }
    
}
