//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BonusHolder : MonoBehaviour
//{
//    private const string BonusPrefabPath = "Bonuses/";
//    [SerializeField] private List<BonusPrefabData> _bonusPrefabList;
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.R))
//        {
//            //TestInstantiateRingShine();
//            TestInstantiateRingShineFromResources();
//        }
//        else if (Input.GetKeyDown(KeyCode.S))
//        {
//            TestInstantiateShineOvelFromResources();
//        }
//    }

//    private BonusPrefabData GetBonusPrefabData(BonusType type)
//    {
//        return _bonusPrefabList.Find(bonusPrefab => bonusPrefab.Type == type);
//    }

//    //private void TestInstantiateRingShine()
//    //{
//    //    var prefabData = GetBonusPrefabData(BonusType.RingShine);
//    //    Instantiate(prefabData.Behaviour);
//    //}

//    private void TestInstantiateRingShineFromResources()
//    {
//        var path = $"{BonusPrefabPath}{BonusType.BallSpeedDown.ToString()}";
//        var bonusBehaviour = Resources.Load<BonusBehaviour>(path);
//        Instantiate(bonusBehaviour);
//    }

//    //private void TestInstantiateShineOvel()
//    //{
//    //    var prefabData = GetBonusPrefabData(BonusType.ShineOval);
//    //    Instantiate(prefabData.Behaviour);
//    //}

//    private void TestInstantiateShineOvelFromResources()
//    {
//        var path = $"{BonusPrefabPath}{BonusType.SuperBall.ToString()}";
//        var bonusBehaviour = Resources.Load<BonusBehaviour>(path);
//        Instantiate(bonusBehaviour);
//    }
//}
//public class BonusBehaviour : MonoBehaviour
//{
//    public BonusType Type;
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
//public enum BonusType
//{
//    BallSpeedDown,
//    SuperBall
//}
//[Serializable]
//public class BonusPrefabData
//{
//    public BonusType Type;
//    public BonusBehaviour Behaviour;
//}

