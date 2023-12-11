using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���¸� �Ǻ��ؼ� ���� ���·� �ٲ���
public class StateMachine : MonoBehaviour
{
    Enemy owner;
    public Dictionary<AllEnum.StateEnum, State> StateDic = new Dictionary<AllEnum.StateEnum, State>();
    AllEnum.StateEnum ExState; // �������� üũ
    bool isPlay = false;

    //������ ���� ����Enum�� ���� ����Ʈ
    //List<AllEnum.StateEnum> patternList = new List<AllEnum.StateEnum>();
    //bool doPattern = false; // �ڷ�ƾ �����
    //int patternNum; // ���ϸ���Ʈ�� �ϳ��� �������� ����

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
    //        yield return new WaitForSeconds(�������Ͻð�);
    //        patternNum++;
    //        if (patternNum >= patternList.Count)
    //        {
    //            patternNum = 0;
    //        }
    //        StateDic[patternList[patternNum]].OnStateEnter();
    //    }
    //}
}
