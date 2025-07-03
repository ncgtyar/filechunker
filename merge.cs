List<byte> bytes = new List<byte>();
foreach (string file in parts) //For each part, parts is a string array consisting of the file paths
{
    foreach (byte b in File.ReadAllBytes(file)) //For each byte in part
        bytes.Add(b); //Append every byte, and so the original file is built. Make sure to put in the correct order
}
SaveFileDialog sfd = new SaveFileDialog();
if (sfd.ShowDialog() == DialogResult.OK)
{
    File.WriteAllBytes(sfd.FileName, bytes.ToArray()); //File saved with the selection from SaveFileDialog
}
