using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftUI : MonoBehaviour
{
    [HideInInspector]
    public GameObject structureObj;
    [HideInInspector]
    public Vector3 structurePos;
    [HideInInspector]
    public StructureSO structureSO;
    public GameObject previewObj;

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
        if (previewObj.transform.rotation == Quaternion.Euler(0f, 90f, 0f))
        {
            previewObj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //������ �϶� �ð���� ȸ����Ű��
        else if (previewObj.transform.rotation == Quaternion.Euler(0f, 0f, 0f))
        {
            previewObj.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    //��ư���� ���� Ȯ���ϱ�
    public void DecideConstruction()
    {
        //���๰ �����ϱ�
        GameObject structure = Instantiate(structureObj, structurePos, Quaternion.identity);
        structure.transform.rotation = previewObj.transform.rotation;
        structure.GetComponent<Structure>().Init(structureSO);

        //������ ������Ʈ �����ϱ�
        previewObj.GetComponent<PreviewStructure>().DestroyPreview();

        //StoreUI Active��Ű��
        ui_Store.ToggleValue(true);
        uiManager.ToggleVerticalMenu(ui_Store.gameObject);        

        //Craft UI ����
        Destroy(this.gameObject);
    }
    //��ư���� ���� ����ϱ�
    public void CancelConstruction()
    {
        //������ ������Ʈ �����ϱ�
        previewObj.GetComponent<PreviewStructure>().DestroyPreview();

        //StoreUI Active��Ű��
        ui_Store.ToggleValue(true);
        uiManager.ToggleVerticalMenu(ui_Store.gameObject);

        //Craft UI ����
        Destroy(this.gameObject);
    }
}
