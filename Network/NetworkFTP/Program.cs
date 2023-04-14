using System;
using System.IO;
using System.Net;

class FtpFileTransfer
{
    static void Main(string[] args)
    {
        string ftpServerUrl = "ftp://ftpupload.net/";
        string ftpUsername = "epiz_34011387";
        string ftpPassword = "dF6hP8T8HE";


        //Upload Directories
        string uploadLocalFilePath = "/Users/krmli/Downloads/AliTate.png";
        string uploadRemoteFilePath = "/htdocs/AliTate.png";

        //Download Directories
        string downloadLocalFilePath = "/Users/krmli/Downloads/AliTate2.png";
        string downloadRemoteFilePath = "/htdocs/AliTate.png";

        Console.WriteLine("Upload:");
        UploadFileToFTP(ftpServerUrl, ftpUsername, ftpPassword, uploadLocalFilePath, uploadRemoteFilePath);

        Console.WriteLine("\nDownload:");
        DownloadFileFromFTP(ftpServerUrl, ftpUsername, ftpPassword, downloadRemoteFilePath, downloadLocalFilePath);
    }

    static void UploadFileToFTP(string ftpServerUrl, string ftpUsername, string ftpPassword, string localFilePath, string remoteFilePath)
    {
        try
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServerUrl + remoteFilePath);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            request.UseBinary = true;
            request.KeepAlive = false;

            Console.WriteLine("Successful connection!");

            using (Stream localFileStream = File.OpenRead(localFilePath))
            using (Stream ftpStream = request.GetRequestStream())
            {
                localFileStream.CopyTo(ftpStream);
            }

            Console.WriteLine("File upload successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("File upload failed. " + ex.Message);
        }
    }

    static void DownloadFileFromFTP(string ftpServerUrl, string ftpUsername, string ftpPassword, string remoteFilePath, string localFilePath)
    {
        try
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServerUrl + remoteFilePath);

            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            request.UseBinary = true;
            request.KeepAlive = false;

            Console.WriteLine("Successful connection!");

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream ftpStream = response.GetResponseStream())
            using (Stream localFileStream = File.Create(localFilePath))
            {
                ftpStream.CopyTo(localFileStream);
            }

            Console.WriteLine("File download successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("File download failed. " + ex.Message);
        }
    }
}
