using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*public Transform target;
   // public float movePower = 1f;
    Vector3 movement;
   // int movementFlag = 0;

   /* public int maxHealth;
    public int curHealth;
    public bool isAttack;
    public bool isChase;*/

    // public float speed;
    // int Health;
    Rigidbody rigid;
    //Animator anim;
}


    /*private void RunAway()
    {
        if ((transform.position - target.transform.position).magnitude < 50) //���� ���Ϳ� �÷��̾�� �Ÿ��� 10���� �۰�
                  {
            Vector3 direction = (transform.position - target.transform.position).normalized; //������ �÷��̾� �ݴ� ��������
                    transform.position += direction * speed * Time.deltaTime; //Speed�� �ӵ��� ��������.
              }
    }

    void Go()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }*/



 






/*void Move()
{
    Vector3 moveVeocity = Vector3.zero;
    if(movementFlag == 1)
    {
        transform.localScale = new Vector3(1, 0, speed);

    }
    else if(movementFlag == 2)
    {
        moveVeocity = Vector3.right;
        transform.localScale = new Vector3(1, 0, speed);
    }

    transform.position += moveVeocity * movePower * Time.deltaTime;
}

/* void Awake()
{
    rigid = GetComponent<Rigidbody>();
    anim = GetComponentInChilderen<Animator>();

    Invoke("ChaseStart", 2);

}

void ChaseStart()
{
    isChase = true;
    anim.SetBool("isWalk", true);

}*/

/*void Update()


    {

      
        
            transform.LookAt(target);
            
            //transform.position += transform.forward * speed * Time.deltaTime;
        

 
 
    }

    /*void FreezeVelocity()
    {
        if(isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }
  
    void FixedUpdate()
    {
        FreezeVelocity();
    }*/

    



