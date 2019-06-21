using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//转换条件
public enum Transition
{
    NullTransition=0,
    SeePlayer,
    LostPlayer,
    ClosePalyer
}

//状态ID
public enum StateID
{
    NullStateID=0,
    Patrol,
    Chase,
    Attack
}

public abstract class FSMState {

    protected StateID stateID;
    public StateID ID { get { return stateID; } }  //得到stateID的方法

    //字典
    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();

    protected FSMSystem fsm;

    public FSMState(FSMSystem fsm)
    {
        this.fsm = fsm;
    }

    //添加转换条件
    public void AddTransition(Transition trans, StateID id)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("不允许NullTransition");
            return;
        }
        if (id == StateID.NullStateID)
        {
            Debug.LogError("不允许NullStateID");
            return;
        }
        if (map.ContainsKey(trans))
        {
            Debug.Log(trans + "已存在");
            return;
        }
        map.Add(trans, id);
    }

    //删除转换条件
    public void DeleteTransition(Transition trans)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("不允许NullTransition");
            return;
        }
        if (map.ContainsKey(trans) == false) 
        {
            Debug.LogError(trans + "不存在");
            return;
        }
        map.Remove(trans);
    }

    //返回状态
    public StateID GetOutputState(Transition trans)
    {
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }
        return StateID.NullStateID;
    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoAfterLeaving() { }
    public abstract void Act(GameObject npc);  //执行动作
    public abstract void Reason(GameObject npc);  //判断转换条件
}
