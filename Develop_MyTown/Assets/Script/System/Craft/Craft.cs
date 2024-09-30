using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    private BuildManager buildManager;

    [SerializeField]
    private GameObject previewStructure; //������ ������ ������Ʈ
    private GameObject previewObj; //������ ������ ������Ʈ

    private Vector3 viewPos;
    private Vector3 pos;

    private RaycastHit hit;

    void Awake()
    {
        buildManager = FindObjectOfType<BuildManager>();
    }

    void Update()
    {
        if (buildManager.buildMode == StateManager.BuildMode.Build && previewObj != null)
        {
            PreviewPositionUpdate();
        }
    }

    public void CreatePreviewObject(StructureSO structureInfo)
    {
        previewObj = Instantiate(previewStructure, pos, Quaternion.identity);
        previewObj.GetComponent<MeshFilter>().sharedMesh = structureInfo.structureObj.GetComponent<MeshFilter>().sharedMesh;
    }

    public void PreviewPositionUpdate()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            viewPos = Camera.main.WorldToViewportPoint(hit.point);
            pos = Camera.main.ViewportToWorldPoint(viewPos);

            previewObj.transform.position = new Vector3(pos.x, 0, pos.z);
        }
    }

    //��ư���� ���� Ȯ���ϱ�
    public void DecideConstruction()
    {

    }
    //��ư���� ���� ����ϱ�
    public void CancelConstruction()
    {

    }
}
