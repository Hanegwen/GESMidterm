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
        currentState = States.patrol;
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

                myRigidbody.velocity = new Vector2(transform.localScale.x * PatrolSpeed * -1, myRigidbody.velocity.y);

                if(isFlip)
                {
                    myRigidbody.velocity = new Vector2(transform.localScale.x * PatrolSpeed, myRigidbody.velocity.y);
                }

                break;

            case States.attack:
                MoveSpeed = 3f;
                MovetoPlayer();
                Debug.Log(Player.name);

                    AutoAttack();

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
            Player = other.gameObject;
            playerFound = true;
            currentState = States.attack;
        }


    }


    void MovetoPlayer()
    {

        /*if (playerFound == true)
            if (Player.transform.position.x - this.transform.position.x > 0)
            {
                transform.Translate(new Vector3(MoveSpeed * Time.deltaTime, 0, 0)); //Right
            }

        else
            {
                transform.Translate(new Vector3(MoveSpeed * Time.deltaTime * -1, 0, 0)); //Left
            }
            */

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
