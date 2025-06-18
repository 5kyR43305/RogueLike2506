using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject[] _mines;
    [SerializeField] GameObject[] _collectable;

    [SerializeField] Transform[] _positions; 
    [SerializeField] Transform _parent;
    [SerializeField] Transform _3DTiles;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 9; // 4 + (9-1)*2 = 20 최대 생성수
    private int minDifficultyLevel = 1;

    void Start()
    {
        ClearTiles();
        SetupTile();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            difficultyLevel = Mathf.Min(difficultyLevel + 1, maxDifficultyLevel);
            Debug.Log($"난이도 증가: {difficultyLevel}");
            SetupTile();
        }

        if (Input.GetKeyDown(KeyCode.F10))
        {
            difficultyLevel = Mathf.Max(difficultyLevel - 1, minDifficultyLevel);
            Debug.Log($"난이도 감소: {difficultyLevel}");
            SetupTile();
        }
    }

    private void ClearTiles()
    {
        foreach (Transform child in _3DTiles)
        {
            Destroy(child.gameObject);
        }
    }

    private void SetupTile()
    {
        ClearTiles();

        int mineCount = Mathf.Min(4 + (difficultyLevel - 1) * 2, 20);
        float totalDistance = endPoint.position.x - startPoint.position.x;
        float spacing = totalDistance / (mineCount + 1);
        Vector3 pos = startPoint.position;

        for (int i = 0; i < mineCount; i++)
        {
            pos.x = startPoint.position.x + spacing * (i + 1);

            GameObject prefab = _mines[Random.Range(0, _mines.Length)];
            GameObject clone = Instantiate(prefab, pos, Quaternion.identity, _3DTiles);


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
