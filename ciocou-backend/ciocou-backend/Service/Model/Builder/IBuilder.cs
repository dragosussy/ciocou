namespace Service.Model.Builder
{
    public interface IBuilder<T>
    {
        IBuilder<T> Reset();

        T Build();
    }
}
