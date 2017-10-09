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
        patrol_Search,
        patrol_Found,
        attack_Locate,
        attack_Movement,
        attack_Attack,
        attack_Recharge,
        attack_Results,
        attack_Over,
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

    
    public bool canAttack = true;
    int numShots = 0, maxShots = 2;
    [SerializeField]
    float attackSpeed;
    [SerializeField]
    GameObject MagicCast;
    bool isfacingRight;

    [SerializeField]
    GameObject castPosition;

    // trigger on left, trigger on right

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        myRigidbody = GetComponent<Rigidbody2D>();
        currentState = States.patrol_Search;
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

            case States.patrol_Search:


                if (distance < 2)
                {
                    myRigidbody.velocity = new Vector2(transform.localScale.x * PatrolSpeed, myRigidbody.velocity.y);
                }

                if (distance > 5)
                {
                    myRigidbody.velocity = new Vector2(transform.localScale.x * -PatrolSpeed, myRigidbody.velocity.y);

                }


                break;

            case States.patrol_Found:
                MoveSpeed = 2;
                break;

            case States.attack_Locate:
                break;

            case States.attack_Movement:
                break;

            case States.attack_Attack:
                MoveSpeed = 3f;
                MovetoPlayer();
                Debug.Log(Player.name);
                if (canAttack == true)
                {
                    StartCoroutine(WaitandAttack());
                    canAttack = false;
                }
                break;

 
            default:
                MovetoPlayer();
                break;

            case States.death:
                break;

        }
    }


    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player = other.gameObject;
            playerFound = true;
            currentState = States.attack_Attack;
        }


    }

    void OnCollisionExit2D(Collision2D other)
    {
        playerFound = false;
        currentState = States.patrol_Search;
    }

    void MovetoPlayer()
    {

        if (playerFound == true)
            if (Player.transform.position.x - this.transform.position.x > 0)
            {
                transform.Translate(new Vector3(MoveSpeed * Time.deltaTime, 0, 0)); //Right
            }

        else
            {
                transform.Translate(new Vector3(MoveSpeed * Time.deltaTime * -1, 0, 0)); //Left
            }


    }

    IEnumerator TurnAround()
    {
        // suspend execution for 5 seconds


        yield return new WaitForSeconds(2);
        Flip();



    }

    public void Flip()
    {

        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }

    void AutoAttack()
    {

        //Instantiate(MagicCast, castPosition.transform.position, transform.rotation);

        

    }

    IEnumerator WaitandAttack()
    {
        // suspend execution for 5 seconds

        for (int i = numShots; i < maxShots; i++)
        {
            AutoAttack();
        }
        yield return new WaitForSeconds(attackSpeed);
        numShots = 0;
        canAttack = true;
    }

}
