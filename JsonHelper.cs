using UnityEngine;

// JsonをUnityで扱いやすくするためのクラス
public class JsonHelper
{
    // public -> 他のクラスからも使える関数(privateでは他では使えない)
    // static -> インスタンスを生成しなくても使える(めんどくさい手順不要)
    // T -> ジェネリック型(どんな型でも使える)
    // T[] -> ジェネリック型(どんな型でも使える)の配列データが返却される
    // 返却されるデータの型を書かなければいけない(今回はT[]が返却される)
    // FromJson -> 関数名
    // <T> -> FromJsonが必要としている型
    // (string json) -> 呼び出したクラス(ファイル)から文字列のデータが渡されてくる
    // それが変数「json」に入っている
    // FromJsonの関数を呼び出すときは、必ず「文字列型のデータ」を渡してあげなければいけない
    public static T[] FromJson<T>(string json)
    {
        // UnityでJsonを扱う場合、[]で囲まれた形式のJsonを使う事はできない
        // {items:[.....]}の形式で囲む(ラップする)必要がある
        string wrappedJson = "{\"items\":" + json + "}";
        // Untiyで扱いやすいようにしてから返却
        return JsonUtility.FromJson<Wrapper<T>>(wrappedJson).items;
    }

    // Jsonをオブジェクト(扱いやすい)に変換する為のひな形
    // 入れ物の形を作っている
    // System.Serializable -> 外部のファイル(拡張機能)を扱うために必要
    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }
}
