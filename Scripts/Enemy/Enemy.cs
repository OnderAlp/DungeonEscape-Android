using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject diamondPreFab;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected AudioSource audioSource;
    protected bool isDead = false;

    protected bool isHit = false;

    protected Player player;

    public GameObject EnemyParent;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); ;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Init();
    }
    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            EnemyParent.transform.localScale = new Vector3(-1, 1, 1);
            //sprite.flipX = true;
        }
        else
        {
            EnemyParent.transform.localScale = new Vector3(1, 1, 1);
            //sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if(distance > 4.0f)
        {
            anim.SetBool("InCombat", false);
        }
        if (!anim.GetBool("InCombat") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            isHit = false;
        }

        Vector3 direction = player.transform.localPosition - transform.position;
        if (isHit)
        {
            if (direction.x > 0)
            {
                EnemyParent.transform.localScale = new Vector3(1, 1, 1);
                //sprite.flipX = false;
            }
            else if (direction.x < 0)
            {
                EnemyParent.transform.localScale = new Vector3(-1, 1, 1);
                //sprite.flipX = true;

            }
        }

    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        }
        if(isDead == false)
        {
            Movement();
        }

        
    }

}
