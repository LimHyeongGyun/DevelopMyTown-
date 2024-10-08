using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StructureData", menuName = "ScriptableObject/Structure", order = 0)]
public class StructureSO : ScriptableObject
{
    //���๰ ���� ���
    public StateManager.StructureType structureType; //�ǹ� Ÿ��
    public GameObject structureObj; //�ǹ� ������Ʈ
    public Sprite structureImg; //�ǹ� �̹���
    public string structureName; //�ǹ� �̸�
    public float structureSizeX; //�ǹ� X�� ũ��
    public float structureSizeY; //�ǹ� Y�� ũ��
    public float structureSizeZ; //�ǹ� Z�� ũ��
    public float buildTime; //�Ǽ��ð�
    public int structureId; //�ǹ� ���̵�
    public int needGold; //�Ǽ��� �ʿ��� ���
    public int infrastructureFigure; //�������ġ

    //���๰ ������ ���� �ΰ� ���
    //���� �ǹ��϶�
    public float productionTime; //����ð�
    public int output; //���귮
    public int harvestableOutput;//��Ȯ���� ���귮
    public int outputPerMinute; //�д� ���귮
    public int maxOutput; //�ִ� ���귮

    //��ȭ�ü��϶�

    //�������϶�
    public int npcId; //ã�ƿ� npc���̵�
    public float visitProbability; //ã�ƿ� Ȯ��
}