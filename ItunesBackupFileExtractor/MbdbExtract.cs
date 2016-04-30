#define DEBUG

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ItunesBackupFileExtractor
{
    public class MbdbExtract
    {
        public struct MBDBFile
        {
            public string Domain;
            public string FilePath;
            public string EncryptedFilename;
        }

        /// <summary>
        /// Get the file list from the mbdb file
        /// </summary>
        /// <param name="BackupPath"></param>
        /// <returns></returns>
        public static List<MBDBFile> ReadMBDB(string iTunesBackupFolder)
        {
            List<MBDBFile> mbdbFiles = new List<MBDBFile>();
            SHA1CryptoServiceProvider sha1Crypt = new SHA1CryptoServiceProvider();
            FileStream fs = new FileStream(iTunesBackupFolder+"Manifest.mbdb", FileMode.Open, FileAccess.Read);

            byte[] MbdbBuffer = GetBuffer(fs, 6);
            
            //Check first bytes of mbdb file
            if (GetHexStringByByteArray(MbdbBuffer) != "6d6264620500")
            {
                return null;
            }
            else
            {
                for (int i = 0; fs.Position < fs.Length; ++i)
                {
                    //Getting the domain and filepath
                    MBDBFile MbdbFile = new MBDBFile()
                    {
                        Domain = GetNextBufferString(fs),
                        FilePath = GetNextBufferString(fs)
                    }; 

                    //Encrypting domain and filepath to get the right filename
                    byte[] sha1Buffer = sha1Crypt.ComputeHash(ASCIIEncoding.UTF8.GetBytes(string.Format("{0}-{1}", MbdbFile.Domain, MbdbFile.FilePath)));
                    MbdbFile.EncryptedFilename = GetHexStringByByteArray(sha1Buffer);

#if DEBUG
                    if (MbdbFile.Domain.StartsWith("com.apple.TextEncoding") || MbdbFile.Domain.StartsWith("com.apple.assetsd"))
                    {
                        //Do we need to do anything here??
                    }
                    else
                    {
#endif
                        //Add MbdbFile to list
                        mbdbFiles.Add(MbdbFile);

                        //Ignoring the rest
                        NextFile(fs);
#if DEBUG
                    }
#endif
                }

                return mbdbFiles;
            }
        }

        /// <summary>
        /// Concat a byte array in a string
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string GetHexStringByByteArray(byte[] buffer)
        {
            string HexString = string.Empty;
            foreach (byte b in buffer)
            {
                HexString += b.ToString("x2");
            }
            return HexString;
        }

        /// <summary>
        /// Jump to the next file
        /// </summary>
        /// <param name="stm"></param>
        private static void NextFile(Stream stm)
        {
            for (int i = 0; i  < 3; ++i)
            {
                GetNextBuffer(stm);
            }
            GetBuffer(stm, 40);
        }

        /// <summary>
        /// Get length from the stream
        /// </summary>
        /// <param name="fs"></param>
        /// <returns></returns>
        private static int GetLength(Stream stm)
        {
            int firstByte = stm.ReadByte();
            int secByte = stm.ReadByte();

            if (firstByte == 255 && secByte == 255)
                return 0;

            int length = firstByte * 256 + secByte;
            return length;
        }

        /// <summary>
        /// Get the next buffer as a byte array
        /// </summary>
        /// <param name="stm"></param>
        /// <returns></returns>
        private static byte[] GetNextBuffer(Stream stm)
        {
            int l = GetLength(stm);
            byte[] buffer = new byte[l];
            stm.Read(buffer, 0, l);
            return buffer;
        }

        /// <summary>
        /// Get the buffer from the stream as a byte array
        /// </summary>
        /// <param name="stm"></param>
        /// <returns></returns>
        private static byte[] GetBuffer(Stream stm,int l)
        {
            byte[] buffer = new byte[l];
            stm.Read(buffer, 0, l);
            return buffer;
        }

        /// <summary>
        /// Get the next buffer as a string
        /// </summary>
        /// <param name="stm"></param>
        /// <returns></returns>
        private static string GetNextBufferString(Stream stm)
        {
            byte[] buf = GetNextBuffer(stm);
            string s = Encoding.UTF8.GetString(buf);
            return s.Normalize(NormalizationForm.FormC);
        }
    }
}
