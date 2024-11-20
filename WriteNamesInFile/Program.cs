namespace WriteNamesInFile;

public class WriteNamesInFile
{
    public static void Main()
    {
        // get the path of the current folder
        string currentPath = Directory.GetCurrentDirectory();
        string? projectPathBase = Directory.GetParent(currentPath)?.Parent?.Parent?.FullName;

        // Set the files folder path
        string? projectPathFiles = Directory.GetParent(currentPath)?.Parent?.Parent?.FullName + "\\Files\\";

        //string[] files = Directory.GetFiles(projectPathFiles, "*.cs");

        //if (files.Count() == 0)
        //{
        //    CreateFiles(projectPathFiles);
        //}
        DirectoryInfo d = new DirectoryInfo(projectPathFiles);

        IEnumerable<string> fileNames = d.GetFiles("*.cs").Select(x => x.Name.Replace(".cs", ""));
        WriteFileNamesInTxt(fileNames, projectPathBase);

    }
    public static void CreateFiles(string projectPathFiles)
    {
        for (int i = 0; i < 10; i++)
        {
            string projectPath = projectPathFiles + $"file{i}.cs";
            File.WriteAllText(projectPath, $@"
                namespace WriteNamesInFile.Files;
                public class Class{i}
                {{
                }}
                ");
        }
    }

    public static string WriteFileNamesInTxt(IEnumerable<string> fileNames, string projectPathFiles)
    {
        string projectPath = projectPathFiles + "fileNames.txt";
        //foreach (string fileName in fileNames)
        //{
        //}
            File.AppendAllLines(projectPath, fileNames);

        return "";
    }
}

