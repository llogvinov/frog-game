namespace Core.StateMachine
{
    public interface IState
    {
        void Exit();
    }

    public interface ISimpleState : IState
    {
        void Enter();
    }

    public interface IPayloadState<TPayload> : IState
    {
        void Enter(TPayload payload);
    }
}