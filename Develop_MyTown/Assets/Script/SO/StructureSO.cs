using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StructureData", menuName = "ScriptableObject/Structure", order = 0)]
public class StructureSO : ScriptableObject
{
    //���๰ ���� ���
    [SerializeField]
    private StateManager.StructureType structureType;
    [SerializeField]
    private int structureId; //�ǹ� ���̵�
    [SerializeField]
    private string structureName; //�ǹ� �̸�
    [SerializeField]
    private Sprite structureImg; //�ǹ� �̹���
    [SerializeField]
    private int needGold; //�Ǽ��� �ʿ��� ���
    [SerializeField]
    private float buildTime; //�Ǽ��ð�
    [SerializeField]
    private float infrastructureFigure; //�������ġ

    //���๰ ������ ���� �ΰ� ���
    //���� �ǹ��϶�
    [SerializeField]
    private float productTime;

    //��ȭ�ü��϶�


    //�������϶�
    [SerializeField]
    private int npcId; //ã�ƿ� npc���̵�
    [SerializeField]
    private float visitProbability; //ã�ƿ� Ȯ��
}