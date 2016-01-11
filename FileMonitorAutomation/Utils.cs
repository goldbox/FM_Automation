// <copyright file="Utils.cs" author="Simona Trifan" company="Temasoft">
// Copyright @ Temasoft 2014
// </copyright>

namespace FileMonitorAutomation
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Management;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO.Compression;

    /// <summary>
    /// Useful methods to use in File Monitor automation
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Method that creates a directory in the specified path
        /// </summary>
        /// <param name="folderPath">The directory path.</param>
        public static void CreateDirectory(string folderPath)
        {
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(folderPath))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(folderPath);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(folderPath));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
         
        /// <summary>
        /// Method that creates a shared directory in the specified path
        /// </summary>
        /// <param name="path">The directory path.</param>
        public static void CreateSharedDirectory(string folderName)
        {
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(folderName))
                {
                    // Console.WriteLine("That path exists already.");
                    ProcessStartInfo info = new ProcessStartInfo("net", "share MyNewShare=" + folderName);
                    info.CreateNoWindow = true;
                    Process.Start(info);
                    return;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public static void QshareFolder(string FolderPath, string ShareName, string Description)
        {
            try
            {
                // Create a ManagementClass object
                ManagementClass managementClass = new ManagementClass("Win32_Share");

                // Create ManagementBaseObjects for in and out parameters
                ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");

                ManagementBaseObject outParams;

                // Set the input parameters
                inParams["Description"] = Description;

                inParams["Name"] = ShareName;

                inParams["Path"] = FolderPath;

                inParams["Type"] = 0x0; // Disk Drive

                

                outParams = managementClass.InvokeMethod("Create", inParams, null);

                // Check to see if the method invocation was successful

                if ((uint)(outParams.Properties["ReturnValue"].Value) != 0)
                {

                    throw new Exception("Unable to share directory.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Method that creates a file in the specified path
        /// </summary>
        /// <param name="filePath">The file location.</param>
        public static void CreateSingleFile(string filePath)
        {
            FileStream fs = null;

            if (!File.Exists(filePath))
            {
                using (fs = File.Create(filePath))
                {
                    Console.WriteLine("File {0} created successfully",filePath);
                }
            }
            else
            {
                Console.WriteLine("File {0} exists", filePath);
            }
        }

        /// <summary>
        /// Method that sets archive attribute
        /// </summary>
        /// <param name="fileLoc">The file location.</param>
        public static void SetArchive(string fileLoc)
        {
            File.SetAttributes(fileLoc, FileAttributes.Archive);
        }

        /// <summary>
        /// Method that sets read only attribute
        /// </summary>
        /// <param name="fileLoc">The file location.</param>
        public static void SetReadOnlyFile(string fileLoc)
        {
            File.SetAttributes(fileLoc, FileAttributes.ReadOnly);
        }

        /// <summary>
        /// Method that sets hidden attribute
        /// </summary>
        /// <param name="fileLoc">The file location.</param>
        public static void SetHiddenFile(string fileLoc)
        {
            File.SetAttributes(fileLoc, FileAttributes.Hidden);
        } 

        /// <summary>
        /// Method that removes archive attribute
        /// </summary>
        /// <param name="fileLoc">The file location.</param>
        public static void RemoveArchive(string fileLoc)
        {
            File.SetAttributes(fileLoc, File.GetAttributes(fileLoc) & ~FileAttributes.Archive);
        } 

        /// <summary>
        /// Method that removes hidden attribute
        /// </summary>
        /// <param name="fileLoc">The file location.</param>
        public static void RemoveHiddenAttributes(string fileLoc)
        {
            File.SetAttributes(fileLoc, File.GetAttributes(fileLoc) & ~FileAttributes.Hidden);
        }

        /// <summary>
        /// Method that removes read only attributes
        /// </summary>
        /// <param name="fileLoc">The file location.</param>
        public static void RemoveReadOnlyAttributes(string fileLoc)
        {
            File.SetAttributes(fileLoc, File.GetAttributes(fileLoc) & ~FileAttributes.ReadOnly);
        } 

        /// <summary>
        /// Method that creates a file in the specified path
        /// </summary>
        /// <param name="fileLoc">The file location.</param>
        public static void RemoveAll(string fileLoc)
        {
            File.SetAttributes(fileLoc, File.GetAttributes(fileLoc) & ~FileAttributes.ReadOnly);
        }

        /// <summary>
        /// Method that writes in a specified file
        /// </summary>
        /// <param name="fileLoc">The file location.</param>
        public static void WriteSingleFile(string fileLoc)
        {
            if (File.Exists(fileLoc))
            {
                using (StreamWriter sw = new StreamWriter(fileLoc))
                {
                    sw.Write("Some sample text for the file");
                }
            }
        }

        /// <summary>
        /// Method that reads from a specified file
        /// </summary>
        /// <param name="fileLoc">The file location.</param>
        public static void ReadSingleFile(string fileLoc)
        {
            if (File.Exists(fileLoc))
            {
                using (TextReader tr = new StreamReader(fileLoc))
                {
                    string line = tr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// Method that opens file in the specified browser
        /// </summary>
        /// <param name="fileLoc">The file location.</param>
        /// <param name="process">The process name.</param>
        public static void OpenFileInBrowser(string fileLoc, string process)
        {
            System.Diagnostics.Process.Start(process, "\"" + fileLoc);
        }

        /// <summary>
        /// Method that copies a file from a specified source to a specified destination
        /// </summary>
        /// <param name="fileLoc">The file location source.</param>
        /// <param name="fileCopyDestination">The file location destination.</param>
        public static void CopySingleFile(string fileLoc, string fileCopyDestination)
        {
            if (File.Exists(fileLoc))
            {
                // If file already exists in destination, delete it.
                if (File.Exists(fileCopyDestination))
                {
                    File.Delete(fileCopyDestination);
                }

                File.Copy(fileLoc, fileCopyDestination);
            }
        }

        /// <summary>
        /// Method that deletes a specified file
        /// </summary>
        /// <param name="fileLoc">The file location source.</param>
        public static void DeleteSingleFile(string fileLoc)
        {
            if (File.Exists(fileLoc))
            {
                File.Delete(fileLoc);
            }
        }

        /// <summary>
        /// Method that renames a specified file
        /// </summary>
        /// <param name="fileLoc">The file location source.</param>
        /// <param name="fileDest">The file location destination.</param>
        public static void RenameSingleFile(string fileLoc, string fileDest)
        {
            if (File.Exists(fileLoc))
            {
                // If file already exists in destination, delete it.
                if (File.Exists(fileDest))
                {
                    File.Delete(fileDest);
                }

                File.Move(fileLoc, fileDest);
            }
        }

        /// <summary>
        /// Change file extension
        /// </summary>
        /// <param name="fileLoc">The file location source.</param>
        /// <param name="newextension">The new extension.</param>
        public static void ChangeFileExtension(string fileLoc, string newextension)
        {
            if (File.Exists(fileLoc))
            {
                string extension = Path.GetExtension(fileLoc);
                fileLoc.Replace(extension, ".Jpeg");
                FileInfo f = new FileInfo(fileLoc);
                f.MoveTo(Path.ChangeExtension(fileLoc, newextension));
            }
           
        }

        /// <summary>
        /// Method that creates a file with a specified lenght
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <param name="sizeInMB">File dimension.</param>
        public static void CreateFileWithSpecifiedLenght(string fileName, double sizeInMB)
        {
            //var sizeInMB = 3; // Up to many Gb
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    while (writer.BaseStream.Length <= sizeInMB * 1000000)
                    {
                        writer.Write("a"); //This could be random. Also, larger strings improve performance obviously
                    }

                    writer.Close();
                }
            }
        } 

        /// <summary>
        /// Method that creates multiple files with diff name
        /// </summary>
        /// <param name="path">The file location.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="numberbOfFiles">The file location destination.</param>
        public static void CreateMultipleFileswithDiffName(string path, string fileName, int numberbOfFiles)
        {
            // string path = @"C:\test\";
            if (Directory.Exists(path))
            {
                for (int i = 1; i < numberbOfFiles; i++)
                {
                    string filePath = path + fileName + i + ".txt";

                    // Create a file to write to. 
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.WriteLine("Hello");
                        sw.WriteLine("And");
                        sw.WriteLine("Welcome");
                    }
                }
            }
        }

        /// <summary>
        /// Search name and operations matches the input values
        /// </summary>
        /// <param name="cSVPath">csv Path</param>
        /// <param name="searchFileName">The file name of the file.</param>
        /// <param name="searchOperation">Operation type.</param>
        /// <param name="numberOfSearchedMatches">Number of matches.</param>
        public static bool GetFileNameandOperation(string cSVPath, string searchFileName, string searchOperation, int numberOfSearchedMatches, DateTime startAutomatedTestsTimestamp)
        {
            char cSVSeparator = ',';
            int numberOfActualMatches = 0;
            foreach (string line in File.ReadLines(cSVPath))
            {
                bool fileNameMatched = false;
                bool operationMatched = false;
                string[] modifiedLine = line.Replace("\"", string.Empty).Split('\r', '\n', cSVSeparator);

                //check if TimeStamp is Older Than Start Of Automated Tests
                if (IsThisAnOlderEvent(modifiedLine, startAutomatedTestsTimestamp))
                {
                    continue;
                }

                foreach (string value in modifiedLine)
                {
                    if (!operationMatched && value.Trim().Equals(searchOperation, StringComparison.InvariantCultureIgnoreCase))
                    {
                        operationMatched = true;
                    }
                    else if (!fileNameMatched && value.Trim().Equals(searchFileName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        fileNameMatched = true;
                    }

                    if (fileNameMatched && operationMatched)
                    {
                        numberOfActualMatches++;
                        break;
                    }
                }
            }

            if (numberOfActualMatches > 0 && numberOfActualMatches == numberOfSearchedMatches)
            {
                // Console.WriteLine("Matched: [ {0} ] ", numberOfMatches);
                Console.WriteLine("Number of matches wanted: [ {0} ] , number of matches found [ {1} ]", numberOfSearchedMatches, numberOfActualMatches);
                return true;
            }

            Console.WriteLine("Number of matches wanted: [ {0} ] , number of matches found [ {1} ]", numberOfSearchedMatches, numberOfActualMatches);
            return false;
        }

        public static bool IsThisAnOlderEvent(string[] line, DateTime startAutomatedTestsTimestamp)
        {
            var ci = System.Globalization.CultureInfo.GetCultureInfo("en-us");
            try
            {
                var currentTimestamp = DateTime.Parse(line[1], ci);
                int result = DateTime.Compare(currentTimestamp, startAutomatedTestsTimestamp);
                if (result < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return true;
            }
        }

        /// <summary>
        /// Method that creates multiple files with diff name
        /// </summary>
        /// <param name="searchFileName">The file name of the file.</param>
        /// <returns>Returns the status object.</returns>
        public static bool GetFileName(string searchFileName)
        {
            string date = DateTime.Now.ToString("yyyyMMdd");
            string csvFile = @"C:\ProgramData\temasoft\filemonitor\storage\csv_logs\log-" + date + ".csv";

            char csvSeparator = ',';
            foreach (string line in File.ReadLines(csvFile))
            {
                bool fileNameMatched = false;

                // bool operationMatched = false;
                string[] modifiedLine = line.Replace("\"", string.Empty).Split('\r', '\n', csvSeparator);
                foreach (string value in modifiedLine)
                {
                    if (!fileNameMatched && value.Trim().Equals(searchFileName, StringComparison.CurrentCulture))
                    {
                        fileNameMatched = true;
                        Console.WriteLine("Matched [ {0} ] found in: {1}", value, line);
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Adds an ACL entry on the specified file for the specified account.
        /// </summary>
        /// <param name="fileName">The file name of the file.</param>
        /// <param name="account">Account name.</param>
        /// <param name="rights">Rights.</param>
        /// <param name="controlType">Control type.</param>
        public static void AddFileSecurity(string fileName, string account, FileSystemRights rights, AccessControlType controlType)
        {
            // Get a FileSecurity object that represents the
            // current security settings.
            FileSecurity fileSecurity = File.GetAccessControl(fileName);

            // Add the FileSystemAccessRule to the security settings.
            fileSecurity.AddAccessRule(new FileSystemAccessRule(account, rights, controlType));

            // Set the new access settings.
            File.SetAccessControl(fileName, fileSecurity);
        }

        /// <summary>
        /// Removes an ACL entry on the specified file for the specified account.
        /// </summary>
        /// <param name="fileName">The file name of the file.</param>
        /// <param name="account">Account name.</param>
        /// <param name="rights">Rights.</param>
        /// <param name="controlType">Control type.</param>
        public static void RemoveFileSecurity(string fileName, string account, FileSystemRights rights, AccessControlType controlType)
        {
            // Get a FileSecurity object that represents the
            // current security settings.
            FileSecurity fileSecurity = File.GetAccessControl(fileName);

            // Remove the FileSystemAccessRule from the security settings.
            fileSecurity.RemoveAccessRule(new FileSystemAccessRule(account, rights, controlType));

            // Set the new access settings.
            File.SetAccessControl(fileName, fileSecurity);
        }

        public static void AddCSVColumns(List<string> headers, Dictionary<int, List<string>> lines)
        {
            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var currentTime = DateTime.Now.ToString("yyyyMMddHHmm");
            string resultsFilePath = pathDesktop + "\\results" + currentTime + ".csv";
            
            if (!File.Exists(resultsFilePath))
            {
                File.Create(resultsFilePath).Close();
            } 

           string delimiter = ",";
           using (TextWriter writer = File.CreateText(resultsFilePath))
           {
               writer.WriteLine(string.Join(delimiter, headers));
               foreach (var line in lines.Values)
               {
                   writer.WriteLine(string.Join(delimiter, line));
               }
           }
           // Dictionary<int, List<string>> toWrite = new Dictionary<int, List<string>>();
           // int maxWords = 0;
           // foreach (var line in lines.Values)
           // {
           //     if (line.Count > maxWords)
           //     {
           //         maxWords = line.Count;
           //     }
           // }
           // for (int i = 0; i < maxWords; i++)
           // {
           //     toWrite.Add(i, new List<string>(headers.Count));
           // }

           // for (int i = 0; i < maxWords; i++)
           // {
           //     foreach (var line in lines)
           //     {
           //         if (line.Value.Count <= i)
           //         {
           //                 toWrite[i].Add(" ");  
           //         }
           //         else
           //         {
           //             toWrite[i].Add(line.Value[i]);
           //         }
           //     }
           // }
            
           //List<List<string>> output = new List<List<string>>();
           //output.Add(new List<string> { headers[0], headers[1], headers[2], headers[3], headers[4] });

           // int length = output.Count();

           // using (System.IO.TextWriter writer = File.CreateText(filePath))
           // {
           //     for (int index = 0; index < length; index++)
           //     {
           //         writer.WriteLine(string.Join(delimter, output[index]));
           //     }

           //     foreach (var tw in toWrite)
           //     {
           //         string line = string.Empty;
           //         foreach (var item in tw.Value)
           //         {
           //             line += item + delimter;
           //             writer.WriteLine(line);
           //         }
           //     }
           // }
        }

       


    }
}
