using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspec.Common
{
    public class DataReaderHelper
    {
        #region Constructor

        /// <CommentsBlock>
        /// <MethodName>SampleEntity</MethodName>      
        /// <Description>
        /// Default Constructor
        /// </Description>
        /// </CommentsBlock>
        public DataReaderHelper()
        {

        }

        #endregion Constructor

        #region Static Methods

        /// <CommentsBlock>
        /// <MethodName>GetString</MethodName>
        /// <Parameters>
        /// <Parameter type="object" name="data"></Parameter>        
        /// </Parameters>
        /// <returns>String</returns> 
        /// <Description>
        /// If the data is Equal to DBNull.Value, returns Null.
        /// If data is not equal to DBNull, returns string.
        /// </Description>
        /// </CommentsBlock>
        public static string GetString(object data)
        {
            //Result variable initialised to null by default
            string result = null;

            //if data is not equal to DBNull.Value then it is Converted to string
            if (data != DBNull.Value)
            {
                result = Convert.ToString(data);
            }

            //Return result
            return result;
        }

        /// <CommentsBlock>
        /// <MethodName>GetInt</MethodName>
        /// <Parameters>
        /// <Parameter type="object" name="data"></Parameter>        
        /// </Parameters>
        /// <returns>int</returns> 
        /// <Description>
        /// If the data is Equal to DBNull.Value returns zero.
        /// If data is not equal to DBNull then Converts it to int and returns.
        /// </Description>
        /// </CommentsBlock>
        public static int GetInt(object data)
        {
            //Declare and initilize the result variable to hold zero as default value
            int result = 0;

            //Check if data is equal to DBNull.Value and convert it to int32
            if (data != DBNull.Value)
            {
                result = Convert.ToInt32(data);
            }

            //Return result
            return result;
        }

        /// <CommentsBlock>
        /// <MethodName>GetInt64</MethodName>
        /// <Parameters>
        /// <Parameter type="object" name="data"></Parameter>        
        /// </Parameters>
        /// <returns>int</returns> 
        /// <Description>
        /// If the data is Equal to DBNull.Value returns zero.
        /// If data is not equal to DBNull then Converts it to int and returns.
        /// </Description>
        /// </CommentsBlock>
        public static Int64 GetInt64(object data)
        {
            //Declare and initilize the result variable to hold zero as default value
            Int64 result = 0;

            //Check if data is equal to DBNull.Value and convert it to int32
            if (data != DBNull.Value)
            {
                result = Convert.ToInt64(data);
            }

            //Return result
            return result;
        }

        /// <CommentsBlock>
        /// <MethodName>GetBool</MethodName>
        /// <Parameters>
        /// <Parameter type="object" name="data"></Parameter>        
        /// </Parameters>
        /// <returns>bool</returns> 
        /// <Description>
        /// If the data is Equal to DBNull.Value, returns false.
        /// If data is not equal to DBNull, then Converts it to boolean and returns.
        /// </Description>
        /// </CommentsBlock>
        public static bool GetBool(object data)
        {
            //Declare variable to hold value for result and initialize it to false by default
            bool result = false;

            //Check if the data is not equal to DBNull.value and Convert it to boolean
            if (data != DBNull.Value)
            {
                if (Convert.ToBoolean(data))
                {
                    result = true;
                }
            }

            //Return result
            return result;
        }

        /// <CommentsBlock>
        /// <MethodName>GetDateTime</MethodName>
        /// <Parameters>
        /// <Parameter type="object" name="data"></Parameter>        
        /// </Parameters>
        /// <returns>DateTime</returns> 
        /// <Description>
        /// If the data is Equal to DBNull.Value, returns MinValue.
        /// If data is not equal to DBNull, then Converts it to DateTime and returns.
        /// </Description>
        /// </CommentsBlock>
        public static DateTime GetDateTime(object data)
        {
            //Declare variable to hold the value for result and initialize it with minValue
            DateTime result = DateTime.MinValue;

            //Checks if data is not equal to DBNull.Value and Converts it to DateTime
            if (data != DBNull.Value)
            {
                result = Convert.ToDateTime(data);
            }

            //Return result
            return result;
        }

        /// <CommentsBlock>
        /// <MethodName>GetDecimal</MethodName>
        /// <Parameters>
        /// <Parameter type="object" name="data"></Parameter>        
        /// </Parameters>
        /// <returns>decimal</returns> 
        /// <Description>
        /// If the data is Equal to DBNull.Value, returns zero.
        /// If data is not equal to DBNull, then Converts it to Decimal and returns.
        /// </Description>
        /// </CommentsBlock>
        public static decimal GetDecimal(object data)
        {
            //Declare variable to hold the value of the result and initialize it to zero by default
            decimal result = 0;

            //Checks if the data is not equal to DBNull.value and Converts to Decimal and returns it
            if (data != DBNull.Value)
            {
                result = Convert.ToDecimal(data);
            }

            //Return result
            return result;
        }

        /// <CommentsBlock>
        /// <MethodName>GetDouble</MethodName>
        /// <Parameters>
        /// <Parameter type="object" name="data"></Parameter>        
        /// </Parameters>
        /// <returns>Double</returns> 
        /// <Description>
        /// If the data is Equal to DBNull.Value, returns zero.
        /// If data is not equal to DBNull, then Converts it to Double and returns.
        /// </Description>
        /// </CommentsBlock>
        public static Double GetDouble(object data)
        {
            //Declare variable to hold the value of result and intialize it to zero by default
            Double result = 0;

            //Check if value is not equal to DBNull.value and then Converts it to Double and returns
            if (data != DBNull.Value)
            {
                result = Convert.ToDouble(data);
            }

            //Returns result
            return result;
        }

        /// <CommentsBlock>
        /// <MethodName>GetLong</MethodName>
        /// <Parameters>
        /// <Parameter type="object" name="data"></Parameter>        
        /// </Parameters>
        /// <returns>long</returns> 
        /// <Description>
        /// If the data is Equal to DBNull.Value, returns zero.
        /// If data is not equal to DBNull, then Converts it to long and returns.
        /// </Description>
        /// </CommentsBlock>
        public static long GetLong(object data)
        {
            //Declare variable to hold the value of result and intialize it to zero by default
            long result = 0;

            //Check if value is not equal to DBNull.value and then Converts it to Long and returns
            if (data != DBNull.Value)
            {
                result = Convert.ToInt64(data);
            }

            //Returns result
            return result;
        }

        /// <CommentsBlock>
        /// <MethodName>GetShort</MethodName>
        /// <Parameters>
        /// <Parameter type="object" name="data"></Parameter>        
        /// </Parameters>
        /// <returns>short</returns>
        /// <Description>
        /// If the data is Equal to DBNull.Value, returns zero.
        /// If data is not equal to DBNull then Converts it to short and returns.
        /// </Description>
        /// </CommentsBlock>
        public static short GetShort(object data)
        {
            //Declare and initilize the result variable to hold zero as default value
            short result = 0;

            //Check if data is equal to DBNull.Value and convert it to short/int16
            if (data != DBNull.Value)
            {
                result = Convert.ToInt16(data);
            }

            //Return result
            return result;
        }

        /// <CommentsBlock>
        /// <MethodName>GetByte</MethodName>
        /// <Parameters>
        /// <Parameter type="object" name="data"></Parameter>        
        /// </Parameters>
        /// <returns>Byte</returns>
        /// <Description>
        /// If the data is Equal to DBNull.Value, returns zero.
        /// If data is not equal to DBNull then Converts it to byte and returns.
        /// </Description>
        /// </CommentsBlock>
        public static Byte GetByte(object data)
        {
            //Declare and initilize the result variable to hold zero as default value
            Byte result = 0;

            //Check if data is equal to DBNull.Value and convert it to short/int16
            if (data != DBNull.Value)
            {
                result = Convert.ToByte(data);
            }

            //Return result
            return result;
        }

        /// <summary>
        /// Gets the byte array.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static Byte[] GetByteArray(object data)
        {
            //Declare and initilize the result variable to hold zero as default value
            Byte[] result = null;

            //Check if data is equal to DBNull.Value and convert it to short/int16
            if (data != DBNull.Value)
            {
                result = (byte[])data;
            }

            //Return result
            return result;
        }

        /// <CommentsBlock>
        /// <MethodName>GetChar</MethodName>
        /// <Parameters>
        /// <Parameter type="object" name="data"></Parameter>        
        /// </Parameters>
        /// <returns>Char</returns>
        /// <Description>
        /// If the data is Equal to DBNull.Value, returns zero.
        /// If data is not equal to DBNull then Converts it to Char and returns.
        /// </Description>
        /// </CommentsBlock>
        public static Char GetChar(object data)
        {
            //Result variable initialised to '0' by default
            Char result = '0';

            //if data is not equal to DBNull.Value then it is Converted to string
            if (data != DBNull.Value)
            {
                result = Convert.ToChar(data.ToString().Trim());
            }

            //Return result
            return result;
        }

        #endregion Static Methods
    }
}
