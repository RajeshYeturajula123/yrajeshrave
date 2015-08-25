using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

//namespace Inspec.Mercury.Workflow.Common.Components
namespace Inspec.Common
{
    /// <remarks />
    public static class SerializationUtils
    {
        /// <summary>
        /// Write data to a UTF8 encoded strean
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static MemoryStream WriteToStream(string data)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] array = enc.GetBytes(data);
            MemoryStream stream = new MemoryStream();
            stream.Write(array, 0, array.Length);
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Write data to a UTF16 encoded stream
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static MemoryStream WriteToUnicodeStream(string data)
        {
            UnicodeEncoding enc = new UnicodeEncoding();
            byte[] array = enc.GetBytes(data);
            MemoryStream stream = new MemoryStream();
            stream.Write(array, 0, array.Length);
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Convert a stream to a string
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public static string ReadFromStream(MemoryStream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                // Just read to the end.
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Deserialize an object that is currently encoded in a string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static T DeserializeObject<T>(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(WriteToStream(data));
        }

        /// <summary>
        /// Deserialize an object that is currently encoded in a stream
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static T DeserializeObject<T>(Stream data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(data);
        }

        /// <summary>
        /// Deserialize an object that is currently encoded in an XmlDocument
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlSaveBundle"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static T DeserializeObject<T>(XmlDocument xmlSaveBundle)
        {
            using (System.IO.StringReader reader = new System.IO.StringReader(xmlSaveBundle.OuterXml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Serialize an object to a memory stream
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static MemoryStream SerializeObject<T>(T item)
        {
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            System.Xml.Serialization.XmlSerializer xmlSerializer =
                                       new System.Xml.Serialization.XmlSerializer(typeof(T));

            System.Xml.XmlTextWriter xmlTextWriter = new System.Xml.XmlTextWriter(memoryStream, Encoding.Unicode);
            xmlSerializer.Serialize(xmlTextWriter, item);

            return (System.IO.MemoryStream)xmlTextWriter.BaseStream;
        }

        /// <summary>
        /// Serialize an object to a string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string SerializeObjectToString<T>(T item)
        {
            MemoryStream stream = SerializeObject<T>(item);
            stream.Position = 0;
            return ReadFromStream(stream);
        }

        /// <summary>
        /// Make a copy of an object using serialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static T Copy<T>(T item)
        {
            MemoryStream stream = SerializeObject<T>(item);
            stream.Position = 0;
            return (T)DeserializeObject<T>(stream);
        }
    }
}
