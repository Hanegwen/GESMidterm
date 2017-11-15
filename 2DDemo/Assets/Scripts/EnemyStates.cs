using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{

    private Dictionary<int, States> battleStateHash = new Dictionary<int, States>();

    [SerializeField]
    LayerMask PlayerLayer;

    [SerializeField]
    private States currentState;

    enum States
    {
        patrol,
        attack,
        death
    }

    [SerializeField]
    GameObject Player;

    [SerializeField]
    float MoveSpeed;

    [SerializeField]
    float PatrolSpeed;

    bool playerFound = false;

    Random ran;
    Vector3 position;
    Rigidbody2D myRigidbody;

    [SerializeField]
    private float distance;
    bool dead = false;

    [SerializeField]
    bool isFlip;
    [SerializeField]
    float attackSpeed;
    [SerializeField]
    GameObject MagicCast;
    bool isfacingRight;

    [SerializeField]
    GameObject castPosition;

    Animator enemyAnimator;

    [SerializeField]
    float attackTimer = 0;

 

    // Use this for initialization
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        myRigidbody = GetComponent<Rigidbody2D>();
        currentState = States.patrol;
        PatrolSpeed = 1;
    }

    void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {


        distance = Vector3.Distance(this.transform.position, Player.transform.position);


        Debug.Log(currentState.ToString());
        switch (currentState)
        {

            case States.patrol:
                if (distance < 10)
                {
                    enemyAnimator.SetFloat("Speed", PatrolSpeed);
                    if (distance < 5)
                    {
                        currentState = States.attack;
                    }
                }
                myRigidbody.velocity = new Vector2(transform.localScale.x * PatrolSpeed * -1, myRigidbody.velocity.y);

                if(isFlip)
                {
                    myRigidbody.velocity = new Vector2(transform.localScale.x * PatrolSpeed, myRigidbody.velocity.y);
                }

                break;

            case States.attack:
                enemyAnimator.SetFloat("Speed", MoveSpeed);
                MoveSpeed = 3f;
                MovetoPlayer();
                Debug.Log(Player.name);
                AutoAttack();
                CheckDistance();

                if (attackTimer < 50)
                {
                    attackTimer++;
                }
                else
                {
                    attackTimer = 0;
                    currentState = States.patrol;
                }
                break;

 
            default:
                MovetoPlayer();
                break;

            case States.death:
                break;

        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            attackTimer = 0;
            Player = other.gameObject;
            playerFound = true;
            currentState = States.attack;

            
        }


    }

    void CheckDistance()
    {
        if(Player.transform.position.x - this.gameObject.transform.position.x > 10 || Player.transform.position.x - this.gameObject.transform.position.x <-10)
        {

        }
    }

    void MovetoPlayer()
    {

        if (playerFound == true)
            if (Player.transform.position.x > this.transform.position.x)
            {
                if (!isFlip)
                {
                    Flip();
                }
            }

            else
            {
                if (isFlip)
                {
                    Flip();
                }
            }


    }

    public void Flip()
    {
        this.gameObject.transform.Rotate(0, 180, 0);
        isFlip = !isFlip;

    }

    void AutoAttack()
    {

        Instantiate(MagicCast, castPosition.transform.position, transform.rotation);
    }

 
}
