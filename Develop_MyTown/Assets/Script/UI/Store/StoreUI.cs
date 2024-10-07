using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    [SerializeField]
    private StoreCategoryUI[] TypeBtns;

    public GameObject warningImg;

    private void Start()
    {
        SetupList();
    }
    public void SetupList()
    {
        TypeBtns = gameObject.GetComponentsInChildren<StoreCategoryUI>();
        for (int i = 1; i < TypeBtns.Length; i++)
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
        foreach (StoreCategoryUI type in TypeBtns)
        {
            //��ü �޴�  ����
            type.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        //Ŭ���� UI�޴��� ��������
        Type.transform.GetChild(0).gameObject.SetActive(true);
    }
}
