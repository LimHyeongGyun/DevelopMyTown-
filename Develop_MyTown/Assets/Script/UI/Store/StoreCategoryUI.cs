using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCategoryUI : MonoBehaviour
{
    public Dictionary<int, StructureSO> structureDB = new Dictionary<int, StructureSO>();

    [SerializeField]
    private StateManager.StructureType type;
    [SerializeField]
    private int numberOfCategorie;
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private StoreSlot slot;
    private StoreSlot[] slots;

    private string dataPath;
    void Start()
    {
        Init();
    }

    private void Init()
    {
        LoadStructureData();
        CreateSlot();
    }
    //������ �ҷ�����
    private void LoadStructureData()
    {
        if (type == StateManager.StructureType.Production)
        {
            dataPath = "ScriptableObject/Store/Production";
        }
        else if (type == StateManager.StructureType.Curtural)
        {
            dataPath = "ScriptableObject/Store/Curtural";
        }
        else if (type == StateManager.StructureType.Sculpture)
        {
            dataPath = "ScriptableObject/Store/Sculpture";
        }

        foreach (StructureSO structureSO in Resources.LoadAll<StructureSO>(dataPath))
        {
            structureDB.Add(structureSO.structureId, structureSO);
        }
    }
    private void CreateSlot()
    {
        //������ ������ŭ ���Ի���
        for (int i = 0; i < numberOfCategorie; i++)
        {
            StoreSlot slot = Instantiate(this.slot); //������ ������ŭ ���� ����
            slot.transform.SetParent(content.transform); //content�� �ڽ����� ����
        }
        SetSlot();
    }

    private void SetSlot()
    {
        //������ �����ϱ����� �迭�� ����
        slots = content.GetComponentsInChildren<StoreSlot>();

        //���Կ� Id ������� StructureDB�� ������ �������ֱ�
        for (int i = 0; i < slots.Length; i++)
        {
            structureDB.TryGetValue(i, out slots[i].structureInfo);
        }
    }
}
