using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class NetConnection
{
    public const int SkipPacketHead = 4;    // 跳过包头，无用的数据
    public const int PacketLength = 64 * 1024;  // 单个包最大字节数
    private readonly byte[] _cacheReader = new byte[PacketLength];    // 一个包大小最多64KB

    private TcpClient _tcp = new TcpClient();  // TCP连接
    private NetworkStream _stream;                  // 网络流字节处理
    private MemoryStream _readerMemory;    // 接收协议包缓存块
    private BinaryReader _reader;          // 接收协议包字节处理
    private MemoryStream _writerMemory;    // 发送协议包缓存块
    private BinaryWriter _writer;          // 发送协议包字节处理

    private int _lastPacketLength;      // 未读取的包长

    public Action OnConnected;          // 连接上服务器回调

#if UNITY_EDITOR
    public static Dictionary<short, string> MessageType;    // 消息类型   key:type of int; value:typeName of String
#endif


    public NetConnection()
    {
        _readerMemory = new MemoryStream(_cacheReader);
        _reader = new CustomBinaryReader(_readerMemory);
        _writerMemory = new MemoryStream(PacketLength);
        _writer = new BinaryWriter(_writerMemory);

#if UNITY_EDITOR
        if (MessageType != null)
            return;

        MessageType = new Dictionary<short, string>();

        TextAsset asset = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Scripts/Protocol/MessageType.cs", typeof(TextAsset)) as TextAsset;
        string data = asset.text;
        int beginIndex = 0;
        const string msg = "public const short MSG_";
        while (true)
        {
            beginIndex = data.IndexOf(msg, beginIndex, StringComparison.Ordinal);
            if (beginIndex < 0)
                break;
            var endIndex = data.IndexOf(" = ", beginIndex, StringComparison.Ordinal);
            beginIndex += msg.Length;
            string messageTypeName = data.Substring(beginIndex, endIndex - beginIndex);
            beginIndex = endIndex + 3;
            endIndex = data.IndexOf(";", beginIndex, StringComparison.Ordinal);
            short msgType = Convert.ToInt16(data.Substring(beginIndex, endIndex - beginIndex));

            beginIndex = data.IndexOf("//", endIndex, StringComparison.Ordinal);
            endIndex = data.IndexOf("\n", endIndex, StringComparison.Ordinal);
            string messageComment = data.Substring(beginIndex, endIndex - beginIndex);
            MessageType[msgType] = messageTypeName + messageComment;
        }
#endif
    }

    public void Dispose()
    {
        _reader.Close();
        _reader = null;
        _readerMemory.Dispose();
        _readerMemory = null;

        _writer.Close();
        _writer = null;
        _writerMemory.Dispose();
        _writerMemory = null;

        if (_stream != null)
        {
            _stream.Dispose();
            _stream = null;
        }
        if (_tcp != null)
        {
            _tcp.Close();
            _tcp = null;
        }
    }

    public bool Send(byte[] packet, object className)
    {
        if (_tcp == null || !_tcp.Connected)
        {
            Debug.Log("网络未连接" + className.GetType().Name);
            return false;
        }

        _writerMemory.SetLength(0);

        // C++不同平台下会有不同编码规定，进行8位对齐后可以解决这问题
        var modByte = packet.Length % 8;

        short length = (short)(packet.Length + 2);
        if (modByte != 0)
        {
            length += (short)(8 - modByte);
        }

        _writer.Write(length);
        _writer.Write(packet);

        if (modByte != 0)
        {
            for (int i = 0; i < 8 - modByte; i++)
            {
                _writer.Write((byte)0);
            }
        }

        var bytes = _writerMemory.ToArray();
        _stream.BeginWrite(bytes, 0, bytes.Length, OnWrote, _tcp);

#if UNITY_EDITOR
        byte[] typeBytes = new byte[2];
        Buffer.BlockCopy(packet, 0, typeBytes, 0, 2);
        var type = BitConverter.ToInt16(typeBytes, 0);
        Debug.Assert(length == bytes.Length);
        Debug.Log(string.Format("发送协议{0}, length:{1}, {2}", type, bytes.Length, MessageType[type]));
#endif

        return true;
    }

    private void OnWrote(IAsyncResult ar)
    {
        try
        {
            _stream.EndWrite(ar);
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
        }
    }

    public bool Connected
    {
        get { return _tcp.Connected; }
    }

    public void Connect(string host, int port)
    {
        try
        {
            _tcp.BeginConnect(host, port, OnConnectedHandler, _tcp);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    private void OnConnectedHandler(IAsyncResult ar)
    {
        try
        {
            _tcp.EndConnect(ar);

            _stream = _tcp.GetStream();
            _stream.BeginRead(_cacheReader, 0, _cacheReader.Length, OnInitNet, _cacheReader);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    private void OnInitNet(IAsyncResult ar)
    {
        try
        {
            var totalBytes = _stream.EndRead(ar);

            var encryptMode = _readerMemory.ReadByte();
            var keyLen = _readerMemory.ReadByte();
            byte[] key = new byte[keyLen];
            _readerMemory.Read(key, 0, keyLen);

            Debug.Log(string.Format("EncryptMode:{0}, KeyLen:{1}, Key:{2}", encryptMode, keyLen, Encoding.Default.GetString(key)));
            Debug.Assert(totalBytes == 10 && _readerMemory.Position == totalBytes);

            _stream.BeginRead(_cacheReader, 0, _cacheReader.Length, OnRead, _cacheReader);

            OnConnected();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    private void OnRead(IAsyncResult ar)
    {
        try
        {
            if (_stream == null || _tcp == null || !_tcp.Connected)
                return;

            var totalBytes = _stream.EndRead(ar);
            //Debug.Log(string.Format("Receive {0}bytes", totalBytes));

            // 在UnityEditor下，结束运行程序连接不会断开。此时读出的字节数为0。
            if (totalBytes == 0)
            {
                Debug.Log(string.Format("stream:{0}, data:{1}, read:{2}, write:{3}, seek:{4}, timeout:{5}, tcp:{6}, connect:{7}, available:{8}", 
                    _stream, _stream.DataAvailable, _stream.CanRead, _stream.CanWrite, _stream.CanSeek, _stream.CanTimeout, _tcp, _tcp.Connected, _tcp.Available));
                return;
            }

            ReadPacket(totalBytes);

            _stream.BeginRead(_cacheReader, _lastPacketLength, _cacheReader.Length - _lastPacketLength, OnRead, _cacheReader);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    private void ReadPacket(int totalBytes)
    {
        Debug.Assert(totalBytes > 0);

        _readerMemory.Position = 0;

        int packetLength; // 单个包长度，如果是并包，则要保存字节流，以便下次读取
        if (_lastPacketLength == 0)
        {
            packetLength = _reader.ReadUInt16() - 2;
        }
        else
        {
            packetLength = _lastPacketLength;
            _lastPacketLength = 0;
        }

        // 当可用的字节数大于包长度，不断读取单个包
        while (totalBytes - _readerMemory.Position >= packetLength)
        {
            // 当前包读取完后的位置
            var nextPosition = _readerMemory.Position + packetLength;

            // 读取单个包
            var msgType = _reader.ReadInt16();
            // 跳过包头，服务端需要用到，客户端没有用到
            _readerMemory.Position += SkipPacketHead;
            // 消息处理程序
            NetMessage.DispatchMessage(msgType, _reader, packetLength);

            // 如果消息处理程序没有读取数据，主动跳过这段数据
            if (_readerMemory.Position != nextPosition)
                _readerMemory.Position = nextPosition;

            _lastPacketLength = 0;
            packetLength = 0;

            if (totalBytes - _readerMemory.Position <= 2)
                break;
            packetLength = _reader.ReadUInt16() - 2;
        }

        // 这次包还没读完，下次读取
        if (totalBytes - _readerMemory.Position < packetLength)
            _lastPacketLength = packetLength;
    }
}
