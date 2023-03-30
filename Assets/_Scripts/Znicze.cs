using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;
using System;
public class Znicze : MonoBehaviour
{
    #region Singleton
    private static Znicze _instance;
    public static Znicze Instance => _instance;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    #region Variables
    [SerializeField] private GameObject[] blocksArray;
    [SerializeField] [Foldout("Znicze")] [ShowAssetPreview] private Sprite ZniczSprite;
    [SerializeField] [Foldout("Znicze")] [ShowAssetPreview] private Sprite ZniczZapalonySprite;
    [SerializeField] [Foldout("Znicze")] Vector3 size;
    [SerializeField] [Foldout("Spawner")] int gridX, gridY;
    [SerializeField] [Foldout("Spawner")] float gridOffset;
    [SerializeField] [Foldout("Spawner")] private Vector2 gridOrgin = Vector2.zero;
    [SerializeField] [Foldout("Znicze")] List<GameObject> ZniczeToClikck;
    [SerializeField] [Foldout("Znicze")][InfoBox(" index 0 jest w lewym dolnym rogu kolejne id¹ w prawo")] int[] ZniczIndexToClick;
    Vector2 lastKnownLocation = new Vector2(0, 0);
    Vector2 movement;
    #endregion
    #region SpawnGrid
    void Start()
    {
        blocksArray = new GameObject[gridX*gridY];
        SpawnGrid();
        CreateList();
    }
    void CreateList()
    {
        ZniczeToClikck = new List<GameObject>();
        foreach(int index in ZniczIndexToClick)
        {
            ZniczeToClikck.Add(blocksArray[index]);
            Debug.Log(index);
        }
        foreach(GameObject obj in ZniczeToClikck)
        {
            obj.GetComponent<Image>().sprite = ZniczSprite;
        }
    }
    void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                Vector2 spawnPosition = new Vector2(x * gridOffset, y * gridOffset) + gridOrgin;
                SpawnCubeFuckPrefabs(x,y, spawnPosition);
            }

        }
    }
    //Kocham unity jak wiszenie na ¯yrandolu
    void SpawnCubeFuckPrefabs(int x, int y, Vector2 spawnPosition)
    {
        GameObject cube = new GameObject($@"Znicz:{x}x {y}y", typeof(Image),typeof(BoxCollider),typeof(ZniczeChild),typeof(Button));
        cube.transform.parent = gameObject.transform;
        //cube.GetComponent<BoxCollider>().isTrigger=true;
        cube.GetComponent<Image>().sprite = ZniczSprite;
        cube.transform.position = spawnPosition;
        cube.transform.localScale+=size;
        blocksArray.SetValue(cube, x+(y*gridX));

    }
    #endregion
    #region ClickToFire
    public static bool CheckCandle(GameObject ClickedCandle)
    {
        if (Znicze.Instance.ZniczeToClikck.Contains(ClickedCandle))
        {
            Znicze.Instance.ZniczeToClikck.Remove(ClickedCandle);
            Znicze.Instance.End();
            return true;

        }
        Znicze.Instance.CreateList();
        return false;
        

    }
    public static void ChangeTexture(GameObject Candle)
    {
        Candle.GetComponent<Image>().sprite = Znicze.Instance.ZniczZapalonySprite;
    }
    void End()
    {
        Debug.Log(ZniczeToClikck.Count);
        if (ZniczeToClikck.Count <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    #endregion
}
