namespace OTO.Object
{
    //System
    using System.Collections;
    using System.Collections.Generic;

    //UnityEngine
    using UnityEngine;

    /// <summary>
    /// 총알이 파괴될때 소환되는 이펙트의 기능을 구현한 함수
    /// </summary>
    public class HitEffect : MonoBehaviour
    {
        [SerializeField] private float destoryTime = default;

        /// <summary>
        /// 이펙트가 소환되면 일정시간 뒤에 파괴되게 하는 코드
        /// </summary>
        private void Start()
        {
            Invoke("DestroyEffect", destoryTime);
        }

        /// <summary>
        /// 이펙트를 파괴하는 함수
        /// </summary>
        private void DestroyEffect()
        {
            Destroy(gameObject);
        }
    
    }
}


