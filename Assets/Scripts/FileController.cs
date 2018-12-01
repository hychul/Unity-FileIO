using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileController : MonoBehaviour
{
    [SerializeField]
    private InputField filenameInputField;

    [SerializeField]
    private InputField dataInputField;

    public void OnSaveButton()
    {
        FileIO.write<string>(dataInputField.text, filenameInputField.text);
    }

    public void OnLoadButton()
    {
        string strData = FileIO.read<string>(filenameInputField.text);
        dataInputField.text = strData;
    }

    public void OnSaveAsStringButton()
    {
        FileIO.write(dataInputField.text, filenameInputField.text);
    }

    public void OnLoadAsStringButton()
    {
        string strData = FileIO.read(filenameInputField.text);
        dataInputField.text = strData;
    }
}
