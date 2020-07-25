using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ObjectBase
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float maxDelay;
    protected float curDelay;

    protected int hp;
    protected int bomb;

    public GameObject sword;
    public GameObject bombObj;

    Animator anim;


    SpriteRenderer swordRenderer;
    SpriteRenderer renderer;

    protected override IEnumerator OnStartCoroutine()
    {
        renderer = GetComponent<SpriteRenderer>();
        swordRenderer = sword.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        bomb = 3;
        anim.SetInteger("Horizontal", 1);
        yield break;
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal") * speed;
        float v = Input.GetAxisRaw("Vertical") * speed;

        curDelay += Time.deltaTime;

        if(curDelay>=maxDelay&& h!=0)
        {
            sword.SetActive(true);
            anim.SetInteger("Vertical", 0);
            anim.SetInteger("Horizontal", (int)h);
            transform.position += new Vector3(h, 0, 0);
            if (h > 0)
            {
                swordRenderer.flipX = true;
                sword.transform.localPosition = new Vector3(0.7f, -0.1f, 0);
                renderer.flipX = false;
            }
            else if (h < 0)
            {
                swordRenderer.flipX = false;
                sword.transform.localPosition = new Vector3(-0.7f, -0.1f, 0);
                renderer.flipX = true;
            }
            if (transform.position.x < -8 || transform.position.x > 8)
            { 
                transform.position -= new Vector3(h, 0, 0);
            }
            curDelay = 0;
        }
        if (curDelay >= maxDelay && v != 0)
        {
            sword.SetActive(false);
            anim.SetInteger("Horizontal", 0);
            anim.SetInteger("Vertical", (int)v);
            transform.position += new Vector3(0, v, 0);

            if (transform.position.y < -4 || transform.position.y > 4)
            {

                transform.position -= new Vector3(0, v, 0);
            }
            curDelay = 0;
        }

        if (Input.GetKey(KeyCode.Z)&&gameObject.tag != "Player_Attack")
        {
            Attack();
        }
        
        

    }

   
    protected void Attack()
    {
        float d;
        d = anim.GetInteger("Horizontal");
        sword.transform.position += new Vector3(d/5, 0, 0);
        gameObject.tag = "Player_Attack";
        Invoke("FinishAttack", 0.5f);
    }
    protected void FinishAttack()
    {
        float d;
        d = anim.GetInteger("Horizontal");
        sword.transform.position -= new Vector3(d/5, 0, 0);
        gameObject.tag = "Player";
    }

    public int getbomb()
    {
        return bomb;
    }

    public int getHp()
    {
        return hp;
    }

    public void setbomb(int newbomb)
    {
        bomb = newbomb;
    }

    public Vector3 getPos()
    {
        return transform.position;
    }
}
