using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshProを使うために必要
using System.IO; // ファイルを扱うために必要

// 変換したJsonを受け取るクラス(箱)を用意
[System.Serializable]
public class PokemonJsonData
{
    // APIの取得したいデータのキーに合わせる
    public string name;
}


public class ShowJson : MonoBehaviour
{
    // TestMeshPro(TMP)のコンポーネントを格納する変数
    private TextMeshPro displayText;

    // Start is called before the first frame update
    void Start()
    {
        // TestMeshPro(TMP)のコンポーネントを取得
        displayText = GetComponent<TextMeshPro>();

        // プロジェクト内のJsonファイルを取得する
        // ファイルパスを作成
        string filePath =
         Path.Combine(Application.streamingAssetsPath,"data.json");
        
        // ファイルの存在チェック
        if(File.Exists(filePath))
        {
            // ファイルがある場合
            // Jsonデータを取得する(テキストデータとして取得される)
            string json = File.ReadAllText(filePath);
            // JsonHelperを使用して、テキストのJsonを扱いやすいように変換
            PokemonJsonData jsonData = JsonUtility.FromJson<PokemonJsonData>(json);

            displayText.text = jsonData.name;
        } else {
            // ファイルが無い場合
            displayText.text = "Not File";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
