using System;
using System.Collections.Generic;
using System.Text;

namespace PermitirConversaoAtravesDeIConvertible
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Bit bit = new Bit(true);
                SByte bitConverted = Convert.ToSByte(bit);
                Console.WriteLine(bitConverted);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }



    struct Bit : IConvertible
    {
        public bool isTrue;

        public Bit(bool isTrue)
        {
            this.isTrue = isTrue;
        }

        #region IConvertible Members

        TypeCode IConvertible.GetTypeCode()
        {
            //Quando conversao nao for permitida usar InvalidCastException

            throw new InvalidCastException("The method or operation is not implemented.");
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            if (this.isTrue)
                return 1;
            else
                return 0;
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
