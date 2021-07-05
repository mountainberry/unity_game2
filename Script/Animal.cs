using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] protected string animalName; // 동물의 이름
    [SerializeField] protected int hp;  // 동물의 체력

    [SerializeField] protected float walkSpeed;  // 걷기 속력
    [SerializeField] protected float runSpeed;  // 달리기 속력
    [SerializeField] protected float turningSpeed;  // 회전 속력

    protected float applySpeed;
    protected FieldOfViewAngle theFieldOfViewAngle;
    

    protected Vector3 direction;  // 방향

    // 상태 변수
    protected bool isAction;  // 행동 중인지 아닌지 판별
    protected bool isWalking; // 걷는지, 안 걷는지 판별
    protected bool isRunning; // 달리는지 판별
    protected bool isDead;   // 죽었는지 판별
    protected bool isAttacking; // 공격중인지 판별

    [SerializeField] protected float walkTime;  // 걷기 시간
    [SerializeField] protected float waitTime;  // 대기 시간
    [SerializeField] protected float runTime;  // 뛰기 시간
    protected float currentTime;

    // 필요한 컴포넌트
    [SerializeField] protected Animator anim;
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected BoxCollider boxCol;


    protected void Start()
    {
        currentTime = waitTime;   // 대기 시작
        isAction = true;   // 대기도 행동
        theFieldOfViewAngle = GetComponent<FieldOfViewAngle>();
        

    }

    protected void Update()
    {
        if (!isDead)
        {
            Move();
            Rotation();
            ElapseTime();
        }
    }

    protected void Move()
    {
        if (isWalking || isRunning)
            rigid.MovePosition(transform.position + transform.forward * applySpeed * Time.deltaTime);
    }

    protected void Rotation()
    {
        if (isWalking || isRunning)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, direction.y, 0f), turningSpeed); // turningSpeed 만큼 보간 됨
            rigid.MoveRotation(Quaternion.Euler(_rotation));
        }
    }

    protected void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)  // 랜덤하게 다음 행동을 개시
                ReSet();
        }
    }

    protected virtual void ReSet()  // 다음 행동 준비
    {
        isAction = true;
        isWalking = false;
        anim.SetBool("Walking", isWalking);
        isRunning = false;
        anim.SetBool("Running", isRunning);
        applySpeed = walkSpeed;

        direction.Set(0f, Random.Range(0f, 360f), 0f);

        // RandomAction();
    }

    protected void TryWalk()  // 걷기
    {
        currentTime = walkTime;
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        applySpeed = walkSpeed;
        Debug.Log("걷기");
    }

    public virtual void Damage(int _dmg, Vector3 _targetPos)
    {
        if (!isDead)
        {
            hp -= _dmg;

            if (hp <= 0)
            {
                Dead();
                return;
            }

           
            anim.SetTrigger("Hurt");
            // Run(_targetPos);
        }
    }

    protected void Dead()
    {
        

        isWalking = false;
        isRunning = false;
        isDead = true;

        anim.SetTrigger("Dead");
    }

 
}
