using System.Collections;
using UnityEngine;

public class DissolveExample : MonoBehaviour
{
    [Header("Dissolve")]
    [SerializeField] private float _dissolveSpeed = 1;
    [SerializeField] private float _dissolveWait = 1;
    [Space]
    [SerializeField] private bool _useIndex;
    [SerializeField] private SkinnedMeshRenderer _dissolveMesh;
    [SerializeField] private int _dissolveMeshIndex;

    [Header("References")]
    [SerializeField] private Material _dissolveMaterial;

    private bool _isDissolving;

    private float _dissolveValue;
    private float _valueStart = 1;
    private float _valueEnd = 0;

    private int hash_Dissolve = Shader.PropertyToID("_DISSOLVE");

    private void Start()
    {
        if (_useIndex)_dissolveMaterial = _dissolveMesh.materials[_dissolveMeshIndex];

        _dissolveMaterial.SetFloat(hash_Dissolve, _valueStart);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isDissolving)
        {
            StartCoroutine(MakeDissolve());
        }
    }

    private IEnumerator MakeDissolve()
    {
        _isDissolving = true;

        _dissolveValue = _valueStart;

        while (_dissolveValue > _valueEnd)
        {
            _dissolveValue -= Time.deltaTime * _dissolveSpeed;
            _dissolveMaterial.SetFloat(hash_Dissolve, _dissolveValue);
            yield return null;
        }

        _dissolveValue = _valueEnd;

        Debug.Log($"<color=green><b> CHANGE! </b></color>");

        yield return new WaitForSeconds(_dissolveWait);

        while (_dissolveValue < _valueStart)
        {
            _dissolveValue += Time.deltaTime * _dissolveSpeed;
            _dissolveMaterial.SetFloat(hash_Dissolve, _dissolveValue);
            yield return null;
        }

        _isDissolving = false;
    }

}