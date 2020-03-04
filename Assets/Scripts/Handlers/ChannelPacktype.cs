using System.Text;

namespace Handlers
{
    public class ChannelPacktype
    {
        public enum Pack
        {
            Flatbuffer,
            Protobuf,
            Json
        }

        private Pack packtype;

        public ChannelPacktype(Pack packtype)
        {
            this.packtype = packtype;
        }

        public Pack GetPack()
        {
            return packtype;
        }

        public byte[] SizedBinaryRepresent()
        {
            var packname = packtype.ToString();
            var bytearray = Encoding.UTF8.GetBytes(packname);
            var resultarray = new byte[bytearray.Length + 2];
            bytearray.CopyTo(resultarray, 2);
            resultarray[0] = (byte)(resultarray.Length >> 8 & 0xFF);
            resultarray[1] = (byte)(resultarray.Length & 0xFF);
            return resultarray;
        }
    }
}