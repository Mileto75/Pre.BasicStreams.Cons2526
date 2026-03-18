// See https://aka.ms/new-console-template for more information
using System.Text;

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
//how to write to a file
//old skool style
try 
{
    FileStream fileStream = new FileStream(fullPathToFile, FileMode.Open);
    string user = "69,Karel,Soete,Langestraat 69 8000 Brugge\r\n";
    var byteEncoded = Encoding.UTF8.GetBytes(user);
    //find method to point to a newline.
    fileStream.Write(byteEncoded);
    fileStream.Dispose();
}
catch(IOException iOException)
{
    Console.WriteLine(iOException.Message);
}
//StreamWriter => new skool way
try
{
    //using statement block = auto dispose
    using StreamWriter streamWriter = new StreamWriter(fullPathToFile, true);
    {
        string user = "69,Karel,Soete,Langestraat 69 8000 Brugge";
        streamWriter.WriteLine(user);
        //calling Dispose() is unnecessary
        //streamWriter.Dispose();
    }
}
catch (IOException iOxception)
{
    Console.WriteLine(iOxception.Message);
}
try
{
    //new school way
    StreamReader streamReader = new StreamReader(fullPathToFile);
    Console.WriteLine(streamReader.ReadToEnd());
}
catch (IOException iOexception)
{
    Console.WriteLine(iOexception.Message);
}


