using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItunesBackupFileExtractor
{
    public static class Constants
    {
        public const string ManifestFile = "Manifest.mbdb";
        public const string MbdbFirstBytes = "6d6264620500";
        public const string ExtensionTypeSection = "ExtensionTypeList";
        public const string AllCheckbox = "All";

        public const string BckpUnselected = "Please select the iTunes backup folder and the output folder.";
        public const string DirectoryEmpty = "Nothing found in your iTunes backup folder. Select the right folder and try again.";
        public const string CheckboxUnselected = "Please select a checkbox.";
        public const string ErrorTitle = "Error";
        public const string DoneTitle = "Done";
        public const string DoneMessage = "Backup extract done !";
        public const string CanceledTitle = "Canceled";
        public const string CanceledMessage = "Backup extract canceled !";
        public const string BadConfigFile = "Bad file format. Check your config file and try again.";
        public const string BadMbdbFile = "Bad MBDB file.";
    }
}
