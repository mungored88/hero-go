using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControler : MonoBehaviour
{
    public Animation enemyanimator;
    public CharacterControler owner;
    private bool movement;
    public GameObject StartMove;
    public GameObject EndMove;
    Rigidbody2D rb;

    public float speed;
    public int EnemyLife;
    private Renderer render;

    [Header("attack")]
    public int attackDamage;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public Transform Player;
    
    



    // Start is called before the first frame update
    void Start()
    {
        owner = this.GetComponent<CharacterControler>();
        StartMove.transform.parent = null;
        EndMove.transform.parent = null;
        render = GetComponent<Renderer>();

        if (!movement)
        {
            transform.position = StartMove.transform.position;
        } else
        {
            transform.position = EndMove.transform.position;
        }
        Player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!movement)
        {
            attackOffset = new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, EndMove.transform.position, speed * Time.deltaTime);
            //Debug.Log(transform.position+""+EndMove.transform.position);
            if(transform.position == EndMove.transform.position)
            {
                //Debug.Log("b");
                movement = true;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (movement)
        {
            // Debug.Log("c");
            attackOffset = new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, StartMove.transform.position, speed * Time.deltaTime);
            if (transform.position == StartMove.transform.position)
            {
               // Debug.Log("d");
                movement = false;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if (Player)
        {
            Vector2 target = new Vector2(Player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }else
        {
            Player = GameObject.Find("Player").transform;
        }

        if (Vector2.Distance(Player.position, rb.position) <= attackRange)
        {
           GetComponent<Animator>().SetBool("Attack b",true);
        }
       


    }
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

       
            Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
            if (colInfo != null)
            {

                colInfo.GetComponent<CharacterControler>().TakeDamage(attackDamage);

            }
      
    }
       
    public void TakeDamage(int Damage)
    {
        EnemyLife -= Damage;
        GetComponent<Animator>().SetBool("gethit", true);
        Debug.Log("damage taken");

        if (EnemyLife <= 1)
        {
            render.material.color = Color.red;
        }

        if (EnemyLife <= 0)
        {
            GetComponent<Animator>().SetBool("isdead", true);
            Destroy(this.gameObject);
        }
        
    }
    private void OnDrawGizmosSelected()
    {
       
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOffset, attackRange);
    }
}
