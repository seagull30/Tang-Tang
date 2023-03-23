using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackGroundController : MonoBehaviour
{
    [SerializeField]
    private GameObject BGPrefab;

    private GameObject[] BGPool = new GameObject[9];

    private readonly int[] dirY = { 1, 1, 1, 0, 0, 0, -1, -1, -1 };
    private readonly int[] dirX = { 1, 0, -1, 1, 0, -1, 1, 0, -1 };
    const float size = 10.2f;
    private Vector3 vec;

    private GameObject centerObj;

    public event UnityAction<GameObject> change;



    private void Awake()
    {
        for (int i = 0; i < 9; ++i)
        {
            BGPool[i] = Instantiate(BGPrefab, gameObject.transform);
            vec.Set(dirX[i], dirY[i], 0);
            BGPool[i].transform.position = GameManager.Instance.player.transform.position + vec * size;
        }
    }
    private void Start()
    {
        for (int i = 0; i < 9; ++i)
        {
            BackGround BG = BGPool[i].GetComponent<BackGround>();
            Debug.Assert(BG != null);
            BG.OnPlayerBG += changeCenter;
            BG.PlayerOut += PlyerMove;
            change += BG.moveBG;
        }

    }

    private void changeCenter(GameObject obj)
    {
        centerObj = obj;
    }

    private void PlyerMove()
    {
        change.Invoke(centerObj);
    }   

}
