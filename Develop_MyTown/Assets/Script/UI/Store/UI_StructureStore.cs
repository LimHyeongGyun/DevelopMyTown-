using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StructureStore : MonoBehaviour
{
    [SerializeField]
    private Button[] structureTypeBtns;

    private void Start()
    {
        SetupList();
    }
    public void SetupList()
    {
        structureTypeBtns = gameObject.GetComponentsInChildren<Button>();
        for (int i = 1; i < structureTypeBtns.Length - 1; i++)
        {
            structureTypeBtns[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    //�ٸ� ��ư���� isOn�� ������ ���
    public void ToggleValue(bool isOn)
    {
        //UI ����� ���� �� �޴������� ���� �Ǵ� ���� ������ �ʰ� �ϱ� ����
        //���� �� ���µż� ���̵��� if�� �߰�
        if (isOn)
        {
            ActiveTypeMenu(structureTypeBtns[0].gameObject);
        }
        gameObject.GetComponent<Toggle>().isOn = isOn;
    }

    //���� �޴� Ŭ����
    public void ActiveTypeMenu(GameObject structureType)
    {
        foreach (Button btn in structureTypeBtns)
        {
            //��ü �޴�  ����
            btn.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        //Ŭ���� UI�޴��� ��������
        structureType.transform.GetChild(0).gameObject.SetActive(true);
    }
}
