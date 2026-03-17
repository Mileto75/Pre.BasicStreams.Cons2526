// See https://aka.ms/new-console-template for more information
Console.WriteLine("Basic streams");
var pathToDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Pre", "Secrets");
//check if directory exists
if(!Directory.Exists(pathToDirectory))
{
    Directory.CreateDirectory(pathToDirectory);
}
var fullPathToFile = Path.Combine(pathToDirectory, "Users.csv");
//check if file exists
Console.WriteLine(pathToDirectory);
if(!File.Exists(fullPathToFile))
{
    File.Create(fullPathToFile);
}
try
{
    //open a stream; old school way
    FileStream fileStream = new FileStream(fullPathToFile, FileMode.Open);
    var charByte = fileStream.ReadByte();
    while(charByte != -1)
    {
        Console.Write((char)charByte);
        charByte = fileStream.ReadByte();
    }
    fileStream.Dispose();
}
catch(FileNotFoundException fileNotFoundException)
{
    Console.WriteLine(fileNotFoundException.Message);
}

StreamReader streamReader = new StreamReader(fullPathToFile);
Console.WriteLine(streamReader.ReadToEnd());
