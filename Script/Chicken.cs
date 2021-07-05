using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : WeakAnimal
{
    protected override void ReSet()
    {
        base.ReSet();
        RandomAction();
    }

    private void RandomAction()
    {

        
        float _random = Random.Range(0, 4); // ���, �Ա�, ���Ǳ�, �ȱ�


        if (_random <= 13 && _random >3)//10
        {
            Peek();
        }

        if (_random <= 15 )//15
        {
            Eat();
        }

        if (_random > 64)//35
        {
            Wait();
        }

        if (_random <= 65 && _random >25)//40
        {
            TryWalk();
        }

        /*if (_random == 0)
            Wait();
        else if (_random == 1)
            Eat();
        else if (_random == 2)
            Peek();
        else if (_random == 3)
            TryWalk();*/
    }

    private void Wait()  // ���
    {
        currentTime = waitTime;
        Debug.Log("���");
    }

    private void Eat()  // �Ա�
    {
        currentTime = waitTime;
        anim.SetTrigger("Eat");
        Debug.Log("�Ա�");
    }

    private void Peek()  // ���Ǳ�
    {
        currentTime = waitTime;
        anim.SetTrigger("Peek");
        Debug.Log("���Ǳ�");
    }


   
}
