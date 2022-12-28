namespace Platform.Services.Storage.Helpers;

public class StorageHelper
{
    protected delegate bool HasFile(string path, string fileName);

    protected async Task<string> FileRenameAsync(string path, string fileName, HasFile hasFile, bool first = true)
    {
        string newFileName = await Task.Run(async () =>
        {
            string extension = Path.GetExtension(fileName);
            string newFileName = string.Empty;
            if (first)
            {
                string oldName = Path.GetFileNameWithoutExtension(fileName);
                newFileName = $"{FileRenameHelper.Rename(oldName)}{extension}";
            }
            else
            {
                newFileName = fileName;
                int index1 = newFileName.IndexOf("-");
                if (index1 == -1)
                    newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
                else
                {
                    int lIndex = 0;
                    while (true)
                    {
                        lIndex = index1;
                        index1 = newFileName.IndexOf("-", index1 + 1);
                        if (index1 == -1)
                        {
                            index1 = lIndex;
                            break;
                        }
                    }
                    int index2 = newFileName.IndexOf(".");
                    string no = newFileName.Substring(index1 + 1, index2 - index1 - 1);
                    if (int.TryParse(no, out int _no))
                    {
                        _no++;
                        newFileName = newFileName.Remove(index1 + 1, index2 - index1 - 1).Insert(index1 + 1, _no.ToString());
                    }
                    else
                        newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
                }
            }
            if (hasFile(path, newFileName))
                return await FileRenameAsync(path, newFileName, hasFile, false);
            else
                return newFileName;
        });
        return newFileName;
    }
}
