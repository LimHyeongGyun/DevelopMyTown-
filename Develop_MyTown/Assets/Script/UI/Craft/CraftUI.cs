using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftUI : MonoBehaviour
{
    [HideInInspector]
    public GameObject structureObj;
    private UIManager uiManager;
    private UI_Store ui_Store;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        ui_Store = FindObjectOfType<UI_Store>();
    }

    //��ġ Ȯ�� ���� �ǹ� ���� ���ϱ�
    public void RotateStructure()
    {
        //�ð���� �϶� �ݽð� ȸ����Ű��
        if (structureObj.transform.rotation == Quaternion.Euler(0f, 90f, 0f))
        {
            structureObj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //������ �϶� �ð���� ȸ����Ű��
        else if (structureObj.transform.rotation == Quaternion.Euler(0f, 0f, 0f))
        {
            structureObj.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    //��ư���� ���� Ȯ���ϱ�
    public void DecideConstruction()
    {
        ui_Store.ToggleValue(true);
        uiManager.ToggleVerticalMenu(ui_Store.gameObject);
        PlayerData playerData = FindObjectOfType<PlayerData>();
        playerData.gold -= structureObj.GetComponent<Structure>().structureInfo.needGold; //������ ����

        Destroy(this.gameObject);
    }
    //��ư���� ���� ����ϱ�
    public void CancelConstruction()
    {
        ui_Store.ToggleValue(true);
        uiManager.ToggleVerticalMenu(ui_Store.gameObject);
        Destroy(structureObj); //�����Ϸ��� �ǹ� ����
        Destroy(this.gameObject); //UI ����
    }
}
