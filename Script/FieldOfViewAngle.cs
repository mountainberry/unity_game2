using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewAngle : MonoBehaviour
{
    [SerializeField] private float viewAngle;  // �þ� ���� (130��)
    [SerializeField] private float viewDistance; // �þ� �Ÿ� (10����)
    [SerializeField] private LayerMask targetMask;  // Ÿ�� ����ũ(�÷��̾�)

    private Chicken theChicken;

    void Start()
    {
        theChicken= GetComponent<Chicken>();
    }

    void Update()
    {
        View();  // �� �����Ӹ��� �þ� Ž��
    }

    private Vector3 BoundaryAngle(float _angle)
    {
        _angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(_angle * Mathf.Deg2Rad), 0f, Mathf.Cos(_angle * Mathf.Deg2Rad));
    }

    private void View()
    {
        Vector3 _leftBoundary = BoundaryAngle(-viewAngle * 0.5f);  // z �� �������� �þ� ������ ���� ������ŭ �������� ȸ���� ���� (�þ߰��� ���� ��輱)
        Vector3 _rightBoundary = BoundaryAngle(viewAngle * 0.5f);  // z �� �������� �þ� ������ ���� ������ŭ ���������� ȸ���� ���� (�þ߰��� ������ ��輱)

        Debug.DrawRay(transform.position + transform.up, _leftBoundary, Color.red);
        Debug.DrawRay(transform.position + transform.up, _rightBoundary, Color.red);

        Collider[] _target = Physics.OverlapSphere(transform.position, viewDistance, targetMask);

        for (int i = 0; i < _target.Length; i++)
        {
            Transform _targetTf = _target[i].transform;
            if (_targetTf.name == "Player")
            {
                Vector3 _direction = (_targetTf.position - transform.position).normalized;
                float _angle = Vector3.Angle(_direction, transform.forward);

                if (_angle < viewAngle * 0.5f)
                {
                    RaycastHit _hit;
                    if (Physics.Raycast(transform.position + transform.up, _direction, out _hit, viewDistance))
                    {
                        if (_hit.transform.name == "Player")
                        {
                            Debug.Log("�÷��̾ ���� �þ� ���� �ֽ��ϴ�.");
                            Debug.DrawRay(transform.position + transform.up, _direction, Color.blue);

                            theChicken.Run(_hit.transform.position);
                        }
                    }
                }
            }
        }
    }
}
