using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.IO;

namespace DataLibrary
{
    public class UploadFile
    {
        public IList<IBrowserFile> SelectedFiles { get; set; }

        public string Message = "Nie wybrano plików";

        public string FolderName { get; set; }

        public string FolderPath { get; set; }

        public double[] Progress { get; set; } = { 0 };




        public int Mb { get; set; } = 10;


        public void OnInputFileChange(InputFileChangeEventArgs e)
        {
            SelectedFiles = (IList<IBrowserFile>)e.GetMultipleFiles();
            Message = $"{SelectedFiles.Count} wybrane pliki";
        }

        public async void SaveImageTo()
        {
            System.IO.Directory.CreateDirectory(FolderPath + "\\Pictures\\" + FolderName);
            long MaxBit = (1024 * 1024 * Mb);

            for (int i = 0; i < SelectedFiles.Count; i++)
            {
                Stream stream = SelectedFiles[i].OpenReadStream(MaxBit);
                FileStream fs = File.Create(FolderPath + "\\Pictures\\" + FolderName + "\\" + SelectedFiles[i].Name);
                await stream.CopyToAsync(fs);
                stream.Close();
                fs.Close();
            }
            Message = $"{SelectedFiles.Count} Pliki zostały wysłane";
        }








    }
}