using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject[] _mines;
    [SerializeField] GameObject[] _collectable;
    [SerializeField] GameObject _blockPrefeb;

    [SerializeField] Transform[] _positions;
    [SerializeField] Transform _parent;
    [SerializeField] Transform _3DTiles;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;

    [SerializeField] StageLevelSO currentLevel;

    public StageLevelSO[] stageLevels;
    public StageLevelSO currentStageLevel;

    void Start()
    {
        _3DTiles.transform.Clear();
        _parent.transform.Clear();
        SetupTile();
        CreateCurrentStage(currentStageLevel);
    }

    private void SetupTile()
    {
        Vector3 pos = startPoint.position;
        Debug.Log("A " + startPoint.position.x);
        Debug.Log("B" + endPoint.position.x);
        int count = 0;

        while (count < 20)
        {
            GameObject clone = Instantiate(_mines[Random.Range(0, _mines.Length)]);
            pos.x += clone.GetComponent<Renderer>().bounds.size.x;
            Debug.Log("siez x" + clone.GetComponent<Renderer>().bounds.size.x);

            clone.transform.position = pos;

            if (pos.x > endPoint.position.x) break;

        }
    }

    public void CreateCurrentStage(StageLevelSO currentStage)
    {
        List<GameObject> myObjects = new List<GameObject>();
     
        for(int i=0;i< currentStage.TrapAmount; i++)
        {
            GameObject clone = Instantiate(_mines[UnityEngine.Random.Range(0, _mines.Length)], _positions[i].position, Quaternion.identity);
            myObjects.Add(clone);
            
        }

        for (int i = 0; i < currentStage.CollectibleAmount; i++)
        {
            GameObject clone = Instantiate(_collectable[Random.Range(0, _collectable.Length)]);
            clone.GetComponent<Collectible>().JumpForce = currentStage.JumpForce;
            myObjects.Add(clone);
        }

        for(int i=myObjects.Count;i<_positions.Length;i++)
        {
            GameObject clone = Instantiate(_blockPrefeb);
            myObjects.Add(clone);
        }

        UTILS.Shuffle(myObjects);

        for(int i = 0; i < myObjects.Count; i++)
        {
            myObjects[i].transform.position = _positions[i].position;
            myObjects[i].transform.parent = _parent;
        }
        
    }

    public void CreateMines(int max = 10)
    {
        max = Mathf.Min(_positions.Length, max);
        for (int i = 0; i < max; i++)
        {
            GameObject clone = Instantiate(_mines[Random.Range(0, _mines.Length)], _positions[i].position, Quaternion.identity);
            clone.transform.parent = _parent;
        }
    }

    public void CreateCollectable(int max = 10)
    {
        max = Mathf.Min(_positions.Length, max);
        for (int i = 0; i < max; i++)
        {
            GameObject clone = Instantiate(_collectable[Random.Range(0, _collectable.Length)], _positions[i].position, Quaternion.identity);
            clone.transform.parent = _parent;
        }
    }

    public void RemoveMines()
    {
        foreach (Transform child in _parent)
        {
            Destroy(child.gameObject);
        }
    }
}
