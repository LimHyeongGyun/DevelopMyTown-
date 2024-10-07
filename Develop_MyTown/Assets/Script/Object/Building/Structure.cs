using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Structure : MonoBehaviour
{
    private Harvest harvest;

    public StructureSO structureInfo;
    public StateManager.ConstructState constructState;
    public StateManager.OperateType operateType;

    [SerializeField]
    private GameObject harvestUi;

    public float buildTime;
    public float productionTime;
    public int output;

    private void Awake()
    {
        harvest = FindObjectOfType<Harvest>();
    }

    private void Update()
    {
        if (constructState == StateManager.ConstructState.Construct)
        {
            ConstructTimer();
        }
        else if(constructState == StateManager.ConstructState.Completion && structureInfo.structureType == StateManager.StructureType.Production)
        {
            ProductTimer();
        }
    }

    public void Init(StructureSO structureSO)
    {
        structureInfo = structureSO; //���๰ ���� �ޱ�
        gameObject.transform.localScale = 
            new Vector3(structureInfo.structureSizeX, structureInfo.structureSizeY, structureInfo.structureSizeZ); //���๰ ũ�� �ʱ�ȭ

        //�÷��̾� �����Ϳ��� ������ �����ϱ�
        PlayerData playerData = FindObjectOfType<PlayerData>();
        playerData.gold -= structureInfo.needGold; //������ ����

        constructState = StateManager.ConstructState.Construct;
        operateType = StateManager.OperateType.None;

        buildTime = structureInfo.buildTime; //����ð� �ʱ�ȭ
        productionTime = structureInfo.productionTime; //����ð� �ʱ�ȭ
        output = structureInfo.output; //���귮 �ʱ�ȭ
    }

    private void ConstructTimer()
    {
        if (constructState == StateManager.ConstructState.Construct)
        {
            buildTime -= Time.deltaTime;
            if (buildTime <= 0)
            {
                constructState = StateManager.ConstructState.Completion;
                if (constructState == StateManager.ConstructState.Completion)
                {
                    if (structureInfo.structureType == StateManager.StructureType.Production)
                    {
                        operateType = StateManager.OperateType.Operate;
                    }
                    else if (structureInfo.structureType == StateManager.StructureType.Curtural || structureInfo.structureType == StateManager.StructureType.Sculpture)
                    {
                        operateType = StateManager.OperateType.None;
                    }
                }
            }
        }
    }

    private void ProductTimer()
    {
        productionTime -= Time.deltaTime;
        if (productionTime <= 0)
        {
            output += structureInfo.outputPerMinute; //���깰 ����
            productionTime = structureInfo.productionTime; //����ð� �ʱ�ȭ

            if (output >= structureInfo.harvestableOutput) //��Ȯ������ ���귮 �̻��϶�
            {
                if (!harvest.productionStructure.Contains(this))
                {
                    harvest.productionStructure.Add(this);
                    harvest.harvestable = true;
                    harvest.ActiveButton();
                }
                if (output >= structureInfo.maxOutput) //�ִ� ��Ȯ���� �Ѿ��� ��
                {
                    operateType = StateManager.OperateType.Stop; //���� ����
                    output = structureInfo.maxOutput; //���귮�� �ִ� ���귮���� �ٲ�
                    productionTime = structureInfo.productionTime; //����ð� �ʱ�ȭ
                }
            }
        }
    }
}
