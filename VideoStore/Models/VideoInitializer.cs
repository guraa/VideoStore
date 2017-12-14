using System;
using System.Collections.Generic;
using System.Data.Entity;
using VideoStore.Controllers;
using System.IO;
using System.Linq;
using System.Web;

namespace VideoStore.Models
{

    public class VideoInitializer : DropCreateDatabaseIfModelChanges<VideoContext>
    {
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;
            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);
            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        protected override void Seed(VideoContext context)
        {
            var video = new List<VideoModels>
            {
                new VideoModels{id=1234, description= "Star Wars: Episod I – Det mörka hotet är en amerikansk science fiction-film som hade biopremiär i USA 1999, skriven och regisserad av George Lucas", genre="Science fiction", price=205, title="Star Wars: Episod I – Det mörka hotet", Image = ReadFile("C:\\Users\\gusegn\\Desktop\\VisualStudio\\Projects\\VideoStore\\VideoStore\\Star_Wars.jpg") },
                new VideoModels{id=2345, description="Bad Santa är en amerikansk långfilm från 2003 i regi av Terry Zwigoff, med Billy Bob Thornton, Tony Cox, Brett Kelly och Lauren Graham i rollerna", genre="Komedi", price=99, title="Bad Santa"}
            };
            foreach(var item in video)
            {
                context.Video.Add(item);
            }
            context.SaveChanges();
        }
    }
}