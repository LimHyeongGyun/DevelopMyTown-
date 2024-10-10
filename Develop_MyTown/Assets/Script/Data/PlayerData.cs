using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private const int highRating = 1; //�ְ� �ſ���
    private const int lowRating = 10; //���� �ſ���

    public int gold; //������
    public int debt = 100000; //��
    public int curCraditRating = 8;//�÷��̾� ���� �ſ���

    public void IncreaseGold(int gold)
    {
        this.gold += gold;
    }
    public void DecreaseGold(int gold)
    {
        this.gold -= gold;
    }
}
