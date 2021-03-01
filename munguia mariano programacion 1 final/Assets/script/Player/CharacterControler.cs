using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterControler : MonoBehaviour
{
    public Animator MainAnimation;
    public SpriteRenderer MainSprite;
    public float Speed;
    public int Life;
    public Rigidbody2D Body;
    public float horizontal;
    public sound playersound;
    public Image swordcheat;
    public Image heartcheat;

    [Header("Jump")]
    public float JumpForce;
    public int NumberJump;
    public int MaxJump;

    [Header("Life Components")]
    public int NumberOfHeart;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    [Header("Attack")]
    public float AttackRange;
    public int Damage;
    private float TimeToAttack;
    public float FirstTimeToAttack;
    public Transform attackPoint;
    public LayerMask DefineEnemy;
    



    // Start is called before the first frame update
    void Start()
    {
        MainAnimation = this.GetComponent<Animator>();
        MainAnimation.SetInteger("life", Life);
        MainSprite = this.GetComponent<SpriteRenderer>();
        Body = this.GetComponent<Rigidbody2D>();
        NumberJump = MaxJump;
        playersound = GetComponent<sound>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 realVelocity;
        realVelocity.x = Speed * horizontal ;
        realVelocity.y = Body.velocity.y;
        realVelocity.z = 0;

        Body.velocity = realVelocity;


        //Move
        if (horizontal < 0)
        {
            MainSprite.flipX = false;
            attackPoint.position = new Vector3(transform.position.x - 0.50f, transform.position.y, transform.position.z);
        }
        else if (horizontal > 0)
        {
            MainSprite.flipX = true;
            attackPoint.position = new Vector3(transform.position.x + 0.50f, transform.position.y, transform.position.z);
        }
        
        MainAnimation.SetFloat("walk speed", Mathf.Abs(horizontal));

        MainAnimation.SetFloat("jump", Body.velocity.y);

        //atack
       if (TimeToAttack <= 0)
        {
            TimeToAttack = FirstTimeToAttack;
            if (Input.GetMouseButton(0))
            {
                playersound.SoundPlay(playersound.clips[0]); //audio
                MainAnimation.SetTrigger("attackmovement");
                MainAnimation.Play("atack 1");
                Debug.Log("attack on");

               

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, DefineEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                     enemyControler enemy= enemiesToDamage[i].GetComponent<enemyControler>();
                    if(enemy!= null)
                    {
                        enemy.TakeDamage(Damage);
                    } else
                    {
                        bossLife boss = enemiesToDamage[i].GetComponent<bossLife>();
                        if (boss != null)
                        {
                            boss.TakeDamage(Damage);
                        }
                    }
                    
                }
            }
           
        }
        else
        {
           TimeToAttack -= Time.deltaTime;
        }

        //vida
        if (Life > NumberOfHeart)
        {
            Life = NumberOfHeart;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Life)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < NumberOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (Life <= 0)
        {
            Die();
        }
        //cheats
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Damage += 2;
            swordcheat.gameObject.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Life += 2;
            heartcheat.gameObject.SetActive(true);
        }
    }
    public void TakeDamage(int damage)
    {
        Life -= damage;

        StartCoroutine(DamageAnimation());

        playersound.SoundPlay(playersound.clips[2]); //audio

        if (Life <= 0)
        {
            Die();
        }
    }
     void Die()
    {
        MainAnimation.Play("die");
        GameObject.Destroy(this.gameObject);
        SceneManager.LoadScene("lost");
    }

    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        { return; }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, AttackRange);
    }

   
    
    public void Move(float dirX)
    {
        horizontal = dirX;
       // playersound.SoundPlay(playersound.clips[4]);
    }
    public void Jump()
    {
        playersound.SoundPlay(playersound.clips[1]);
        if (NumberJump > 0)
        {
            MainAnimation.Play("jump");
           

            Body.velocity = Vector3.zero;
            Body.AddForce(Vector3.up * JumpForce * Body.gravityScale * Body.mass, ForceMode2D.Impulse);
            NumberJump--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            NumberJump = MaxJump;
            MainAnimation.Play("movement");
            
        }
       

    }
  
}
