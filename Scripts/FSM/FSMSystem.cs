using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem {

    private Dictionary<StateID, FSMState> states = new Dictionary<StateID, FSMState>();

    private StateID currentStateID;  //当前状态ID
    private FSMState currentState;  //当前状态

    //更新方法
    public void Update(GameObject npc)
    {
        currentState.Act(npc);
        currentState.Reason(npc);
    }

    public void AddState(FSMState s)
    {
        if (s == null)
        {
            Debug.LogError("FSMState不能为空");
            return;
        }
        //如果当前状态为空，
        //将当前状态设为s
        //将当前状态ID设为s.ID
        if (currentState == null)
        {
            currentState = s;
            currentStateID = s.ID;
        }
        if (states.ContainsKey(s.ID))
        {
            Debug.LogError(s.ID + "已存在");
            return;
        }
        //添加状态
        states.Add(s.ID, s);
    }

    public void DeleteState(StateID id)
    {
        if (id == StateID.NullStateID)
        {
            Debug.LogError("不能删除NullStateID");
            return;
        }
        if (states.ContainsKey(id) == false)
        {
            Debug.LogError(id + "不存在");
            return;
        }
        //删除状态
        states.Remove(id);
    }

    //执行转换
    public void PerformTransition(Transition trans)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("无法执行NullTransition");
        }
        //得到StateID
        StateID id = currentState.GetOutputState(trans);
        if (id == StateID.NullStateID)
        {
            Debug.LogWarning("当前状态" + currentState + "无法根据" + trans + "状态发生转换");
        }
        if (states.ContainsKey(id) == false)
        {
            Debug.LogError(id + "不存在");
        }
        //根据StateID得到state
        FSMState state = states[id];
        currentState.DoAfterLeaving();
        //将当前状态设为state
        currentState = state;
        //将当前状态ID设为id
        currentStateID = id;
        currentState.DoBeforeEntering();
    }
}
