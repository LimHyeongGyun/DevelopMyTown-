using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Store : MonoBehaviour
{
    [SerializeField]
    private Button[] TypeBtns;

    public GameObject warningImg;

    private void Start()
    {
        SetupList();
    }
    public void SetupList()
    {
        TypeBtns = gameObject.GetComponentsInChildren<Button>();
        for (int i = 1; i < TypeBtns.Length - 1; i++)
        {
            TypeBtns[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    //�ٸ� ��ư���� isOn�� ������ ���
    public void ToggleValue(bool isOn)
    {
        //UI ����� ���� �� �޴������� ���� �Ǵ� ���� ������ �ʰ� �ϱ� ����
        //���� �� ���µż� ���̵��� if�� �߰�
        if (isOn)
        {
            ActiveTypeMenu(TypeBtns[0].gameObject);
        }
        gameObject.GetComponent<Toggle>().isOn = isOn;
    }

    //���� �޴� Ŭ����
    public void ActiveTypeMenu(GameObject Type)
    {
        foreach (Button btn in TypeBtns)
        {
            //��ü �޴�  ����
            btn.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        //Ŭ���� UI�޴��� ��������
        Type.transform.GetChild(0).gameObject.SetActive(true);
    }
}
