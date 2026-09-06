using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
  [System.Serializable]
    private class ObjectInfo
    {
        // 오브젝트 이름
        public string ObjectName;
        // 오브젝트 풀에서 관리할 오브젝트
        public GameObject Perfeb;
        // 몇개를 미리 생성 해놓을건지
        public int Count;
    }


    public static ObjectPoolManager instance;

    // 오브젝트풀 매니저 준비 완료표시
    public bool IsReady { get; private set; }

    [SerializeField]
    private ObjectInfo[] ObjectInfos = null;

    // 생성할 오브젝트의 key값지정을 위한 변수
    private string ObjectName;

    // 오브젝트풀들을 관리할 딕셔너리
    private Dictionary<string, IObjectPool<GameObject>> ObjectPoolDic = new Dictionary<string, IObjectPool<GameObject>>();

    // 오브젝트풀에서 오브젝트를 새로 생성할때 사용할 딕셔너리
    private Dictionary<string, GameObject> ObjDic = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        Init();
    }


    private void Init()
    {
        IsReady = false;

        for (int idx = 0; idx < ObjectInfos.Length; idx++)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
            OnDestroyPoolObject, true, ObjectInfos[idx].Count, ObjectInfos[idx].Count);

            if (ObjDic.ContainsKey(ObjectInfos[idx].ObjectName))
            {
                Debug.LogFormat("{0} 이미 등록된 오브젝트입니다.", ObjectInfos[idx].ObjectName);
                return;
            }

            ObjDic.Add(ObjectInfos[idx].ObjectName, ObjectInfos[idx].Perfeb);
            ObjectPoolDic.Add(ObjectInfos[idx].ObjectName, pool);

            // 미리 오브젝트 생성 해놓기
            for (int i = 0; i < ObjectInfos[idx].Count; i++)
            {
                ObjectName = ObjectInfos[idx].ObjectName;
                ObjectBase poolAbleGo = CreatePooledItem().GetComponent<ObjectBase>();
                poolAbleGo.Pool.Release(poolAbleGo.gameObject);
            }
        }

        Debug.Log("오브젝트풀링 준비 완료");
        IsReady = true;
    }

    // 생성
    private GameObject CreatePooledItem()
    {
        GameObject PoolObj = Instantiate(ObjDic[ObjectName]);
        PoolObj.GetComponent<ObjectBase>().Pool = ObjectPoolDic[ObjectName];

        return PoolObj;
    }

    // 대여
    private void OnTakeFromPool(GameObject PoolObj)
    {
        PoolObj.SetActive(true);
    }

    // 반환
    private void OnReturnedToPool(GameObject PoolObj)
    {
        PoolObj.SetActive(false);
    }

    // 삭제
    private void OnDestroyPoolObject(GameObject PoolObj)
    {
        Destroy(PoolObj);
    }

    public GameObject GetObj(string ObjName)
    {
        ObjectName = ObjName;

        if (ObjDic.ContainsKey(ObjName) == false)
        {
            Debug.LogFormat("{0} 오브젝트풀에 등록되지 않은 오브젝트입니다.", ObjName);
            return null;
        }

        return ObjectPoolDic[ObjName].Get();
    }
}