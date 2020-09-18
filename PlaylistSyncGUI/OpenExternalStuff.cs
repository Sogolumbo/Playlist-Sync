using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace PlaylistSyncGUI
{
    public static class OpenExternalStuff
    {
        public static void OpenPathInExplorer(string path)
        {
            Process.Start("explorer", path);
        }

        public static void OpenPathInKid(string path)
        {
            string kid3Path = Properties.Settings.Default.kid3_FilePath;
            Process.Start("\"" + kid3Path + "\"", "\"" + path + "\"");
        }
        public static void OpenFileInNotepad(string path)
        {
            string notepadPath = Properties.Settings.Default.notepadPlusPlus_FilePath;
            Process.Start("\"" + notepadPath + "\"", "\"" + path + "\"");
        }

        public static Process OpenPathWithStandardApplication(string path)
        {
            return RunCommand("start \"\" \"" + path + "\"");
        }
        public static Process RunCommand(string command)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("chcp " + Encoding.Default.CodePage); //z.B. Deutsche codepage für Umlaute usw.
            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            return cmd;
        }
    }
}