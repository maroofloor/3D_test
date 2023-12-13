using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : State
{
    Dictionary<AllEnum.StateEnum, State> StateDic = new Dictionary<AllEnum.StateEnum, State>();

    AllEnum.StateEnum ex_State;
    AllEnum.StateEnum State;

    Vector3 vec;
    float dist;

    public State_Attack(Enemy enemy, SetStateDel stateDel) : base(enemy, stateDel)
    {
        StateDic.Add(AllEnum.StateEnum.Attack_Near, new State_Attack_Near(enemy, SetStateInAttack));
        StateDic.Add(AllEnum.StateEnum.Attack_Far, new State_Attack_Far(enemy, SetStateInAttack));
    }

    public override void OnStateEnter()
    {
        ex_State = AllEnum.StateEnum.End;

        if (enemy.target == null)
        {
            StateDel(AllEnum.StateEnum.Idle);
        }
        else
        {
            dist = (enemy.target.transform.position - enemy.transform.position).sqrMagnitude;
            if (dist <= 2)
            {
                State = AllEnum.StateEnum.Attack_Near;
                SetStateInAttack(AllEnum.StateEnum.Attack_Near);
            }
            else if (dist <= 25)
            {
                State = AllEnum.StateEnum.Attack_Far;
                SetStateInAttack(AllEnum.StateEnum.Attack_Far);
            }
            else
            {
                State = AllEnum.StateEnum.Idle;
                SetStateInAttack(AllEnum.StateEnum.Idle);
            }
        }

        State = AllEnum.StateEnum.Attack_Near;
        SetStateInAttack(AllEnum.StateEnum.Attack_Near);
    }

    public override void OnStateExit()
    {
        StateDic[ex_State].OnStateExit();
    }

    public override void OnStateStay()
    {
        if (enemy.target != null)
        {
            vec = enemy.transform.position;
            vec.y = enemy.target.transform.position.y;

            enemy.transform.position = vec;
            enemy.transform.LookAt(enemy.target.transform);

            dist = (enemy.target.transform.position - enemy.transform.position).sqrMagnitude;
            if (dist <= 2)
            {
                State = AllEnum.StateEnum.Attack_Near;
            }
            else if (dist <= 25)
            {
                State = AllEnum.StateEnum.Attack_Far;
            }
            else
            {
                State = AllEnum.StateEnum.End;
                StateDel(AllEnum.StateEnum.Idle);
                return;
            }
            SetStateInAttack(State);
        }

        if (ex_State == State)
        {
            StateDic[State].OnStateStay();
        }
    }

    public void SetStateInAttack(AllEnum.StateEnum _enum)
    {
        State = _enum;

        if (State != AllEnum.StateEnum.Attack_Far && State != AllEnum.StateEnum.Attack_Near)
        {
            StateDel(State);
            return;
        }

        if (ex_State != State)
        {
            if (ex_State != AllEnum.StateEnum.End)
            {
                StateDic[ex_State].OnStateExit();
            }

            StateDic[State].OnStateEnter();
            ex_State = State;
        }
    }
}
