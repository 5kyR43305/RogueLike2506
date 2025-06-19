using UnityEngine;

[CreateAssetMenu(fileName = "StageLevelSO", menuName = "Scriptable Objects/StageLevelSO")]
public class StageLevelSO : ScriptableObject
{
    public int TrapAmount;           // 트랩 종류 및 수
    public int CollectibleAmount;    // 아이템 개수및 종류
    public int Time;                 // 시간제한
    public int Life;                 // 라이프 수

    public float JumpForce;
    public float Speed;
}
