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
        //��ġ��
        if (toggleBtn.GetComponent<Toggle>().isOn)
        {
            toggleBtn.GetComponent<RectTransform>().DOMoveX(toggleBtn.transform.position.x + Mathf.Abs(toggleBtn.transform.GetChild(0).position.x) * 2, 0.3f);
        }
        //����
        else if (!toggleBtn.GetComponent<Toggle>().isOn)
        {
            toggleBtn.GetComponent<RectTransform>().DOMoveX(toggleBtn.transform.position.x - Mathf.Abs(toggleBtn.transform.GetChild(0).position.x) * 2, 0.3f);
        }
    }

    //���� Toggle UI
    public void ToggleVerticalMenu(GameObject toggleBtn)
    {
        //��ġ��
        if (toggleBtn.GetComponent<Toggle>().isOn)
        {
            toggleBtn.GetComponent<RectTransform>().DOMoveY(toggleBtn.transform.position.y + Mathf.Abs(toggleBtn.transform.position.y) * 2, 0.3f);
        }
        //����
        else if (!toggleBtn.GetComponent<Toggle>().isOn)
        {
            toggleBtn.GetComponent<RectTransform>().DOMoveY(toggleBtn.transform.position.y - Mathf.Abs(toggleBtn.transform.position.y) * 2, 0.3f);
        }
    }
}