public interface IParser<T>
{
    T Parse(string rawData);
}