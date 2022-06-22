using UnityEngine;

public class UniRxSender : MonoBehaviour
{
    private void Start()
    {
        SomeScript.DataStream.Fire(System.DateTime.Now.Ticks);
    }
}