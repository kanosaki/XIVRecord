using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace XIVRecord
{
    public class ArchiveDir
    {
        /// <summary>
        /// ShadowPlay stores record directory in this key with UTF-16
        /// </summary>
        const string DEFAULT_REG_SUBKEY =
            @"Software\NVIDIA Corporation\Global\ShadowPlay\NVSPCAPS";
        const string DEFAULT_REG_NAME = "DefaultPathW"; // REG_BINARY
        static readonly int UNICODE_NULLCHAR_SIZE = Encoding.Unicode.GetByteCount("\0");
        static readonly Regex FOLLOWING_FILE_PATTERN = new Regex(@"_[0-9]+\.mp4", RegexOptions.Compiled);

        public DirectoryInfo Dir { get; private set; }

        public ArchiveDir(DirectoryInfo dir)
        {
            this.Dir = dir;
        }

        public IEnumerable<Record> EnumerateRecords()
        {
            return this.Dir.EnumerateFiles("*.mp4")
                .Where(fi => !FOLLOWING_FILE_PATTERN.IsMatch(fi.Name))
                .Select(fi => new Record(fi));
        }

        /// <summary>
        /// Trying to read ShadowPlay record directory location from registry and returns ArchiveDir.
        /// If failed, returns null.
        /// </summary>
        /// <returns>ArchiveDir or null</returns>
        public static ArchiveDir TryReadFromRegistry()
        {
            try
            {
                var regKey = Registry.CurrentUser.OpenSubKey(DEFAULT_REG_SUBKEY);
                var regValue = (byte[])regKey.GetValue("DefaultPathW");
                // remove a null char
                var recdir = Encoding.Unicode.GetString(regValue.SubArray(0, regValue.Length - UNICODE_NULLCHAR_SIZE));
                var path = Path.Combine(recdir, "Desktop");
                var dir = new DirectoryInfo(path);
                return new ArchiveDir(dir);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}
