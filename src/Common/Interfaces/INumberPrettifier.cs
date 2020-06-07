namespace Common.Interfaces
{
    public interface INumberPrettifier
    {
        public string Prettify<T>(T number);
    }
}
