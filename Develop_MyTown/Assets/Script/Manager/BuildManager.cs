using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    public StateManager.BuildMode buildMode;

    public Action<StateManager.BuildMode> modeAction;

    //�Ǽ���� ��ư���� ���
    public void ChangeBuildMode()
    {
        if (modeAction != null)
        {
            //������� ����
            if (buildMode == StateManager.BuildMode.Observe)
            {
                buildMode = StateManager.BuildMode.Build;
            }
            //���������� ����
            else if (buildMode == StateManager.BuildMode.Build)
            {
                buildMode = StateManager.BuildMode.Observe;
            }
            //ī�޶� ��Ʈ�ѷ��� ��� ����
            modeAction.Invoke(buildMode);
        }

        BuildMode();
    }

    private void BuildMode()
    {
        //Build ���·� ����
        if (buildMode == StateManager.BuildMode.Build)
        {
            uiManager.menuBtn.GetComponent<Toggle>().isOn = false;
            uiManager.horizontalAction.Invoke(uiManager.menuBtn);
            uiManager.menuBtn.SetActive(false);
        }
        //Obseve���·� ����
        else if (buildMode == StateManager.BuildMode.Observe)
        {
            uiManager.menuBtn.SetActive(true);
        }
    }
}