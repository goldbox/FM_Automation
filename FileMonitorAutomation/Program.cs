// <copyright file="Program.cs" author="Simona Trifan" company="Temasoft">
// Copyright @ Temasoft 2014
// </copyright>

namespace FileMonitorAutomation
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.Devices;
    using System.Web;
    using System.IO.Compression;
   
     
    public class Program
    {
        /// file operations
        /// <param name="args">Method args.</param>
        public static void Main(string[] args)
        {
            var startAutomatedTestsTimestamp = DateTime.UtcNow;

            // Input Data
            Console.WriteLine("Enter the letter for NTFS partition: ");
            string partitionNTFS = Console.ReadLine();
            Console.WriteLine("Enter the letter for FAT32 partition: ");
            string partitionFAT32 = Console.ReadLine();
            string currentlyLoggedUser = Environment.UserName + "." + Environment.UserDomainName;
            string date = DateTime.Now.ToString("yyyyMMdd");
            string filePathRootC = @"c:\testFile.txt";
            string fileRootNTFSPartition = partitionNTFS + @":\testFile.txt";
            string fileLocFAT23Partition = partitionFAT32 + @":\testFile.txt";
            string fileLocFolder1C = @"c:\Monitoring\testFile.txt";
            string fileNTFSPartitionFolder1 = partitionNTFS + @":\Monitoring\testFile.txt";
            string fileFAT32PartitionFolder1 = partitionFAT32 + @":\Monitoring\testFile.txt";
            string fileCopyDestination = @"c:\CopyFolder\testFile.txt";
            string strangeName = @"c:\Monitoring\--!079;d@b73c#'b9.47$55%d3fe^^59fe&&930()6f+=d2546.txt";
            string longName = @"c:\Monitoring\Gsdffffffffgfds4q235refcc3vc33ttttttttttttttttttttttfsdfashgjhgjhgjgfbsxcxsdwetryt6hytjuykyujjjjjjjjjjjjjjmhnfdsfdsgffgh45y67u7jhjhgfaffsdtetyhrtdutyjkyukjhgadfwgtgeregfjhefwgerdstgeyhfhjngjfdshbfgjhg.txt";
            string csvPathOldPath = @"C:\ProgramData\temasoft\filemonitor\storage\csv_logs\log-" + date + ".csv";
            string csvPath = @"c:\log-" + date + ".csv";
            string renameFileLocRootC = @"c:\renametestFile.txt";
            string renameFileRootNTFSPartition = partitionNTFS + @":\renametestFile.txt";
            string renameFileRootFAT32Partition = partitionFAT32 + @":\renametestFile.txt";
            string renameFileLocFolder1C = @"c:\Monitoring\renametestFile.txt";
            string renameFileNTFSPartitionFolder1 = partitionNTFS + @":\Monitoring\renametestFile.txt";
            string renameFileFAT32PartitionFolder1 = partitionFAT32 + @":\Monitoring\renametestFile.txt";
            string filesettings = @"c:\settings.txt";
            List<string> multipleFiles = new List<string>() { @"c:\Monitoring\multiple1.txt", @"c:\Monitoring\multiple2.txt", @"c:\Monitoring\multiple3.txt", @"c:\Monitoring\multiple4.txt", @"c:\Monitoring\multiple5.txt" };
            List<string> renamemultipleFiles = new List<string>() { @"c:\Monitoring\renamemultiple1.txt", @"c:\Monitoring\renamemultiple2.txt", @"c:\Monitoring\renamemultiple3.txt", @"c:\Monitoring\renamemultiple4.txt", @"c:\Monitoring\renamemultiple5.txt" };
            List<string> renameofficeFiles = new List<string>() { partitionNTFS + @":\renamewordFile.doc", partitionNTFS + @":\renamedocFile.doc", partitionNTFS + @":\renamedocxFile.docx", partitionNTFS + @":\renamexlsFile.xls", partitionNTFS + @":\renamexlsxFile.xlsx", partitionNTFS + @":\renamepptFile.ppt", partitionNTFS + @":\renamepptxFile.ppt", partitionNTFS + @":\renamertfFile.rtf", partitionNTFS + @":\renamepdfFile.pdf" };
            string docFile = partitionNTFS + @":\docFile.doc";
            string docxFile = partitionNTFS + @":\docxFile.docx";
            string xlsFile = partitionNTFS + @":\xlsFile.xls";
            string xlsxFile = partitionNTFS + @":\xlsxFile.xlsx";
            string pptFile = partitionNTFS + @":\pptFile.ppt";
            string pptxFile = partitionNTFS + @":\pptxFile.pptx";
            string rtfFile = partitionNTFS + @":\rtfFile.rtf";
            string pdfFile = partitionNTFS + @":\pdfFile.pdf";
            string sharedFile = partitionNTFS + @":\Shared\sharedFile.txt";
            string renameSharedFile = partitionNTFS + @":\Shared\renameSharedFile1.txt";
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            
            string dropboxFolderFile = @"C:\Users\" + currentlyLoggedUser + @"\Dropbox\testDropboxFile.txt";
            string OneDriveFolderFile = @"C:\Users\" + currentlyLoggedUser + @"\OneDrive\testOneDriveFile.txt";
            string renamedDropboxFolderFile = @"C:\Users\" + currentlyLoggedUser + @"\Dropbox\renamedtestDropboxFile.txt";
            string renamedOneDriveFolderFile = @"C:\Users\" + currentlyLoggedUser + @"\OneDrive\renamedtestOneDriveFile.txt";
            
            string largeFile = partitionNTFS + @":\largeFile.txt";
            string ieFile = partitionNTFS + @":\Browsers\ieFile.txt";
            string chromeFile = partitionNTFS + @":\Browsers\chromeFile.txt";
            string safariFile = partitionNTFS + @":\Browsers\safariFile.txt";
            string operaFile = partitionNTFS + @":\Browsers\operaFile.txt";
            string firefoxFile = partitionNTFS + @":\Browsers\firefoxFile.txt";
            string startPath = @"c:\Archive\Start";
            string zipPath = @"c:\Archive\result.zip";
            string renameExtensionFile = partitionNTFS + @":\renameExtension.txt";


           

            // Operations
            string fileCreation = "FileCreation";
            string fileRead = "FileRead";
            string fileWrite = "FileWrite";
            string fileRename = "FileRename";
            string fileDelete = "FileDelete";
            string fileCopy = "FileCopy";
            string fileArchive = "FileArchived";
            string fileAttributeChange = "FileAttributesChange";
            string fileSettingsChange = "FileSecurityChange";

            // Output data
            bool? operationResult = null;
            List<KeyValuePair<string, bool>> operationResultList = new List<KeyValuePair<string, bool>>();

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------PREPARE ENVIRONMENT-------");
            Utils.CreateDirectory(@"c:\Monitoring");
            Utils.CreateDirectory(@"c:\CopyFolder");
            Utils.CreateDirectory(@"c:\Archive");
            Utils.CreateDirectory(@"c:\Archive\Start");
            Utils.CreateSingleFile(@"c:\Archive\Start\arhiveFile1.txt");
            Utils.CreateFileWithSpecifiedLenght(@"c:\Archive\Start\arhiveFile1.txt", 0.100);
            Utils.CreateFileWithSpecifiedLenght(@"c:\Archive\Start\arhiveFile2.txt", 0.100);
            Utils.CreateFileWithSpecifiedLenght(@"c:\Archive\Start\arhiveFile3.txt", 0.100);
            Utils.CreateDirectory(partitionNTFS + @":\Monitoring");
            Utils.CreateDirectory(partitionNTFS + @":\Browsers");
            Utils.CreateDirectory(partitionFAT32 + @":\Monitoring");
            Utils.CreateDirectory(partitionNTFS + @":\Shared");
            Utils.QshareFolder(partitionNTFS + @":\Shared", "test", "test share");
            Utils.CreateSingleFile(renameExtensionFile);
            Console.WriteLine(@"C:\Users\" + currentlyLoggedUser + @"\Dropbox\");
           
           

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------EXECUTE FILE CREATION OPERATIONS-------");

            int testIndex = 1;

            Console.WriteLine(string.Empty);
            ///// Create a txt file in partition root C
            Console.WriteLine("TEST" + testIndex++ + ".  Create a single txt file in partition root C");
            Utils.CreateSingleFile(filePathRootC);

            Console.WriteLine(string.Empty);
            ///// Create a rtf file in partition root NTFS
            Console.WriteLine("TEST" + testIndex++ + ".  Create a rtf file in partition root NTFS");
            Utils.CreateSingleFile(rtfFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a pdf file in partition root b
            Console.WriteLine("TEST" + testIndex++ + ".  Create a pdf file in partition root b");
            Utils.CreateSingleFile(pdfFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a doc in partition root b
            Console.WriteLine("TEST" + testIndex++ + ".  Create a doc file in partition root b");
            Utils.CreateSingleFile(docFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a docx in partition root b
            Console.WriteLine("TEST" + testIndex++ + ".  Create a docx file in partition root b");
            Utils.CreateSingleFile(docxFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create an xls file in partition root b
            Console.WriteLine("TEST" + testIndex++ + ".  Create an xls file in partition root b");
            Utils.CreateSingleFile(xlsFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create an xlsx file in partition root b
            Console.WriteLine("TEST" + testIndex++ + ".  Create an xlsx file in partition root b");
            Utils.CreateSingleFile(xlsxFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a ppt in partition root b
            Console.WriteLine("TEST" + testIndex++ + ".  Create an ppt file in partition root b");
            Utils.CreateSingleFile(pptFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a pptx file in partition root b
            Console.WriteLine("TEST" + testIndex++ + ".  Create an pptx file in partition root b");
            Utils.CreateSingleFile(pptxFile);

            // TEST2. Create a single file in partition root B
            Console.WriteLine("TEST" + testIndex++ + ". Create a single file in partition root b");
            Utils.CreateSingleFile(fileRootNTFSPartition);

            // TEST3. Create a single file in partition root E
            Console.WriteLine("TEST" + testIndex++ + ". Create a single file in partition root E");
            Utils.CreateSingleFile(fileLocFAT23Partition);

            // TEST4. Create a single file in a folder in partition root C
            Console.WriteLine("TEST" + testIndex++ + ". Create a single file in a folder on drive C (NTFS)");
            Utils.CreateSingleFile(fileLocFolder1C);

            // TEST5. Create a single file in a folder in partition root B
            Console.WriteLine("TEST" + testIndex++ + ". Create a single file in a folder on drive B (NTFS)");
            Utils.CreateSingleFile(fileNTFSPartitionFolder1);

            // TEST6. Create a single file in a folder in partition root E
            Console.WriteLine("TEST" + testIndex++ + ". Create a single file in a folder on drive E (FAT32)");
            Utils.CreateSingleFile(fileFAT32PartitionFolder1);

            //// TEST7. Create a file with different characters in name
            Console.WriteLine("TEST" + testIndex++ + ". Create a file with different characters in name");
            Utils.CreateSingleFile(strangeName);

            //// TEST8. Create a file with a long name
            Console.WriteLine("TEST" + testIndex++ + ". Create a file with a long name");
            Utils.CreateSingleFile(longName);

            //// TEST9. Create a simple file
            Console.WriteLine("TEST" + testIndex++ + ". Create a simple file");
            Utils.CreateSingleFile(filesettings);

            //// TEST10. Create multiple files in the same folder
            Console.WriteLine("TEST" + testIndex++ + "TEST10. Create multiple files in the same folder");
            foreach (var file in multipleFiles)
            {
                Utils.CreateSingleFile(file);
            }

            ////// TEST11. Create a file with specified size
            //Console.WriteLine("TEST" + j++ + ". Create a file with specified size");
            //Utils.CreateFileWithSpecifiedLenght(largeFile, 10);
        
            ////Console.WriteLine(string.Empty);
            Console.WriteLine("-------EXECUTE FILE WRITE OPERATIONS-------");

            Console.WriteLine(string.Empty);
            //// TEST10. Write to a file from partition root C
            Console.WriteLine("TEST" + testIndex++ + ". Write to a file from partition root C");
            Utils.WriteSingleFile(filePathRootC);

            Console.WriteLine(string.Empty);
            ///// TEST1. Write to a rtf file in partition root b
            Console.WriteLine("TEST" + testIndex++ + ".  Write to a rtf file in partition root b");
            Utils.WriteSingleFile(rtfFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Write to a pdf file in partition root b
            Console.WriteLine("TEST" + testIndex++ + ".  Write to a pdf file in partition root b");
            Utils.WriteSingleFile(pdfFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a doc in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Write to a doc file in partition root b");
            Utils.WriteSingleFile(docFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a doc in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Write to a docx file in partition root b");
            Utils.WriteSingleFile(docxFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a doc in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Write to an xls file in partition root b");
            Utils.WriteSingleFile(xlsFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a doc in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Write to an xlsx file in partition root b");
            Utils.WriteSingleFile(xlsxFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a ppt in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Write to an ppt file in partition root b");
            Utils.WriteSingleFile(pptFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a pptx file in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Write to an pptx file in partition root b");
            Utils.WriteSingleFile(pptxFile);

            //// TEST11. Write to a file from partition root D
            Console.WriteLine("TEST" + testIndex++ + ". Write to a file from partition root B");
            Utils.WriteSingleFile(fileRootNTFSPartition);

            //// TEST12. Write to a file from partition root E
            Console.WriteLine("TEST" + testIndex++ + ". Write to a file from partition root E");
            Utils.WriteSingleFile(fileLocFAT23Partition);

            //// TEST13. Write to single file in a folder in partition root C
            Console.WriteLine("TEST" + testIndex++ + ". Write to single file in a folder in partition root C");
            Utils.WriteSingleFile(fileLocFolder1C);

            //// TEST14. Write to single file in a folder in partition root D
            Console.WriteLine("TEST" + testIndex++ + ". Write to single file in a folder in partition root B");
            Utils.WriteSingleFile(fileNTFSPartitionFolder1);

            //// TEST15. Write to single file in a folder in partition root E
            Console.WriteLine("TEST" + testIndex++ + ". Write to single file in a folder in partition root E");
            Utils.WriteSingleFile(fileFAT32PartitionFolder1);

            //// TEST10. Write to multiple files in the same folder
            Console.WriteLine("TEST" + testIndex++ + "TEST10. Write to multiple files in the same folder");
            foreach (var file in multipleFiles)
            {
                Utils.WriteSingleFile(file);
            } 

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------EXECUTE FILE READ OPERATIONS-------");

            Console.WriteLine(string.Empty);
            //// TEST16. Read a file from partition root C
            Console.WriteLine("TEST" + testIndex++ + ". Read a file from partition root C");
            Utils.ReadSingleFile(filePathRootC);

            Console.WriteLine(string.Empty);
            ///// TEST1. Read from rtf file in partition root b
            Console.WriteLine("TEST" + testIndex++ + ".  Read a rtf file in partition root b");
            Utils.ReadSingleFile(rtfFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Write to a pdf file in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Read a pdf file in partition root b");
            Utils.ReadSingleFile(pdfFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a doc in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Read a doc file in partition root b");
            Utils.ReadSingleFile(docFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a doc in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Read a docx file in partition root b");
            Utils.ReadSingleFile(docxFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a doc in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Read an xls file in partition root b");
            Utils.ReadSingleFile(xlsFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a doc in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Read an xlsx file in partition root b");
            Utils.ReadSingleFile(xlsxFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a ppt in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Read an ppt file in partition root b");
            Utils.ReadSingleFile(pptFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a pptx file in partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Read an pptx file in partition root b");
            Utils.ReadSingleFile(pptxFile);

            //// TEST17. Read a file from partition root D
            Console.WriteLine("TEST" + testIndex++ + ". Read a file from partition root D");
            Utils.ReadSingleFile(fileRootNTFSPartition);

            //// TEST18. Read a file from partition root E
            Console.WriteLine("TEST" + testIndex++ + ". Read a file from partition root E");
            Utils.ReadSingleFile(fileLocFAT23Partition);

            //// TEST19. Read from a single file in a folder in partition root C
            Console.WriteLine("TEST" + testIndex++ + ". Read from a single file in a folder in partition root C");
            Utils.ReadSingleFile(fileLocFolder1C);

            //// TEST20. Read from a single file in a folder in partition root D
            Console.WriteLine("TEST" + testIndex++ + ". Read from a single file in a folder in partition root D");
            Utils.ReadSingleFile(fileNTFSPartitionFolder1);

            //// TEST21. Read from a single file in a folder in partition root E
            Console.WriteLine("TEST" + testIndex++ + ". Read from a single file in a folder in partition root E");
            Utils.ReadSingleFile(fileFAT32PartitionFolder1);

            //// TEST22. Read multiple files
            Console.WriteLine("TEST" + testIndex++ + " Read multiple files from the same folder");
            foreach (var file in multipleFiles)
            {
                Utils.ReadSingleFile(file);
            } 

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------EXECUTE FILE RENAME OPERATIONS-------");

            Console.WriteLine(string.Empty);
            //// TEST22. Rename a file from partition root C
            Console.WriteLine("TEST" + testIndex++ + ". Rename a file from partition root C");
            Utils.RenameSingleFile(filePathRootC, renameFileLocRootC);

            Console.WriteLine(string.Empty);
            //// TEST22. Change file extension
            Console.WriteLine("TEST" + testIndex++ + ". Change file extension .txt with .jpeg");
            Utils.ChangeFileExtension(renameExtensionFile, ".jpeg");

            Console.WriteLine(string.Empty);
            //// TEST22. Rename a rtf file
            Console.WriteLine("TEST" + testIndex++ + ". Rename a rtf file from partition root B");
            Utils.RenameSingleFile(rtfFile, renameofficeFiles[7]);

            Console.WriteLine(string.Empty);
            //// TEST22. Rename a pdf file
            Console.WriteLine("TEST" + testIndex++ + ". Rename a pdf file from partition root B");
            Utils.RenameSingleFile(pdfFile, renameofficeFiles[8]);

            Console.WriteLine(string.Empty);
            //// TEST22. Rename a doc file
            Console.WriteLine("TEST" + testIndex++ + ". Rename a doc file from partition root B");
            Utils.RenameSingleFile(docFile, renameofficeFiles[0]);

            Console.WriteLine(string.Empty);
            //// TEST22. Rename a docx file
            Console.WriteLine("TEST" + testIndex++ + ". Rename a docx file from partition root B");
            Utils.RenameSingleFile(docxFile, renameofficeFiles[1]);

            Console.WriteLine(string.Empty);
            //// TEST22. Rename a xls file
            Console.WriteLine("TEST" + testIndex++ + ". Rename an xls file from partition root B");
            Utils.RenameSingleFile(xlsFile, renameofficeFiles[2]);

            Console.WriteLine(string.Empty);
            //// TEST22. Rename a xlsx file
            Console.WriteLine("TEST" + testIndex++ + ". Rename a xlsx file from partition root B");
            Utils.RenameSingleFile(xlsxFile, renameofficeFiles[3]);

            Console.WriteLine(string.Empty);
            //// TEST22. Rename a ppt file
            Console.WriteLine("TEST" + testIndex++ + ". Rename a ppt file from partition root B");
            Utils.RenameSingleFile(pptFile, renameofficeFiles[4]);

            Console.WriteLine(string.Empty);
            //// TEST22. Rename a pptx file
            Console.WriteLine("TEST" + testIndex++ + ". Rename a pptx file from partition root B");
            Utils.RenameSingleFile(pptxFile, renameofficeFiles[5]);

            Console.WriteLine(string.Empty);
            //// TEST22. Rename a file from partition root C
            Console.WriteLine("TEST" + testIndex++ + ". Rename a file from partition root C");
            Utils.RenameSingleFile(filePathRootC, renameFileLocRootC);

            //// TEST23. Rename a file from partition root b
            Console.WriteLine("TEST" + testIndex++ + ". Rename a file from partition root B");
            Utils.RenameSingleFile(fileRootNTFSPartition, renameFileRootNTFSPartition);

            //// TEST24. Rename a file from partition root E
            Console.WriteLine("TEST" + testIndex++ + ". Rename a file from partition root E");
            Utils.RenameSingleFile(fileLocFAT23Partition, renameFileRootFAT32Partition);

            //// TEST25. Rename a single file in a folder in partition root C
            Console.WriteLine("TEST" + testIndex++ + ". Rename a single file in a folder in partition root C");
            Utils.RenameSingleFile(fileLocFolder1C, renameFileLocFolder1C);

            //// TEST2. Rename a single file in a folder in partition root D
            Console.WriteLine("TEST" + testIndex++ + ". Rename a single file in a folder in partition root b");
            Utils.RenameSingleFile(fileNTFSPartitionFolder1, renameFileNTFSPartitionFolder1);

            //// TEST27. Rename a single file in a folder in partition root E
            Console.WriteLine("TEST" + testIndex++ + ". Rename a single file in a folder in partition root E");
            Utils.RenameSingleFile(fileFAT32PartitionFolder1, renameFileFAT32PartitionFolder1);

            //// TEST27. Rename multiple files
            Console.WriteLine("TEST" + testIndex++ + ". Rename multiple files");
           
            Utils.RenameSingleFile(multipleFiles[0], renamemultipleFiles[0]);
            Utils.RenameSingleFile(multipleFiles[1], renamemultipleFiles[1]);
            Utils.RenameSingleFile(multipleFiles[2], renamemultipleFiles[2]);
            Utils.RenameSingleFile(multipleFiles[3], renamemultipleFiles[3]);
            Utils.RenameSingleFile(multipleFiles[4], renamemultipleFiles[4]);

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------EXECUTE FILE OPERATIONS IN A SHARED FOLDER-------");

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Create a file in a shared folder");
            Utils.CreateSingleFile(sharedFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Write to a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Write to a file in a shared folder");
            Utils.WriteSingleFile(sharedFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Read a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Read a file in a shared folder");
            Utils.ReadSingleFile(sharedFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Read a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Rename a file in a shared folder");
            Utils.RenameSingleFile(sharedFile, renameSharedFile);

            Console.WriteLine(string.Empty);
            //// TEST30. Change file attributes, arhive only
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes arhive-only in a shared folder");
            Utils.SetArchive(renameSharedFile);

            Console.WriteLine(string.Empty);
            //// TEST31. Change file attributes, read-only
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes read-only in a shared folder");
            Utils.SetReadOnlyFile(renameSharedFile);

            Console.WriteLine(string.Empty);
            //// TEST33. Remove file attributes, hidden
            Console.WriteLine("TEST" + testIndex++ + ". Remove file attributes read-only in a shared folder");
            Utils.RemoveReadOnlyAttributes(renameSharedFile);

            Console.WriteLine(string.Empty);
            //// TEST32. Change file attributes, hidden
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes hidden in a shared folder");
            Utils.SetHiddenFile(renameSharedFile);

            Console.WriteLine(string.Empty);
            //// TEST33. Remove file attributes, hidden
            Console.WriteLine("TEST" + testIndex++ + ". Remove file attributes hidden in a shared folder");
            Utils.RemoveHiddenAttributes(renameSharedFile);

            Console.WriteLine(string.Empty);
            ////  TEST34. Add the access control entry to the file.
            Console.WriteLine("TEST" + testIndex++ + "Add the access control entry to the file in a shared folder.");
            Utils.AddFileSecurity(renameSharedFile, userName, FileSystemRights.FullControl, AccessControlType.Allow);

            Console.WriteLine(string.Empty);
            //// TEST34. Remove the access control entry from the file.
            Console.WriteLine("TEST" + testIndex++ + "Remove the access control entry to the file in a shared folder.");
            Utils.RemoveFileSecurity(renameSharedFile, userName, FileSystemRights.FullControl, AccessControlType.Allow);

            Console.WriteLine(string.Empty);
            // TEST29. Delete a file from a shared folder. 
            Console.WriteLine("TEST" + testIndex++ + ". Delete a file from a shared folder");
            Utils.DeleteSingleFile(renameSharedFile);



            Console.WriteLine(string.Empty);
            Console.WriteLine("-------EXECUTE FILE OPERATIONS IN A DROPBOX FOLDER-------");

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Create a file in dropbox folder");
            Utils.CreateSingleFile(dropboxFolderFile);

            Thread.Sleep(200);

            Console.WriteLine(string.Empty);
            ///// TEST1. Write to a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Write to a file in dropbox folder");
            Utils.WriteSingleFile(dropboxFolderFile);

            Thread.Sleep(200);

            Console.WriteLine(string.Empty);
            ///// TEST1. Read a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Read a file in dropbox folder");
            Utils.ReadSingleFile(dropboxFolderFile);

            Thread.Sleep(200);

            Console.WriteLine(string.Empty);
            ///// TEST1. Read a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Rename a file in dropbox folder");
            Utils.RenameSingleFile(dropboxFolderFile, renamedDropboxFolderFile);

            Thread.Sleep(200);

            Console.WriteLine(string.Empty);
            //// TEST30. Change file attributes, arhive only
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes arhive only in dropbox folder");
            Utils.SetArchive(renamedDropboxFolderFile);

            Thread.Sleep(200);

            Console.WriteLine(string.Empty);
            //// TEST31. Change file attributes, read-only
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes read-only in dropbox folder");
            Utils.SetReadOnlyFile(renamedDropboxFolderFile);

            Thread.Sleep(200);

            Console.WriteLine(string.Empty);
            //// TEST33. Remove file attributes, hidden
            Console.WriteLine("TEST" + testIndex++ + ". Remove file attributes read-only in dropbox folder");
            Utils.RemoveReadOnlyAttributes(renamedDropboxFolderFile);

            Thread.Sleep(200);

            Console.WriteLine(string.Empty);
            //// TEST32. Change file attributes, hidden
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes hidden in dropbox folder");
            Utils.SetHiddenFile(renamedDropboxFolderFile);

            Thread.Sleep(200);

            Console.WriteLine(string.Empty);
            //// TEST33. Remove file attributes, hidden
            Console.WriteLine("TEST" + testIndex++ + ". Remove file attributes hidden in dropbox folder");
            Utils.RemoveHiddenAttributes(renamedDropboxFolderFile);

            Thread.Sleep(200);

            Console.WriteLine(string.Empty);
            ////  TEST34. Add the access control entry to the file.
            Console.WriteLine("TEST" + testIndex++ + "Add the access control entry to the file.");
            Utils.AddFileSecurity(renamedDropboxFolderFile, userName, FileSystemRights.FullControl, AccessControlType.Allow);

            Thread.Sleep(200);

            Console.WriteLine(string.Empty);
            //// TEST34. Remove the access control entry from the file.
            Console.WriteLine("TEST" + testIndex++ + "Remove the access control entry to the file.");
            Utils.RemoveFileSecurity(renamedDropboxFolderFile, userName, FileSystemRights.FullControl, AccessControlType.Allow);

            Thread.Sleep(200);

            Console.WriteLine(string.Empty);
            // TEST29. Delete a file from dropbox folder. 
            Console.WriteLine("TEST" + testIndex++ + ". Delete a file from dropbox folder");
            Utils.DeleteSingleFile(renamedDropboxFolderFile);


            Console.WriteLine(string.Empty);
            Console.WriteLine("-------EXECUTE FILE OPERATIONS IN A ONEDRIVE FOLDER-------");

            Console.WriteLine(string.Empty);
            ///// TEST1. Create a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Create a file in OneDrive folder.");
            Utils.CreateSingleFile(OneDriveFolderFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Write to a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Write to a file in OneDrive folder.");
            Utils.WriteSingleFile(OneDriveFolderFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Read a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Read a file in OneDrive folder.");
            Utils.ReadSingleFile(OneDriveFolderFile);

            Console.WriteLine(string.Empty);
            ///// TEST1. Read a txt file in a shared folder
            Console.WriteLine("TEST" + testIndex++ + ".  Rename a file in OneDrive folder.");
            Utils.RenameSingleFile(OneDriveFolderFile, renamedOneDriveFolderFile);

            Console.WriteLine(string.Empty);
            //// TEST30. Change file attributes, arhive only
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes arhive only in OneDrive folder.");
            Utils.SetArchive(renamedOneDriveFolderFile);

            Console.WriteLine(string.Empty);
            //// TEST31. Change file attributes, read-only
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes read-only in OneDrive folder.");
            Utils.SetReadOnlyFile(renamedOneDriveFolderFile);

            Console.WriteLine(string.Empty);
            //// TEST33. Remove file attributes, hidden
            Console.WriteLine("TEST" + testIndex++ + ". Remove file attributes read-only in OneDrive folder.");
            Utils.RemoveReadOnlyAttributes(renamedOneDriveFolderFile);

            Console.WriteLine(string.Empty);
            //// TEST32. Change file attributes, hidden
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes hidden in OneDrive folder.");
            Utils.SetHiddenFile(renamedOneDriveFolderFile);

            Console.WriteLine(string.Empty);
            //// TEST33. Remove file attributes, hidden
            Console.WriteLine("TEST" + testIndex++ + ". Remove file attributes hidden in OneDrive folder.");
            Utils.RemoveHiddenAttributes(renamedOneDriveFolderFile);

            Console.WriteLine(string.Empty);
            ////  TEST34. Add the access control entry to the file.
            Console.WriteLine("TEST" + testIndex++ + "Add the access control entry to the file in OneDrive folder.");
            Utils.AddFileSecurity(renamedOneDriveFolderFile, userName, FileSystemRights.FullControl, AccessControlType.Allow);

            Console.WriteLine(string.Empty);
            //// TEST34. Remove the access control entry from the file.
            Console.WriteLine("TEST" + testIndex++ + "Remove the access control entry to the file in OneDrive folder.");
            Utils.RemoveFileSecurity(renamedOneDriveFolderFile, userName, FileSystemRights.FullControl, AccessControlType.Allow);

            Console.WriteLine(string.Empty);
            // TEST29. Delete a file from OneDrive folder. 
            Console.WriteLine("TEST" + testIndex++ + ". Delete a file from OneDrive folder");
            Utils.DeleteSingleFile(renamedOneDriveFolderFile);



            Console.WriteLine(string.Empty);
            Console.WriteLine("-------EXECUTE FILE COPY OPERATIONS-------");

            Console.WriteLine(string.Empty);
            //// TEST28. Copy a file 
            Console.WriteLine("TEST" + testIndex++ + ". Copy a file");
            Utils.CopySingleFile(filePathRootC, fileCopyDestination);

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------EXECUTE FILE DELETE-------");

            Console.WriteLine(string.Empty);
            // TEST29. Delete a file from partition root C
            Console.WriteLine("TEST" + testIndex++ + ". Delete a file from partition root C");
            Utils.DeleteSingleFile(renameFileRootNTFSPartition);

            Console.WriteLine(string.Empty);
            //// Delete office files
            Console.WriteLine("TEST" + testIndex++ + ". Delete office files from root B");
            foreach (var file in renameofficeFiles)
            {
                Utils.DeleteSingleFile(file);
            } 
             

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------EXECUTE FILE ATTRIBUTE CHANGE-------");

            Console.WriteLine(string.Empty);
            //// TEST30. Change file attributes, arhive only
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes, arhive only");
            Utils.SetArchive(filesettings);

            Console.WriteLine(string.Empty);
            //// TEST31. Change file attributes, read-only
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes, read-only");
            Utils.SetReadOnlyFile(filesettings);

            Console.WriteLine(string.Empty);
            //// TEST32. Change file attributes, hidden
            Console.WriteLine("TEST" + testIndex++ + ". Change file attributes, hidden");
            Utils.SetHiddenFile(filesettings);

            Console.WriteLine(string.Empty);
            //// TEST33. Change file attributes, hidden
            Console.WriteLine("TEST" + testIndex++ + ". Remove file attributes, all");
            Utils.RemoveAll(filesettings);

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------EXECUTE SECURITY CHANGE-------");

            Console.WriteLine(string.Empty);
            ////  TEST34. Add the access control entry to the file.
            Console.WriteLine("TEST" + testIndex++ + "Add the access control entry to the file.");
            Utils.AddFileSecurity(filesettings, userName, FileSystemRights.FullControl, AccessControlType.Allow);

            //// TEST34. Remove the access control entry from the file.
            Console.WriteLine("TEST" + testIndex++ + "Remove the access control entry to the file.");
            Utils.RemoveFileSecurity(filesettings, userName, FileSystemRights.FullControl, AccessControlType.Allow);

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------Open files in Browsers-------");

            Utils.CreateFileWithSpecifiedLenght(safariFile, 0.01);
            Utils.CreateFileWithSpecifiedLenght(ieFile, 0.200);
            Utils.CreateFileWithSpecifiedLenght(chromeFile, 0.100);
            Utils.CreateFileWithSpecifiedLenght(operaFile, 0.100);
            Utils.CreateFileWithSpecifiedLenght(firefoxFile, 0.100);

            Console.WriteLine(string.Empty);
            ////  Open file in IE browser.
            Console.WriteLine("TEST" + testIndex++ + "Open file in IE browser.");
            Utils.OpenFileInBrowser(ieFile, "iexplore.exe");

            Console.WriteLine(string.Empty);
            ////  Open file in Chrome browser.
            Console.WriteLine("TEST" + testIndex++ + "Open file in Chrome browser.");
            Utils.OpenFileInBrowser(chromeFile, "chrome.exe");

            Console.WriteLine(string.Empty);
            ////  Open file in Safari browser.
            Console.WriteLine("TEST" + testIndex++ + "Open file in Safari browser.");
            Utils.OpenFileInBrowser(safariFile, "safari.exe");

            Console.WriteLine(string.Empty);
            ////  Open file in Opera browser.
            Console.WriteLine("TEST" + testIndex++ + "Open file in Opera browser.");
            Utils.OpenFileInBrowser(operaFile, "opera.exe");

            Console.WriteLine(string.Empty);
            ////  Open file in Firefox browser.
            Console.WriteLine("TEST" + testIndex++ + "Open file in Firefox browser.");
            Utils.OpenFileInBrowser(firefoxFile, "firefox.exe");

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------CREATE,  AND OPEN ZIP ARCHIVES-------");

            Console.WriteLine(string.Empty);
            ////  Create ZIP archive.
            Console.WriteLine("TEST" + testIndex++ + "Create ZIP archive.");
            ZipFile.CreateFromDirectory(startPath, zipPath);

            Console.WriteLine("Sleep 3 min");
            Thread.Sleep(200000);

            File.Copy(csvPathOldPath, csvPath, true);
            int s = 1;
            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE CREATION OPERATIONS ARE MONITORED-------");

            //// Verify result in csv file: Create a single file in partition root C.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Create a single file in partition root C (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, filePathRootC, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a single file in partition root C (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Create a rtf file in partition root C.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Create a rtf file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, rtfFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a rtf file in partition root C (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Create a pdf file in partition root b (NTFS).
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Create a pdf file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, pdfFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a pdf file in partition root C (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Create a doc file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Create a doc file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, docFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a doc file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Create a docx file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Create a docx file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, docxFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a docx file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Create an xls file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Create an xls file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, xlsFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a xls file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Create an xlsx file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Create an xlsx file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, xlsxFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a xlsx file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Create an ppt file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Create an ppt file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, pptFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a ppt file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Create an pptx file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Create an pptx file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, pptxFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a pptx file in partition root B (NTFS) ", operationResult.Value));

            // Verify result in csv file: TEST2. Create a single file in partition root D.
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Create a single file in partition root B (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileRootNTFSPartition, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a single file in partition root D (NTFS)", operationResult.Value));

            // Verify result in csv file: TEST3. Create a single file in partition root E
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Create a single file in partition root E (FAT32)");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileLocFAT23Partition, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a single file in partition root E (FAT32) ", operationResult.Value));

            // Verify result in csv file: TEST4. Create a single file in a folder in partition root C
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Create a single file in a folder on drive C (NTFS) - monitored: " + operationResult);
            operationResult = Utils.GetFileNameandOperation(csvPath, fileLocFolder1C, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a single file in a folder on drive C (NTFS)", operationResult.Value));

            // Verify result in csv file: TEST5. Create a single file in a folder in partition root D
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Create a single file in a folder on drive B (NTFS) - monitored: " + operationResult);
            operationResult = Utils.GetFileNameandOperation(csvPath, fileNTFSPartitionFolder1, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a single file in a folder on drive D (NTFS)", operationResult.Value));

            // Verify result in csv file: TEST6. Create a single file in a folder in partition root E
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Create a single file in a folder on drive E (FAT32)- monitored: " + operationResult);
            operationResult = Utils.GetFileNameandOperation(csvPath, fileFAT32PartitionFolder1, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a single file in a folder on drive E (FAT32) ", operationResult.Value));

            // Verify result in csv file: TEST7. Create a file with different characters in name
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Create a file with different characters in name - monitored: " + operationResult);
            operationResult = Utils.GetFileNameandOperation(csvPath, strangeName, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a file with different characters in name", operationResult.Value));

            // Verify result in csv file: TEST8. Create file with a long name
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Create a file with a long name: " + operationResult);
            operationResult = Utils.GetFileNameandOperation(csvPath, longName, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a file with a long name", operationResult.Value));

            //// Verify result in csv file: TEST9. Create multiple files in a folder in partition root C.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Create multiple files in a folder in partition root C (NTFS)");
            foreach (var file in multipleFiles)
            {
                operationResult = Utils.GetFileNameandOperation(csvPath, file, fileCreation, 1, startAutomatedTestsTimestamp);
            }

            ////// Verify result in csv file: Create file with specified size.
            //Console.WriteLine(string.Empty);
            //Console.WriteLine("TEST. Create file with specified size.");
            //operationResult = Utils.GetFileNameandOperation(csvPath, largeFile, fileCreation, 1);
            //Console.WriteLine("Operation is monitored: " + operationResult);
            //operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a file with a specified size", operationResult.Value));
            

            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create multiple files in partition root C (NTFS) ", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE WRITE OPERATIONS ARE MONITORED-------");

            // Verify result in csv file: TEST9. Write to a file from partition root C
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Write to a file from partition root C");
            operationResult = Utils.GetFileNameandOperation(csvPath, filePathRootC, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ".Write to a single file in partition root C (NTFS)", operationResult.Value));

            //// Verify result in csv file: Write a rtf file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Write a rtf file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, rtfFile, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write to a rtf file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Write to a pdf file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Write to a pdf file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, pdfFile, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write to a pdf file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Write a doc file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Write a doc file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, docFile, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write a doc file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Write a docx file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Write a docx file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, docxFile, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write a docx file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Write an xls file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Write an xls file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, xlsFile, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write a xls file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Write an xlsx file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Write an xlsx file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, xlsxFile, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write a xlsx file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Write an ppt file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Write an ppt file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, pptFile, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write a ppt file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Write an pptx file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Write an pptx file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, pptxFile, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write a pptx file in partition root B (NTFS) ", operationResult.Value));

            // Verify result in csv file: TEST10. Write to a single file from partition root D
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Write to a single file from partition root D");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileRootNTFSPartition, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write to a single file in partition root D (NTFS)", operationResult.Value));

            // Verify result in csv file: TEST11. Write to a single file from partition root E
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Write to a single file from partition root E");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileLocFAT23Partition, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write to a single file in partition root E (FAT32)", operationResult.Value));

            // Verify result in csv file: TEST12. Write to a single file in a folder on drive C (NTFS)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Write to a single file in a folder on drive C (NTFS) " + operationResult);
            operationResult = Utils.GetFileNameandOperation(csvPath, fileLocFolder1C, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write to a single file in a folder on drive C (NTFS)", operationResult.Value));

            // Verify result in csv file: TEST13. Write to a single file in a folder on drive D (NTFS)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Write to a single file in a folder on drive D (NTFS) " + operationResult);
            operationResult = Utils.GetFileNameandOperation(csvPath, fileNTFSPartitionFolder1, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write to a single file in a folder on drive D (NTFS)", operationResult.Value));

            // Verify result in csv file: TEST14. Write to a single file in a folder on drive E (FAT32)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Write to a single file in a folder on drive E (FAT32) " + operationResult);
            operationResult = Utils.GetFileNameandOperation(csvPath, fileFAT32PartitionFolder1, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write to a single file in a folder on drive E (FAT32)", operationResult.Value));

            //// Verify result in csv file: TEST9. Create multiple files in a folder in partition root C.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Write multiple files in a folder in partition root C (NTFS)");
            foreach (var file in multipleFiles)
            {
                operationResult = Utils.GetFileNameandOperation(csvPath, file, fileWrite, 1, startAutomatedTestsTimestamp);
            }

            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write multiple files in partition root C (NTFS) ", operationResult.Value));

            ////// Verify result in csv file: Write to file with specified size.
            //Console.WriteLine(string.Empty);
            //Console.WriteLine("TEST. Write to a file with specified size.");
            //operationResult = Utils.GetFileNameandOperation(csvPath, largeFile, fileWrite, 1);
            //Console.WriteLine("Operation is monitored: " + operationResult);
            //operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write to a file with specified size", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE READ OPERATIONS ARE MONITORED-------");

            // Verify result in csv file: TEST15. Read from a single file in partition root C (NTFS)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Read a single file in partition root C (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, filePathRootC, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read from a single file in partition root C (NTFS)", operationResult.Value));

            //// Verify result in csv file: Read a rtf file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Read a rtf file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, rtfFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read a rtf file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Read a pdf file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Read a doc file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, pdfFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read a pdf file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Read a docx file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Read a docx file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, docxFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read a docx file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Read an xls file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Read an xls file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, xlsFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read a xls file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Read an xlsx file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Read an xlsx file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, xlsxFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read a xlsx file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Read an ppt file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Read an ppt file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, pptFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read a ppt file in partition root B (NTFS) ", operationResult.Value));

            //// Verify result in csv file: Read an pptx file in partition root b.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Read an pptx file in partition root b (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, pptxFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read a pptx file in partition root B (NTFS) ", operationResult.Value));

            // Verify result in csv file: TEST16. Read from a single file in partition root D (NTFS)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Read a single file in partition root D (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileRootNTFSPartition, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read from a single file in partition root D (NTFS)", operationResult.Value));

            // Verify result in csv file: TEST17. Read from a single file in partition root E (FAT32)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Read a single file in partition root E (FAT32)");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileLocFAT23Partition, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read from a single file in partition root E (FAT32)", operationResult.Value));

            // Verify result in csv file: TEST18. Read from a single file in a folder on drive C (NTFS)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Read a single file in a folder on drive C (NTFS) ");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileLocFolder1C, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read from a single file in a folder on drive C (NTFS) ", operationResult.Value));

            // Verify result in csv file: TEST19. Read from a single file in a folder on drive D (NTFS)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Read a single file in a folder on drive D (NTFS) ");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileNTFSPartitionFolder1, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read from a single file in a folder on drive D (NTFS) ", operationResult.Value));

            // Verify result in csv file: TEST20. Read from a single file in a folder on drive E (FAT32)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Read a single file in a folder on drive E (FAT32) ");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileFAT32PartitionFolder1, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read from a single file in a folder on drive E (FAT32) ", operationResult.Value));

            //// Verify result in csv file: TEST9. Create multiple files in a folder in partition root C.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Read multiple files in a folder in partition root C (NTFS)");
            foreach (var file in multipleFiles)
            {
                operationResult = Utils.GetFileNameandOperation(csvPath, file, fileRead, 1, startAutomatedTestsTimestamp);
            }

            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read multiple files in partition root C (NTFS) ", operationResult.Value));

            ////// Verify result in csv file: Read file with specified size.
            //Console.WriteLine(string.Empty);
            //Console.WriteLine("TEST. Read a file with specified size.");
            //operationResult = Utils.GetFileNameandOperation(csvPath, largeFile, fileRead, 1);
            //Console.WriteLine("Operation is monitored: " + operationResult);
            //operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read a file with specified size", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE RENAME TEST CASES-------");

            // Verify result in csv file: Rename a single file in partition root C (NTFS) 
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Rename a single file in partition root C (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, filePathRootC, fileRename, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Rename a single file in partition root C (NTFS)", operationResult.Value));

            // Verify result in csv file: Change file extension in partition root C (NTFS) 
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Change file extension in partition root C (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, renameFileLocRootC, fileRename, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file extension in partition root C (NTFS)", operationResult.Value));

            // Verify result in csv file: TEST22. Rename a single file in partition root D (NTFS)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Rename a single file in partition root D (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileRootNTFSPartition, fileRename, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Rename a single file in partition root D (NTFS)", operationResult.Value));

            // Verify result in csv file: TEST23. Rename a single file in partition root E (FAT32)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Rename a single file in partition root E (FAT32)");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileLocFAT23Partition, fileRename, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Rename a single file in partition root E (FAT32)", operationResult.Value));

            // Verify result in csv file: TEST24. Rename a single file in a folder on drive C (NTFS)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Rename a single file in a folder on drive C (NTFS) ");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileLocFolder1C, fileRename, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Rename a single file in a folder on drive C (NTFS)", operationResult.Value));

            // Verify result in csv file: TEST25. Rename a single file in a folder on drive D (NTFS)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Rename a single file in a folder on drive D (NTFS)");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileNTFSPartitionFolder1, fileRename, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Rename a single file in a folder on drive D (NTFS)", operationResult.Value));

            // Verify result in csv file: TEST26. Rename a single file in a folder on drive E (FAT32)
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Rename a single file in a folder on drive E (FAT32)");
            operationResult = Utils.GetFileNameandOperation(csvPath, fileFAT32PartitionFolder1, fileRename, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Rename a single file in a folder on drive E (FAT32)", operationResult.Value));

            //// Verify result in csv file: TEST9. Rename multiple files in a folder in partition root C.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Rename multiple files in a folder in partition root C (NTFS)");
            foreach (var file in multipleFiles)
            {
                operationResult = Utils.GetFileNameandOperation(csvPath, file, fileRename, 1, startAutomatedTestsTimestamp);
            }

            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Rename multiple files in partition root C (NTFS) ", operationResult.Value));

            //// Verify result in csv file: TEST9. Rename multiple files in a folder in partition root C.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Rename office files in a folder in partition root C (NTFS)");
            foreach (var file in renameofficeFiles)
            {
                operationResult = Utils.GetFileNameandOperation(csvPath, file, fileRename, 1, startAutomatedTestsTimestamp);
            }

            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Rename office files in partition root C (NTFS) ", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE OPERATIONS IN A SHARED FOLDER ARE MONITORED-------");

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Create a file in a shared folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, sharedFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a file in a shared folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Write to a file in a shared folder. ");
            operationResult = Utils.GetFileNameandOperation(csvPath, sharedFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write to a file in a shared folder", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Read a file in a shared folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, sharedFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read a file in a shared folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Rename a file in a shared folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, sharedFile, fileRename, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Rename a file in a shared folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Change file attributes, arhive only.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renameSharedFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (arhive only) in a shared folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Change file attributes, read-only.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renameSharedFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (read-only) in a shared folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Remove file attributes, read-only.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renameSharedFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Remove file attributes (read-only) in a shared folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Change file attributes, hidden.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renameSharedFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (hidden) in a shared folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Remove file attributes, hidden.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renameSharedFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Remove file attributes (hidden) in a shared folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Add the access control entry to the file.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renameSharedFile, fileSettingsChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Add the access control entry to the file.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Remove the access control entry to the file..");
            operationResult = Utils.GetFileNameandOperation(csvPath, renameSharedFile, fileSettingsChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Remove the access control entry to the file.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Delete a single file from a shared folder ");
            operationResult = Utils.GetFileNameandOperation(csvPath, renameSharedFile, fileDelete, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Delete a single file from a shared folder", operationResult.Value));

            

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE OPERATIONS IN DROPBOX FOLDER ARE MONITORED-------");


            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Create a file in dropbox folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, dropboxFolderFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a file in dropbox folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Write to a file in dropbox folder. ");
            operationResult = Utils.GetFileNameandOperation(csvPath, dropboxFolderFile, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write to a file in dropbox folder", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Read a file in dropbox folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, dropboxFolderFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read a file in dropbox folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Rename a file in dropbox folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, dropboxFolderFile, fileRename, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Rename a file in dropbox folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Change file attributes (arhive only).");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedDropboxFolderFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (arhive only) in a dropbox folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Change file attributes (read-only).");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedDropboxFolderFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (read-only) in a dropbox folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Remove file attributes (read-only).");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedDropboxFolderFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Remove file attributes (read-only) in a dropbox folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Change file attributes, hidden.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedDropboxFolderFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (hidden) in a dropbox folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Remove file attributes, hidden.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedDropboxFolderFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Remove file attributes (hidden) in a dropbox folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Add the access control entry to the file.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedDropboxFolderFile, fileSettingsChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Add the access control entry to the file in a dropbox folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Remove the access control entry to the file..");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedDropboxFolderFile, fileSettingsChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Remove the access control entry to the file in a dropbox folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Delete a single file from DropBox folder ");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedDropboxFolderFile, fileDelete, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Delete a single file from DropBox folder", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE OPERATIONS IN ONEDRIVE FOLDER ARE MONITORED-------");
            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Create a file in  OneDrive folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, OneDriveFolderFile, fileCreation, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Create a file in OneDrive folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Write to a file in OneDrive folder. ");
            operationResult = Utils.GetFileNameandOperation(csvPath, OneDriveFolderFile, fileWrite, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Write to a file in OneDrive folder", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Read a file in OneDrive folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, OneDriveFolderFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Read a file in OneDrive folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Rename a file in OneDrive folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, OneDriveFolderFile, fileRename, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Rename a file in OneDrive folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Change file attributes (arhive only) in OneDrive folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedOneDriveFolderFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (arhive only) in a OneDrive folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Change file attributes (read-only) in OneDrive folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedOneDriveFolderFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (read-only) in a OneDrive folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Remove file attributes (read-only) in OneDrive folder..");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedOneDriveFolderFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Remove file attributes (read-only) in a OneDrive folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Change file attributes (hidden) in OneDrive folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedOneDriveFolderFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (hidden) in a OneDrive folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Remove file attributes (hidden) in OneDrive folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedOneDriveFolderFile, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Remove file attributes (hidden) in a OneDrive folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Add the access control entry to the file.");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedOneDriveFolderFile, fileSettingsChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Add the access control entry to the file in a OneDrive folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Remove the access control entry to the file..");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedOneDriveFolderFile, fileSettingsChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Remove the access control entry to the file in  OneDrive folder.", operationResult.Value));

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Delete a single file from OneDrive folder ");
            operationResult = Utils.GetFileNameandOperation(csvPath, renamedOneDriveFolderFile, fileDelete, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Delete a single file from OneDrive folder", operationResult.Value));


            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE COPY OPERATION IS MONITORED-------");

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Copy file");
            operationResult = Utils.GetFileNameandOperation(csvPath, filePathRootC, fileCopy, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Copy file", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE DELETE OPERATION IS MONITORED-------");

            // Verify result in csv file
            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Delete a single file in partition root C (NTFS) ");
            operationResult = Utils.GetFileNameandOperation(csvPath, renameFileRootNTFSPartition, fileDelete, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Delete a single file from partition root C (NTFS)", operationResult.Value));

            //// Verify result in csv file: TEST9. Rename multiple files in a folder in partition root C.
            Console.WriteLine(string.Empty);
            Console.WriteLine("TEST. Delete office files in a folder in partition root b (NTFS)");
            foreach (var file in renameofficeFiles)
            {
                operationResult = Utils.GetFileNameandOperation(csvPath, file, fileDelete, 1, startAutomatedTestsTimestamp);
            }

            Console.WriteLine("Operation is monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Delete office files in partition root C (NTFS) ", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE ATTRIBUTE CHANGE IS MONITORED (ARHIVE ONLY)-------");

            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Verify change file attributes, arhive only");
            operationResult = Utils.GetFileNameandOperation(csvPath, filesettings, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (arhive only)", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE ATTRIBUTE CHANGE IS MONITORED (READ ONLY)-------");

            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Verify change file attributes, read only");
            operationResult = Utils.GetFileNameandOperation(csvPath, filesettings, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (read only)", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILE ATTRIBUTE CHANGE IS MONITORED (HIDDEN ONLY)-------");

            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Verify change file attributes, hidden only");
            operationResult = Utils.GetFileNameandOperation(csvPath, filesettings, fileAttributeChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Change file attributes (hidden only)", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY SECURITY CHANGE IS MONITORED-------");

            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Add the access control entry to the file.");
            operationResult = Utils.GetFileNameandOperation(csvPath, filesettings, fileSettingsChange, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Add the access control entry to the file.", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY FILES OPENED IN BROWSERS ARE MONITORED-------");

            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. File opened with Internet Explorer.");
            operationResult = Utils.GetFileNameandOperation(csvPath, ieFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". File opened with Internet Explorer.", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. File opened with Chrome.");
            operationResult = Utils.GetFileNameandOperation(csvPath, chromeFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". File opened with Chrome.", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. File opened with Safari.");
            operationResult = Utils.GetFileNameandOperation(csvPath, safariFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". File opened with Safari.", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. File opened with Opera.");
            operationResult = Utils.GetFileNameandOperation(csvPath, operaFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". File opened with Opera.", operationResult.Value));


            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. File opened with Firefox.");
            operationResult = Utils.GetFileNameandOperation(csvPath, firefoxFile, fileRead, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". File opened with Firefox.", operationResult.Value));

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------VERIFY ARCHIVED FILES ARE MONITORED-------");

            Console.WriteLine(string.Empty);
            Console.WriteLine("VERIFY TEST. Archive a folder.");
            operationResult = Utils.GetFileNameandOperation(csvPath, startPath, fileArchive, 1, startAutomatedTestsTimestamp);
            Console.WriteLine("Operation was monitored: " + operationResult);
            operationResultList.Add(new KeyValuePair<string, bool>("TEST" + s++ + ". Archive a folder. ", operationResult.Value));

            
            Console.WriteLine(string.Empty);
            Console.WriteLine("-------CLEAN ENVIROMENT-------");

            Console.WriteLine(string.Empty);
            Console.WriteLine("Delete folders and files");
            Directory.Delete(@"c:\Monitoring", true);
            Directory.Delete(@"c:\CopyFolder", true);
            Directory.Delete(@"c:\Archive", true);
            Directory.Delete(partitionNTFS + @":\Monitoring", true);
            Directory.Delete(partitionNTFS + @":\Browsers", true);
            Directory.Delete(partitionNTFS + @":\Shared", true);
            Directory.Delete(partitionFAT32 + @":\Monitoring", true);

            File.Delete(filesettings);
            File.Delete(renameExtensionFile);
            File.Delete(partitionNTFS + @":\renameExtension.jpeg");
            File.Delete(partitionFAT32 + @":\renametestFile.txt");
            File.Delete(renameFileLocRootC);
            File.Delete(csvPath);
            

            Console.WriteLine(string.Empty);
            Console.WriteLine("-------------------------Test Results-----------------------------------------");

            List<string> headers = new List<string> { "Computer name", "Operating System", "Timestamp", "Test Name", "Test Result" };
            List<string> passed = new List<string>();
            List<string> failed = new List<string>();
            List<string> alltests = new List<string>();
            List<string> results = new List<string>();
            string machineName = Environment.MachineName.ToString();
            ComputerInfo computerInfo = new ComputerInfo();
            string osName = computerInfo.OSFullName;
            DateTime now = DateTime.Now;
            List<string> os = new List<string> { osName };
            List<string> machine = new List<string> { machineName };
            List<string> hour = new List<string> { now.ToString() };

            Console.WriteLine(string.Empty);
            Console.WriteLine("All Operations");
            for (int i = 0; i < operationResultList.Count; i++)
            {
                    Console.WriteLine(operationResultList[i].Key);
                    results.Add(operationResultList[i].Value.ToString());
                    
                    
            }
            
            string os11 = os.FirstOrDefault();
            string machine111 = machine.FirstOrDefault();
            string timestamp = hour.FirstOrDefault();
           
            var columns = new Dictionary<int, List<string>>();
            int currentLineIndex = 1;
            foreach (var test in operationResultList)
            {
                var currentLine = new List<string>() { machine111, os11, timestamp, test.Key , test.Value.ToString() };
                columns.Add(currentLineIndex, currentLine);
                currentLineIndex++;
            }
            Utils.AddCSVColumns(headers, columns);

            Thread.Sleep(60000);
            
        }
    }
}