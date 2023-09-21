using MySql.Data.MySqlClient;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginPanel : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI messageText;

    [Space]

    [Header("Login")]
    [SerializeField] private TMP_InputField idText;
    [SerializeField] private TMP_InputField pwText;
    [SerializeField] private GameObject loginPage;

    [Space]

    [Header("Register")]
    [SerializeField] private TMP_InputField useIDRegisterText;
    [SerializeField] private TMP_InputField usePWRegisterText;
    [SerializeField] private GameObject registerPage;

    private string query;

    public void Login(string id, string pw)
    {
        string loginQuery = $"SELECT * FROM user_info WHERE ID='{id}'";

        Debug.Log(SQLManager.Instance);
        Debug.Log(SQLManager.Instance.sqlConnection);
        Debug.Log(SQLManager.Instance.sqlConnection.State);
        MySqlCommand checkCmd = new MySqlCommand(loginQuery, SQLManager.Instance.sqlConnection);
        SQLManager.Instance.reader = checkCmd.ExecuteReader();

        if (SQLManager.Instance.reader.HasRows)
        {
            while (SQLManager.Instance.reader.Read())
            {
                if (id == (string)SQLManager.Instance.reader["ID"] &&
                    pw == (string)SQLManager.Instance.reader["Password"])
                {
                    // TODO: �α��� ���� ��
                    LoadingController.LoadScene("GameScene");
                    //messageText.text = "�α��� ����!";

                    Debug.Log("�α��� ����!");
                }
                else
                {
                    Debug.Log("��й�ȣ�� ��ġ���� �ʽ��ϴ�!");
                }
            }
        }
        else
        {
            Debug.Log("���̵� Ȥ�� ��й�ȣ�� �߸��Ǿ����ϴ�!");
        }
        SQLManager.Instance.reader.Close();
    }

    public void Register(string inputID, string inputPW)
    {
        string checkQuery = $"SELECT ID FROM user_info WHERE ID='{inputID}'";

        MySqlCommand checkUserCmd = new MySqlCommand(checkQuery, SQLManager.Instance.sqlConnection);
        SQLManager.Instance.reader = checkUserCmd.ExecuteReader();

        if (SQLManager.Instance.reader.HasRows)
        {
            Debug.Log("�ߺ��� ���̵��Դϴ�!");

            if (!SQLManager.Instance.reader.IsClosed)
                SQLManager.Instance.reader.Close();
        }
        else
        {
            SQLManager.Instance.reader.Close();

            query = $"INSERT INTO user_info (ID, Password) VALUES ('{inputID}', '{inputPW}')";

            try
            {
                SQLManager.Instance.SQLUpdateOrInsert(query);
                Debug.Log("ȸ������ �Ϸ�!");
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    public void OnClickLoginButton()
    {
        string id = idText.text;
        string pw = pwText.text;

        Login(id, pw);
    }

    public void OnClickRegisterButton()
    {
        string inputID = useIDRegisterText.text;
        string inputPW = usePWRegisterText.text;

        Register(inputID, inputPW);
    }

    public void OpenLoginPage()
    {
        loginPage.SetActive(true);
        registerPage.SetActive(false);
        titleText.text = "�α���";
    }

    public void OpenRegisterPage()
    {
        loginPage.SetActive(false);
        registerPage.SetActive(true);
        titleText.text = "ȸ������";
    }
}

