using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    private BuildManager buildManager;
    private StructureSO structureSO;

    [SerializeField]
    private GameObject craftUI; //������ UI������Ʈ
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

            if (Input.GetMouseButtonDown(0) && previewObj.GetComponent<PreviewStructure>().IsBuildable())
            {
                FixPreviewPosition();
            }
        }
    }

    public void CreatePreviewObject(StructureSO structureInfo)
    {
        structureSO = structureInfo;
        previewObj = Instantiate(previewStructure, pos, Quaternion.identity);

        //������ �� ���� ����
        Vector3 structureSize = new Vector3(structureSO.structureSizeX, structureSO.structureSizeY, structureSO.structureSizeZ); //������ ������Ʈ ������

        previewObj.GetComponent<MeshFilter>().sharedMesh = structureSO.structureObj.GetComponent<MeshFilter>().sharedMesh; //�����������Ʈ �޽� ����
        previewObj.transform.localScale = structureSize; //������ ũ��
        previewObj.GetComponent<BoxCollider>().size = structureSize; //������ ��ġũ�⺯��
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

    public void FixPreviewPosition()
    {
        Vector3 uiPos = new Vector3(previewObj.transform.position.x, 5, previewObj.transform.position.z);
        GameObject _craftUI = Instantiate(craftUI, uiPos, Quaternion.Euler(90f, 0f, 0f)); //��ġ�� ȸ���� ������ UI������Ʈ ����

        //UI�� ������ �ǹ� ���� �ѱ��
        _craftUI.GetComponent<CraftUI>().structurePos = previewObj.transform.position; //preview ������Ʈ ��ġ
        _craftUI.GetComponent<CraftUI>().previewObj = previewObj;
        _craftUI.GetComponent<CraftUI>().structureObj = structureSO.structureObj;
        _craftUI.GetComponent<CraftUI>().structureSO = structureSO;
        
        previewObj = null;
    }
}
