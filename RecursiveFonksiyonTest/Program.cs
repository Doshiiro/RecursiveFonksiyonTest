using System.IO;

List<FileInfo> files = DosyaYazdir("C:/Program Files/dotnet");
foreach (FileInfo file in files)
    Console.WriteLine(file.FullName);



List<FileInfo> DosyaYazdir(string path)
{
    List<FileInfo> fileInfos = new();
    DirectoryInfo directoryInfo = new(path);
    DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
    if (directoryInfos.Any())
        foreach (DirectoryInfo directory in directoryInfos)
            fileInfos.AddRange(DosyaYazdir(directory.FullName));

    else
        fileInfos.AddRange(directoryInfo.GetFiles());
    return fileInfos;
}