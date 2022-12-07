using System.Collections.Immutable;
using System.Drawing;

namespace AdventOfCode;

public class Day07
{
    private Dictionary<string, Dictionary<string, int>> _fileSystem = new Dictionary<string, Dictionary<string, int>>();
    private Dictionary<string, int> _folderSizes = new Dictionary<string, int>();

    public void Parse(string input)
    {
        var lines = input.Replace("/", "\\").Split(Environment.NewLine);
        PrepareFileSystem(lines);
    }

    private int RecursiveFolderSize(string path)
    {
        return _folderSizes.Where(x => x.Key.Contains(path)).Sum(x => x.Value);
    }

    private void PrepareFileSystem(string[] lines)
    {
        var currentPath = Path.GetFullPath("\\");
        var filesInCurrentFolder = new Dictionary<string, int>();

        foreach (var line in lines)
        {
            // command
            var cmd = line.Split(' ').ToArray();
            switch (cmd[0])
            {
                case "$":
                    switch (cmd[1])
                    {
                        case "cd":
                            // consolidate current folder
                            ConsolidateCurrentPath(currentPath, filesInCurrentFolder);

                            if (cmd[2] == "..")
                            {
                                currentPath = Directory.GetParent(currentPath).FullName;
                            }
                            else
                            {
                                currentPath = Path.GetFullPath(Path.Combine(currentPath, cmd[2]));
                            }
                            break;
                        case "ls": break;
                    }
                    break;

                default:
                    // this is a file listing
                    if (cmd[0].StartsWith("dir"))
                    {
                        continue;
                    }
                    filesInCurrentFolder.Add(cmd[1], int.Parse(cmd[0]));
                    break;
            }
        }

        if (filesInCurrentFolder.Any())
        {
            ConsolidateCurrentPath(currentPath, filesInCurrentFolder);
        }
    }

    private void ConsolidateCurrentPath(string currentPath, Dictionary<string, int> filesInCurrentFolder)
    {
        if (!_fileSystem.ContainsKey(currentPath))
        {
            _fileSystem.Add(currentPath, new Dictionary<string, int>());
            _folderSizes.Add(currentPath, 0);
        }

        foreach (var file in filesInCurrentFolder)
        {
            _fileSystem[currentPath].Add(file.Key, file.Value);
        }

        // calculate ONLY the current folder size
        _folderSizes[currentPath] = _fileSystem[currentPath].Sum(x => x.Value);

        filesInCurrentFolder.Clear(); // current folder means something else now
    }

    public int Day07Part1()
    {
        var absoluteSizes = new Dictionary<string, int>();
        foreach (var item in _fileSystem)
        {
            var size = RecursiveFolderSize(item.Key);
            absoluteSizes.Add(item.Key, size);
        }

        return absoluteSizes.Select(x => x.Value).Where(x => x <= 100000).Sum();
    }

    public int Day07Part2()
    {
        var totalSize = new Dictionary<string, int>();
        foreach (var item in _fileSystem)
        {
            var size = RecursiveFolderSize(item.Key);
            totalSize.Add(item.Key, size);
        }
        totalSize = totalSize.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        var freeSpace = 70000000 - totalSize.Last().Value;
        var target = 30000000 - freeSpace;

        var smallestOver = totalSize.Values.Where(folder => folder >= target).Min();

        return smallestOver;
    }

    //public string Day07Part2(string input)
    //{
    //    var items = Parse(input);

    //    foreach (var item in items)
    //    {


    //    }

    //    return
    //}
}
