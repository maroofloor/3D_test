using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���¸� �� �θ�(����)
//abstract �� �����ϴ���, interface�� ������ �ϴ���.
public abstract class State /*: MonoBehaviour*/
{
    // �����ֿ� ���� ������ ������ �־�� ��.
    protected Enemy enemy; // �ൿ ��ü
    public delegate void SetStateDel(AllEnum.StateEnum state);
    protected SetStateDel StateDel;

    public State(Enemy enemy, SetStateDel stateDel)
    {
        this.enemy = enemy;
        this.StateDel = stateDel;
    }
    //public void SetOwner(Enemy enemy)
    //{
    //    this.enemy = enemy;
    //}

    public abstract void OnStateEnter();
    public abstract void OnStateStay();
    public abstract void OnStateExit();
}
