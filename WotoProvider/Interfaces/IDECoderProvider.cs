using System.Text;

namespace WotoProvider.Interfaces
{
    public interface IDECoderProvider<T1, T2>
    {
        Encoding TheEncoderValue { get; }
        T1 GetDecodedValue(T2 value);
    }
}
