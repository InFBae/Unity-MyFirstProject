using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCoroutine : MonoBehaviour
{
    /************************************************************************
         * �ڷ�ƾ (Coroutine)
         * 
         * �۾��� �ټ��� �����ӿ� �л��� �� �ִ� �񵿱�� �۾�
         * �ݺ������� �۾��� �л��Ͽ� �����ϸ�, ������ �Ͻ������ϰ� �ߴ��� �κк��� �ٽý����� �� ����
         * ��, �ڷ�ƾ�� �����尡 �ƴϸ� �ڷ�ƾ�� �۾��� ������ ���� �����忡�� ����
         ************************************************************************/

    // <�ڷ�ƾ ����>
    // �ݺ������� �۾��� StartCoroutine�� ���� ����

    private void Start()
    {
        StartCoroutine(SubRoutine());
    }

    IEnumerator SubRoutine()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("�α� ���");
        
        for (int i = 1; i <= 10; i++)
        {          
            yield return new WaitForSeconds(1f);
            Debug.Log($"{i}�� ����");
        }
    }

    private Coroutine routine;
    private void CoroutineStart()
    {
        routine = StartCoroutine(SubRoutine());
    }

    // <�ڷ�ƾ ����>
    // StopCoroutine�� ���� ���� ���� �ڷ�ƾ ����
    // StopAllCoroutine�� ���� ���� ���� ��� �ڷ�ƾ ����
    // �ݺ������� �۾��� ��� �Ϸ�Ǿ��� ��� �ڵ� ����
    // �ڷ�ƾ�� �����Ų ��ũ��Ʈ�� ��Ȱ��ȭ�� ��� �ڵ� ����

    private void CoroutineStop()
    {
        StopCoroutine(routine);     // ������ �ڷ�ƾ ����
        StopAllCoroutines();        // ��� �ڷ�ƾ ����
    }

    // <�ڷ�ƾ �ð� ����>
    // �ڷ�ƾ�� �ð� ������ �����Ͽ� �ݺ������� �۾��� ���� Ÿ�̹��� ������ �� ����
    IEnumerator CoRoutineWait()
    {
        yield return new WaitForSeconds(1);     // n�ʰ� �ð�����
        yield return null;                      // �ð����� ����
    }
}