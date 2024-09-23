using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public StateManager.BuildMode buildMode;

    public Action<StateManager.BuildMode> modeAction;

    private void Update()
    {
        
    }

    //�Ǽ���� ��ư���� ���
    public void ChangeBuildMode()
    {
        if (buildMode == StateManager.BuildMode.Observe)
        {
            buildMode = StateManager.BuildMode.Build;
        }
        else if (buildMode == StateManager.BuildMode.Build)
        {
            buildMode = StateManager.BuildMode.Observe;
        }

        if (modeAction != null)
        {
            modeAction.Invoke(buildMode);
        }
    }

    private void BuildMode()
    {
        //Build ���·� ����
        if (buildMode == StateManager.BuildMode.Build)
        {

        }
        //Obseve���·� ����
        else if (buildMode == StateManager.BuildMode.Observe)
        {

        }
    }
}