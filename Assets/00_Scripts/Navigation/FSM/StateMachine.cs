using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//상태를 판별해서 다음 상태로 바꿔줌
public class StateMachine : MonoBehaviour
{
    Enemy owner;
    public Dictionary<AllEnum.StateEnum, State> StateDic = new Dictionary<AllEnum.StateEnum, State>();
    AllEnum.StateEnum ExState; // 이전상태 체크
    bool isPlay = false;

    //패턴을 위한 상태Enum만 담은 리스트
    //List<AllEnum.StateEnum> patternList = new List<AllEnum.StateEnum>();
    //bool doPattern = false; // 코루틴 에어용
    //int patternNum; // 패턴리스트를 하나씩 돌기위한 변수

    //void Start()
    public void SetInIt()
    {
        owner = GetComponent<Enemy>();
        StateDic.Add(AllEnum.StateEnum.Idle, new State_Idle(owner, SetState));
        StateDic.Add(AllEnum.StateEnum.Walk, new State_Walk(owner, SetState));
        StateDic.Add(AllEnum.StateEnum.Chase, new State_Chase(owner, SetState));

        ExState = AllEnum.StateEnum.Walk;
        SetState(AllEnum.StateEnum.Idle);
        isPlay = true;
    }
    void Update()
    {
        if (isPlay == false)
        {
            return;
        }
        if (ExState == owner.NowState /*&& owner.NowState != AllEnum.StateEnum.End*/)
        {
            StateDic[owner.NowState].OnStateStay();
        }
    }

    public void SetState(AllEnum.StateEnum _enum)
    {
        owner.NowState = _enum;
        if (ExState != owner.NowState)
        {
            StateDic[ExState].OnStateExit();
            StateDic[owner.NowState].OnStateEnter();
            ExState = owner.NowState;
        }
    }

    //IEnumerator SetPatternState()
    //{
    //    StateDic[patternList[patternNum]].OnStateEnter();
    //    while (doPattern)
    //    {
    //        yield return new WaitForSeconds(다음패턴시간);
    //        patternNum++;
    //        if (patternNum >= patternList.Count)
    //        {
    //            patternNum = 0;
    //        }
    //        StateDic[patternList[patternNum]].OnStateEnter();
    //    }
    //}
}
