using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private const int setHp = 3; //����HP
    private const int maxHp = 5; //�ִ�HP
    private const int highRating = 1; //�ְ� �ſ���
    private const int lowRating = 10; //���� �ſ���

    public int curHp; //����HP
    public float speed = 10; //�̵��ӵ�
    public int curCraditRating; //���� �ſ���

    public void InitStats()
    {
        curHp = setHp;
        curCraditRating = lowRating;
    }
}