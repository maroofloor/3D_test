using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//상태를 찍어낼 부모(원본)
//abstract 로 구현하던지, interface로 구현을 하던지.
public abstract class State /*: MonoBehaviour*/
{
    // 소유주에 대한 정보도 가지고 있어야 함.
    protected Enemy enemy; // 행동 주체
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
