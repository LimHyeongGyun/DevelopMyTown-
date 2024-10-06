using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StructureData", menuName = "ScriptableObject/Structure", order = 0)]
public class StructureSO : ScriptableObject
{
    //���๰ ���� ���
    public StateManager.StructureType structureType; //�ǹ� Ÿ��
    public GameObject structureObj; //�ǹ� ������Ʈ
    public float structureSizeX; //�ǹ� X�� ũ��
    public float structureSizeY; //�ǹ� Y�� ũ��
    public float structureSizeZ; //�ǹ� Z�� ũ��
    public int structureId; //�ǹ� ���̵�
    public string structureName; //�ǹ� �̸�
    public Sprite structureImg; //�ǹ� �̹���
    public int needGold; //�Ǽ��� �ʿ��� ���
    public float buildTime; //�Ǽ��ð�
    public float infrastructureFigure; //�������ġ

    //���๰ ������ ���� �ΰ� ���
    //���� �ǹ��϶�
    public float productTime;

    //��ȭ�ü��϶�

    //�������϶�
    public int npcId; //ã�ƿ� npc���̵�
    public float visitProbability; //ã�ƿ� Ȯ��
}