using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTU_TP1608.Utils
{
    class DataTypeConvert
    {
        /// <summary>
        /// 赋值Real类型数据
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <param name="value"></param>
        public static void SetReal(ushort[] src, int start, float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            ushort[] dest = Bytes2Ushorts(bytes);

            dest.CopyTo(src, start);
        }

        /// <summary>
        /// ushort[]=>float[]
        /// </summary>
        /// <param name="src"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static float[] GetReal(ushort[] src, int start)
        {
            /*
             * ushort->byte->float
             * ushort = 2byte
             * fload = 4byte
             * fload = 2ushort
            */
            int len = src.Length;
            //获得字节数组
            byte[] bytes = Ushorts2Bytes(src, false);
            float[] result = Bytes2Floats(bytes);
            return result;
        }
        private static ushort[] Bytes2Ushorts(byte[] src, bool reverse = false)
        {
            int len = src.Length;

            byte[] srcPlus = new byte[len + 1];
            src.CopyTo(srcPlus, 0);
            int count = len >> 1;

            if (len % 2 != 0)
            {
                count += 1;
            }

            ushort[] dest = new ushort[count];
            if (reverse)
            {
                for (int i = 0; i < count; i++)
                {
                    dest[i] = (ushort)(srcPlus[i * 2] << 8 | srcPlus[2 * i + 1] & 0xff);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    dest[i] = (ushort)(srcPlus[i * 2] & 0xff | srcPlus[2 * i + 1] << 8);
                }
            }

            return dest;
        }

        private static byte[] Ushorts2Bytes(ushort[] src, bool reverse = false)
        {

            int count = src.Length;
            byte[] dest = new byte[count << 1];//2被长度
            if (reverse)
            {
                for (int i = 0; i < count; i++)
                {  /*
                    * 这叫little-endian
                    把1010 0101 1111 1110 => [1010 0101]+[1111 1110]
                       A    B    C    D   => [ A    B  ]+[ C    D]
                    */
                    dest[i * 2] = (byte)(src[i] >> 8);
                    dest[i * 2 + 1] = (byte)(src[i] >> 0);
                }
            }
            else
            {
                /*for (int i = 0; i < count; i++)
                {
                    *//*
                     * 这是little-endian byte swap(小端字节交换：原来是little-endian，然后前8位和后8位交换)
                    把1010 0101 1111 1110 => [1111 1110]+[1010 0101]
                     A    B    C    D   => [ C    D  ]+[ A    B]
                    *//*

                    dest[i * 2] = (byte)(src[i] >> 0);
                    dest[i * 2 + 1] = (byte)(src[i] >> 8);
                }*/
                //2020.8.1 下午 big-endian D C B A
                for (int i = 0; i < count; i++)
                {
                    if (i % 2 == 0)
                    {
                        dest[i * 2 + 2] = (byte)(src[i] >> 0);
                        dest[i * 2 + 3] = (byte)(src[i] >> 8);
                    }
                    else
                    {
                        dest[i * 2 - 2] = (byte)(src[i] >> 0);
                        dest[i * 2 - 1] = (byte)(src[i] >> 8);
                    }
                }
            }
            return dest;
        }

        /// <summary>
        /// byte[]=>float[]
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private static float[] Bytes2Floats(byte[] src)
        {
            //每四个byte转为一个float
            byte[] bytesTemp = new byte[4];
            float[] result = new float[src.Length / 4];
            //4个byte为一组
            int j = 0, k=0;
            for (int i = 0; i < src.Length; i++)
            {
                if ((j + 1) % 4 != 0)
                {
                    bytesTemp[j] = src[i];
                    j++;
                }
                else
                {
                    bytesTemp[j] = src[i];
                    result[k] = BitConverter.ToSingle(bytesTemp, 0);
                    k++;
                    j = 0;
                }
            }
            return result;
        }
    }
}
