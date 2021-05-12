using System;
using WotoProvider.Interfaces;
using SAO.Constants;

namespace SAO.Security
{
#pragma warning disable IDE0032
    public sealed class StrongString : IStringProvider<StrongString>, ISessionData
    {
        //-------------------------------------------------
        #region Constants Region
        public const string ToStringValue = "-- StrongString -- || BY wotoTeam (C)";
        #endregion
        //-------------------------------------------------
        #region fields Region
        private byte[] myValue;
        private bool isDisposed;
        
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public static StrongString Empty { get => string.Empty; }
        public int Length { get => GetValue().Length; }
        public bool IsDisposed { get => isDisposed; }
        #endregion
        //-------------------------------------------------
        #region Constructors Region
        /// <summary>
        /// convert an ordianary string to the byte.
        /// please don't use crypted string.
        /// </summary>
        /// <param name="theValue"></param>
        public StrongString(string theValue)
        {
            myValue =
                ThereIsConstants.AppSettings.DECoder.TheEncoderValue.GetBytes(theValue);
        }
        /// <summary>
        /// create a new instance of a strong string by passing the 
        /// bytes of an ordinary string value.
        /// </summary>
        /// <param name="theValue">
        /// bytes of an ordinary string.
        /// NOTICE: the ordinary string means a string which is not in coded
        /// format.
        /// </param>
        public StrongString(byte[] theValue)
        {
            myValue = theValue;
        }
        public char this[int index]
        {
            get
            {
                return GetValue()[index];
            }
        }
        public StrongString this[int startIndex, int length]
        {
            get
            {
                return Substring(startIndex, length);
            }
        }
        public StrongString this[bool first]
        {
            get
            {
                if (first)
                {
                    return this[0, 1];
                }
                else
                {
                    return this[Length - 2, 1];
                }
                
            }
        }
        #endregion
        //-------------------------------------------------
        #region Ordianry Methods Region
        public void ChangeValue(string anotherValue)
        {
            myValue =
                ThereIsConstants.AppSettings.DECoder.TheEncoderValue.GetBytes(anotherValue);
        }
        public string GetValue()
        {
            return
                ThereIsConstants.AppSettings.DECoder.TheEncoderValue.GetString(myValue);
        }
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }
            myValue = null;
            isDisposed = true;
        }
        public StrongString[] Split(params string[] separator)
        {
            StrongString[] strongStrings;
            string[] myStrings =
                GetValue().Split(separator, ThereIsConstants.AppSettings.SplitOption);
            strongStrings = new StrongString[myStrings.Length];
            for (int i = 0; i < myStrings.Length; i++)
            {
                strongStrings[i] = new StrongString(myStrings[i]);
            }
            return strongStrings;
        }
        public StrongString[] Split(params StrongString[] strongStrings)
        {
            string[] myStrings = new string[strongStrings.Length];
            for (int i = 0; i < strongStrings.Length; i++)
            {
                myStrings[i] = strongStrings[i].GetValue();
            }
            return Split(myStrings);
        }
        public byte[] GetByteData()
        {
            return myValue;
        }
        public StrongString GetStrong() => this;
        public int IndexOf(string value)
        {
            return GetValue().IndexOf(value);
        }
        public bool IndexOf(params string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (IndexOf(values[i]) != -1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IndexOf(params char[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (IndexOf(values[i]) != -1)
                {
                    return true;
                }
            }
            return false;
        }
        public int[] IndexesOf(params string[] values)
        {
            int[] myInts = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                myInts[i] = IndexOf(values[i]);
            }
            return myInts;
        }
        public int IndexOf(char value)
        {
            return GetValue().IndexOf(value);
        }
        public int IndexOf(StrongString value)
        {
            return GetValue().IndexOf(value.GetValue());
        }
        public int ToInt32()
        {
            return Convert.ToInt32(GetValue());
        }
        public float ToSingle()
        {
            return Convert.ToSingle(GetValue());
        }
        public ushort ToUInt16()
        {
            return Convert.ToUInt16(GetValue());
        }
        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified
        /// character position and has a specified length.
        /// </summary>
        /// <param name="startIndex">
        /// The zero-based starting character position of a substring in this instance.
        /// </param>
        /// <param name="length">
        /// The number of characters in the substring.
        /// </param>
        /// <returns>
        /// A string that is equivalent to the substring of length length that begins at
        /// startIndex in this instance, or System.String.Empty if startIndex is equal to
        /// the length of this instance and length is zero.
        /// </returns>
        public StrongString Substring(in int startIndex, in int length)
        {
            return GetValue().Substring(startIndex, length);
        }
        public StrongString Substring(in int startIndex)
        {
            return Substring(startIndex , Length - startIndex - 1);
        }
        public StrongString Remove(in char value)
        {
            return GetValue().Replace(value.ToString(), string.Empty);
        }
        public StrongString Append(in char value)
        {
            return GetValue() + value;
        }
        public StrongString Append(in string value)
        {
            return GetValue() + value;
        }
        public StrongString Append(in string value, int count)
        {
            StrongString myString = Empty;
            for (int i = 0; i < count; i++)
            {
                myString += value;
            }
            return GetValue() + myString;
        }
        public StrongString Append(params string[] values)
        {
            string myString = string.Empty;
            for (int i = 0; i < values.Length; i++)
            {
                myString += values[i];
            }
            return GetValue() + myString;
        }
        public StrongString Append(in StrongString value)
        {
            return this + value;
        }
        public StrongString Append(in StrongString value, int count)
        {
            StrongString myString = string.Empty;
            for (int i = 0; i < count; i++)
            {
                myString += value;
            }
            return GetValue() + myString;
        }
        public StrongString Append(params StrongString[] values)
        {
            StrongString myString = Empty;
            for (int i = 0; i < values.Length; i++)
            {
                myString += values[i];
            }
            return GetValue() + myString;
        }
        public StrongString Append(in char value, int count)
        {
            return Append(value.ToString(), count);
        }
        public StrongString ToLower()
        {
            return GetValue().ToLower();
        }
        public StrongString ToUpper()
        {
            return GetValue().ToUpper();
        }
        #endregion
        //-------------------------------------------------
        #region static Methods Region
        public static implicit operator StrongString(string v)
        {
            return new StrongString(v);
        }
        #endregion
        //-------------------------------------------------
        #region overrided Methods Region
        public override string ToString()
        {
            return ToStringValue;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        //-------------------------------------------------
        #region Operator's Region
        public static StrongString operator +(StrongString left, StrongString right)
        {
            return left.GetValue() + right.GetValue();
        }
        public static StrongString operator +(StrongString left, string right)
        {
            return left.GetValue() + right;
        }
        public static StrongString operator +(string left, StrongString right)
        {
            return left + right.GetValue();
        }
        public static bool operator ==(StrongString left, StrongString right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (right is null)
                {
                    return false;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left.GetValue() == right.GetValue();
        }
        public static bool operator ==(StrongString left, string right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (right is null)
                {
                    return false;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left.GetValue() == right;
        }
        public static bool operator ==(string left, StrongString right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (right is null)
                {
                    return false;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left == right.GetValue();
        }
        public static bool operator !=(StrongString left, StrongString right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (right is null)
                {
                    return false;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left.GetValue() != right.GetValue();
        }
        public static bool operator !=(StrongString left, string right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (right is null)
                {
                    return false;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left.GetValue() != right;
        }
        public static bool operator !=(string left, StrongString right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (right is null)
                {
                    return false;
                }
                // don't return anything in this place,
                // you should check their value.
            }
            return left != right.GetValue();
        }
        #endregion
        //-------------------------------------------------
    }
#pragma warning restore IDE0032
}
