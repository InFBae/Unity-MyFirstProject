using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
    public void GameObjectBasic()
    {
        // <���� ������Ʈ ����>
        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ�� gameObject �Ӽ��� �̿��Ͽ� ���ٰ���

        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ
        // gameObject.name
        // gameObject.active
        // gameObject.tag
        // gameObject.layer

        GameObject.FindGameObjectWithTag("Player");

        // <���� ������Ʈ ����>
        GameObject newObject = new GameObject("New Game Object");
        
        // <���� ������Ʈ ����>        
        Destroy(newObject);
    }

    private void Start()
    {
        GameObjectBasic();
        ComponenetBasic();
    }

    public void ComponenetBasic()
    {
        // <���ӿ�����Ʈ �� ������Ʈ ����>
        GetComponent<AudioSource>();                // �����Ǿ� �ִ� ���ӿ�����Ʈ�� �������� ����
        gameObject.GetComponent<AudioSource>();     // ���ӿ�����Ʈ�� ������Ʈ ����
        GetComponents<AudioSource>();               // ������Ʈ�� �������� ���� ������Ʈ ����
        
        GetComponentInChildren<Rigidbody>();        // �ڽĵ� �����ؼ� ���� ã��
        GetComponentsInChildren<Rigidbody>();       // �ڽİ��ӿ�����Ʈ ���� ���� ������Ʈ ����

        GetComponentInParent<Rigidbody>();        // �θ�� �����ؼ� ���� ã��
        GetComponentsInParent<Rigidbody>();       // �θ���ӿ�����Ʈ ���� ���� ������Ʈ ����

        // <������Ʈ Ž��>
        FindObjectOfType<AudioSource>();            // �� ���� ������Ʈ Ž��
        FindObjectsOfType<AudioSource>();           // �� ���� ��� ������Ʈ Ž��

        // <������Ʈ �߰�>
        Rigidbody rigidbody = new Rigidbody();      // �����ϳ� �ǹ� ����, ������Ʈ�� ���� ������Ʈ�� �����Ǿ� �־�� �۵�
        AudioSource source = gameObject.AddComponent<AudioSource>();     // ���ӿ�����Ʈ�� ������Ʈ �߰�

        // <������Ʈ ����>
        Destroy(source);
    }
}
