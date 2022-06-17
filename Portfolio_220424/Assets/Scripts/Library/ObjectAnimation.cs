using System.Collections;
using UnityEngine;

namespace HEEUNG
{
    //Hierachy�� �÷��� ������Ʈ�� �ִϸ��̼� �ִ°�
    public class ObjectAnimation : MonoBehaviour
    {
        GameObject obj;
        
        bool bOpenning, bClosing; //�ִϸ��̼� ������ ǥ��
        bool isMoving;
        
        public void SetObj(bool OpenClose, int location, GameObject objName)
        {
            obj = objName;
            //OpenClose true�� ����, false�� �ݱ�
            //location 0�� ���Ծ���, 1�� ����� 
           
            if (OpenClose)
            {
                if (bOpenning) return;

                bOpenning = true;
                StartCoroutine(OpenObj());

                if(location == 1)
                {
                    if (isMoving) return;

                    isMoving = true;
                    StartCoroutine(FromRightUpToCenterCenter());
                }     
            }
            else
            {
                if (bClosing) return;

                bClosing = true;
                StartCoroutine(CloseObj());
            }
        }

        IEnumerator OpenObj()
        {
            float fInit = 0f;

            while (fInit <= 1.0f)
            {
                fInit += 0.1f;
                yield return new WaitForSeconds(0.01f);
                obj.transform.localScale = new Vector3(fInit, fInit, fInit);
            }

            bOpenning = false;
        }

        IEnumerator CloseObj()
        {
            float fInit = 1f;

            while (fInit >= 0f)
            {
                fInit -= 0.1f;
                yield return new WaitForSeconds(0.01f);
                obj.transform.localScale = new Vector3(fInit, fInit, fInit);
            }

            bClosing = false;
        }


        //������ ������ ����� ����
        IEnumerator FromRightUpToCenterCenter()
        {
            //anchor�� 0.5�� �ǵ���

            float fInit_x = 1f;
            float fInit_y = 1f;

            while (fInit_x >= 0.5f || fInit_y >= 0.5f)
            {
                Debug.Log("Moving");

                if (fInit_x >= 0.5f) fInit_x -= 0.02f;
                if (fInit_y >= 0.5f) fInit_y -= 0.02f;

                yield return new WaitForSeconds(0.01f);
                ((RectTransform)obj.transform).anchorMax  = new Vector2(fInit_x, fInit_y);
                ((RectTransform)obj.transform).anchorMin = new Vector2(fInit_x, fInit_y);

            }

            isMoving = false;
        }

    }
}



