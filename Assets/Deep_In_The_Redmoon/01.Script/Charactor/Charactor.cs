namespace OTO.Charactor
{
    //System
    using System.Collections;
    using System.Collections.Generic;
    using Unity.VisualScripting;

    //UnityEngine
    using UnityEngine;
    using UnityEngine.Experimental.GlobalIllumination;

    //Project
    using OTO.Manager;

    /// <summary>
    /// 생명이 있는 모든 객체들의 부모클래스
    /// </summary>
    public class Charactor : MonoBehaviour
    {
        [Header("Material")]
        [SerializeField] protected Material flashMaterial = null;

        [Header("CharactorInfo")]
        public bool isDead = default;


        protected new SpriteRenderer renderer = null;
        protected Material originMaterial = null;
        public float currentHp = default;
        public float maxHp = default;

        private const float duration = 0.05f;

        /// <summary>
        /// 변수 초기화
        /// </summary>
        protected virtual void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            originMaterial = renderer.material;

            currentHp = maxHp;
        }

        /// <summary>
        /// 대미지를 받을때 실행되는 함수
        /// </summary>
        /// <param name="damage"></param>
        public virtual void TakeDamage(float damage)
        {
            currentHp -= damage;

            SpriteFlash();

            if ((!isDead && currentHp <= 0))
            {
                Die();
            }
        }

        //사망 처리
        protected virtual void Die() 
        {
            isDead = true;
            AudioManager.instance.PlaySFX("Dead");
        }

        /// <summary>
        /// 대미지를 받았을때 깜빡거림 기능을 구현한 함수
        /// </summary>
        private void SpriteFlash()
        {
            StartCoroutine(Co_SpriteFlash());
        }


        /// <summary>
        /// 스프라이트의 깜빡거림을 구혆한 코루틴
        /// </summary>
        /// <returns></returns>
        private IEnumerator Co_SpriteFlash()
        {
            renderer.material = flashMaterial;

            yield return new WaitForSeconds(duration);

            renderer.material = originMaterial;
        }
    }
}