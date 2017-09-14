using System.IO;
using System.Text;

public interface IProtocol
{
    void ReadFromStream(BinaryReader reader);
    void WriteToStream(BinaryWriter writer);
    short GetMsgType { get; }
}

public sealed class ProtocolBuffer
{
    public static readonly MemoryStream CacheStream = new MemoryStream();

    public static readonly BinaryWriter MemoryWriter = new CustomBinaryWriter(CacheStream);
    public static BinaryWriter Writer
    {
        get
        {
            MemoryWriter.BaseStream.SetLength(0);
            return MemoryWriter;
        }
    }

    public const uint Zero = 0;
    public static readonly UTF8Encoding Encoding = new UTF8Encoding();
}

public class CustomBinaryReader : BinaryReader
{
    public CustomBinaryReader(Stream stream) : base(stream)
    {
    }

    public override string ReadString()
    {
        short byteCount = ReadInt16();
        byte[] buffer = ReadBytes(byteCount);
        string result = ProtocolBuffer.Encoding.GetString(buffer, 0, byteCount);
        return result;
    }
}

public class CustomBinaryWriter : BinaryWriter
{
    public CustomBinaryWriter(Stream stream) : base(stream)
    {
    }

    public override void Write(string value)
    {
        short byteCount = (short)ProtocolBuffer.Encoding.GetByteCount(value);
        byte[] buffer = ProtocolBuffer.Encoding.GetBytes(value);
        base.Write(byteCount);
        if (buffer.Length > 0)
            base.Write(buffer);
    }
}