using UnityEngine;

[CreateAssetMenu(fileName = "StageLevelSO", menuName = "Scriptable Objects/StageLevelSO")]
public class StageLevelSO : ScriptableObject
{
    public int TrapAmount;           // Ʈ�� ���� �� ��
    public int CollectibleAmount;    // ������ ������ ����
    public int Time;                 // �ð�����
    public int Life;                 // ������ ��

    public float JumpForce;
    public float Speed;
}
