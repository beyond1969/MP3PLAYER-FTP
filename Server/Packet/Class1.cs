using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System.Reflection;
namespace Packet
{
    public enum PacketType
    {
        음악리스트,
        요청파일,
        음악파일
    }
    public enum PacketSendError
    {
        정상 = 0,
        에러
    }
    sealed class AllowAllAssemblyVersionsDeserializationBinder : System.Runtime.Serialization.SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;

            String currentAssembly = Assembly.GetExecutingAssembly().FullName;

            assemblyName = currentAssembly;

            typeToDeserialize = Type.GetType(String.Format("{0}, {1}",
                typeName, assemblyName));

            return typeToDeserialize;
        }
    }
    [Serializable]
    public class Packets
    {
        public int Length;
        public int Type;

        public Packets()
        {
            this.Length = 0;
            this.Type = 0;
        }
        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);   // 4 kb
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Deserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);   // 4 kb
            foreach (byte b in bt)
                ms.WriteByte(b);

            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            bf.Binder = new AllowAllAssemblyVersionsDeserializationBinder();

            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }
    
    [Serializable]
    public class MusicList : Packets
    {
        public string list;

        public MusicList()
        {
            this.list = null;
        }
    }
    [Serializable]
    public class RequestMusic : Packets
    {
        public string requestNo;

        public RequestMusic()
        {
            this.requestNo = null;
        }
    }
    [Serializable]
    public class FileName : Packets
    {
        public string fileName;

        public FileName()
        {
            this.fileName = null;
        }
    }
}
