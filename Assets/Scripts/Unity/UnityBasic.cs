using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
    public void GameObjectBasic()
    {
        // <게임 오브젝트 접근>
        // 컴포넌트가 붙어있는 게임오브젝트는 gameObject 속성을 이용하여 접근가능

        // 컴포넌트가 붙어있는 게임오브젝트
        // gameObject.name
        // gameObject.active
        // gameObject.tag
        // gameObject.layer

        GameObject.FindGameObjectWithTag("Player");

        // <게임 오브젝트 생성>
        GameObject newObject = new GameObject("New Game Object");
        
        // <게임 오브젝트 삭제>        
        Destroy(newObject);
    }

    private void Start()
    {
        GameObjectBasic();
        ComponenetBasic();
    }

    public void ComponenetBasic()
    {
        // <게임오브젝트 내 컴포넌트 접근>
        GetComponent<AudioSource>();                // 부착되어 있는 게임오브젝트를 기준으로 접근
        gameObject.GetComponent<AudioSource>();     // 게임오브젝트의 컴포넌트 접근
        GetComponents<AudioSource>();               // 컴포넌트를 기준으로 여러 컴포넌트 접근
        
        GetComponentInChildren<Rigidbody>();        // 자식들 포함해서 전부 찾기
        GetComponentsInChildren<Rigidbody>();       // 자식게임오브젝트 포함 여러 컴포넌트 접근

        GetComponentInParent<Rigidbody>();        // 부모들 포함해서 전부 찾기
        GetComponentsInParent<Rigidbody>();       // 부모게임오브젝트 포함 여러 컴포넌트 접근

        // <컴포넌트 탐색>
        FindObjectOfType<AudioSource>();            // 씬 내의 컴포넌트 탐색
        FindObjectsOfType<AudioSource>();           // 씬 내의 모든 컴포넌트 탐색

        // <컴포넌트 추가>
        Rigidbody rigidbody = new Rigidbody();      // 가능하나 의미 없음, 컴포넌트는 게임 오브젝트에 부착되어 있어야 작동
        AudioSource source = gameObject.AddComponent<AudioSource>();     // 게임오브젝트에 컴포넌트 추가

        // <컴포넌트 삭제>
        Destroy(source);
    }
}
