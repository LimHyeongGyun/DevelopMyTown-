using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public Action<GameObject> horizontalAction;
    public Action<GameObject> verticalAction;

    public GameObject menuBtn;

    private void Start()
    {
        horizontalAction += ToggleHorizontalMenu;
        verticalAction += ToggleVerticalMenu;
    }
    //���� Toggle UI
    public void ToggleHorizontalMenu(GameObject toggleBtn)
    {
        StateManager.UIDirectionType type = toggleBtn.GetComponent<UI_DefaultSet>().direction;
        //��ġ��
        if (toggleBtn.GetComponent<Toggle>().isOn)
        {
            //���������� ��ġ��
            if (type == StateManager.UIDirectionType.Right)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveX(toggleBtn.transform.position.x + Mathf.Abs(toggleBtn.transform.GetChild(0).position.x) * 2, 0.3f);
            }
            //�������� ��ġ��
            else if (type == StateManager.UIDirectionType.Left)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveX(toggleBtn.transform.position.x - Mathf.Abs(toggleBtn.transform.GetChild(0).position.x) * 2, 0.3f);
            }            
        }
        //����
        else if (!toggleBtn.GetComponent<Toggle>().isOn)
        {
            //������������ ����
            if (type == StateManager.UIDirectionType.Left)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveX(toggleBtn.transform.position.x + Mathf.Abs(toggleBtn.transform.GetChild(0).position.x) * 2, 0.3f);
            }
            //�޹������� ����
            else if (type == StateManager.UIDirectionType.Right)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveX(toggleBtn.transform.position.x - Mathf.Abs(toggleBtn.transform.GetChild(0).position.x) * 2, 0.3f);
            }
        }
    }

    //���� Toggle UI
    public void ToggleVerticalMenu(GameObject toggleBtn)
    {
        StateManager.UIDirectionType type = toggleBtn.GetComponent<UI_DefaultSet>().direction;
        //��ġ��
        if (toggleBtn.GetComponent<Toggle>().isOn)
        {
            //���������� ��ġ��
            if (type == StateManager.UIDirectionType.Up)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveY(toggleBtn.transform.position.y + Mathf.Abs(toggleBtn.transform.position.y) * 2, 0.3f);
            }
            //�Ʒ��������� ��ġ��
            else if (type == StateManager.UIDirectionType.Down)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveY(toggleBtn.transform.position.y - Mathf.Abs(toggleBtn.transform.position.y) * 2, 0.3f);
            }
        }
        //����
        else if (!toggleBtn.GetComponent<Toggle>().isOn)
        {
            //���������� ����
            if (type == StateManager.UIDirectionType.Down)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveY(toggleBtn.transform.position.y + Mathf.Abs(toggleBtn.transform.position.y) * 2, 0.3f);
            }
            //�Ʒ��������� ����
            else if (type == StateManager.UIDirectionType.Up)
            {
                toggleBtn.GetComponent<RectTransform>().DOMoveY(toggleBtn.transform.position.y - Mathf.Abs(toggleBtn.transform.position.y) * 2, 0.3f);
            }
        }
    }
}