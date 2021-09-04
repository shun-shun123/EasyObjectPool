# EasyObjectPool
## EasyObjectPoolとは？
EasyObjectPoolは、UnityでObjectPoolをなるべく簡単に使用できるように設計された軽量ライブラリです。
EasyObjectPoolはほとんどコーディングすることなくObjectPoolの機能を使用することができます。
EasyObjectPoolは、Rent from ObjectPoolやReturn to ObjectPoolなどの必要最低限の機能のみ実装ししています。

## はじめに
EasyObjectPoolは非常に簡単で、2ステップで使用できます。

### Step 1: プールするオブジェクト用にコンポーネントを実装する
プールするコンポーネントにはIPoolElementを実装します。このインターフェイスは、ObjectPoolからオブジェクトを取得する際のコールバックと、ObjectPoolにオブジェクトを戻す際のコールバックが定義されています。

```cs
public class SphereModule : MonoBehaviour, IPoolElement<SphereModule>
{
    public void OnActive()
    {
        Debug.Log("OnActivate");
    }

    public void OnDeActive()
    {
        Debug.Log("OnDeActivate");
    }
}
```

### Step 2: Step 1で作成したオブジェクトのObjectPoolを実装する。
ObjectPoolを実装するには、BaseObjectPoolを継承するだけのシンプルな方法があります。
ステップ1で作成したコンポーネントをgeneric typeの引数に指定します。

```cs
public class SphereObjectPool : BaseObjectPool<SphereModule>
{
}
```