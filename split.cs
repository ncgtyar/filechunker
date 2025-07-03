try
{
    string file = "";
    if (File.Exists(path))
        file = path;
    byte[] bytes = File.ReadAllBytes(file);
    long partSize = 8L * 1024L * 1024L;
    int partCount = (int)Math.Ceiling((double)bytes.Length / partSize);
    int partIndex = 0;

    if (partCount == 1)
    {
        //No chunking needed
    }
    else
    {
        for (int i = 0; i < partCount; i++)
        {
            int startIndex = i * (int)partSize;
            int endIndex = Math.Min(startIndex + (int)partSize, bytes.Length);
            byte[] partBytes = new byte[endIndex - startIndex];
            Array.Copy(bytes, startIndex, partBytes, 0, partBytes.Length);
            MemoryStream stream = new MemoryStream(partBytes);
            //Do whatever you want with the part loaded into the stream
            partIndex++; //For keeping track of the part number, can be used like $"{filename}_part{partIndex}"
        }
    }
}
catch (Exception ex)
{
    MessageBox.Show(ex.ToString());
}
