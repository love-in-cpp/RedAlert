using UnityEngine;

public class GameLoop : MonoBehaviour
{
    // Start is called before the first frame update
    private SceneStateController _controller;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _controller = new SceneStateController();
        _controller.SetState(new StartState(_controller), false);
    }

    // Update is called once per frame
    private void Update()
    {
        _controller.StateUpdate();
    }
}