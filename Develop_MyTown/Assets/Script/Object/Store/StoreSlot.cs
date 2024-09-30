using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour
{
    public StructureSO structureInfo;

    public int id;
    [SerializeField]
    private Text needGold;
    [SerializeField]
    private Text structureName;

    public void SelectSlot()
    {
        PlayerData playerData = FindAnyObjectByType<PlayerData>();

        //������ �� �ִ� ����� ���� ��
        if (playerData.gold >= structureInfo.needGold)
        {
            Craft craft = FindObjectOfType<Craft>();
            craft.CreatePreviewObject(structureInfo);

            //�����޴� �����
            gameObject.GetComponentInParent<UI_Store>().ToggleValue(false);
            UIManager uiManager = FindObjectOfType<UIManager>();
            uiManager.ToggleVerticalMenu(gameObject.GetComponentInParent<UI_Store>().gameObject);
        }
        //����� �����ؼ� ������ �� ���� ��
        else if (playerData.gold < structureInfo.needGold)
        {
            UI_Store storeUI = FindObjectOfType<UI_Store>();
            GameObject warningObj = Instantiate(storeUI.warningImg);
            warningObj.transform.position = Vector3.zero;
        }
    }
}
