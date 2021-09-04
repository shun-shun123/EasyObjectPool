# EasyObjectPool
## What is EasyObjectPool?
EasyObjectPool is a lightweight library designed to make it as easy as possible to use ObjectPool in Unity.
It allows users to use ObjectPool with little or no additional coding, and provides the minimum functionality required for ObjectPool.
EasyObjectPool implements only the minimum required functions, such as Rent from ObjectPool and Return to ObjectPool.

## Introduction
Using EasyObjectPool is very easy, and you can use the ObjectPool features in two steps.

### Step 1: Implement a component to attach to the pooled object.
Implement IPoolElement for the component to be pooled. This interface defines callback methods for enabling objects to be retrieved from the ObjectPool, and for disabling objects to be returned to the ObjectPool.

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

### Step 2: Implement the ObjectPool for the object created in Step 1.
The next step is to implement the ObjectPool itself, which is nice and simple, just by inheriting from BaseObjectPool.
Specify the component created in step 1 as the generic type argument.

```cs
public class SphereObjectPool : BaseObjectPool<SphereModule>
{
}
```