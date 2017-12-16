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
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        protected override void Seed(VideoContext context)
        {
            var video = new List<VideoModels>
            {
                new VideoModels{description="Star Wars: Episod I – Det mörka hotet är en amerikansk science fiction-film som hade biopremiär i USA 1999, skriven och regisserad av George Lucas", genre="Science fiction", price=205, title="Star Wars: Episod I – Det mörka hotet", Image = ReadFile("C:\\Users\\Gustav\\Source\\Repos\\VideoStore\\VideoStore\\Star_Wars.jpg") },
                new VideoModels{description="Bad Santa är en amerikansk långfilm från 2003 i regi av Terry Zwigoff, med Billy Bob Thornton, Tony Cox, Brett Kelly och Lauren Graham i rollerna", genre="Komedi", price=99, title="Bad Santa", Image = ReadFile("C:\\Users\\Gustav\\Source\\Repos\\VideoStore\\VideoStore\\badsanta.jpg")},
                new VideoModels{description="Ensam hemma är en amerikansk komedifilm från 1990 i regi av Chris Columbus med Macaulay Culkin, Joe Pesci och Daniel Stern i huvudrollerna. Filmen hade biopremiär i USA den 16 november 1990 och Sverigepremiär den 14 december samma år.", genre="Komedi", price=99, title="Ensam Hemma", Image = ReadFile("C:\\Users\\Gustav\\Source\\Repos\\VideoStore\\VideoStore\\ensamhemma.jpg")},
                new VideoModels{description="Elf är en tysk-amerikansk julinspirerad komedifilm från 2003, med Will Ferrell i huvudrollen. Regisserad av Jon Favreau", genre="Komedi", price=99, title="Elf", Image = ReadFile("C:\\Users\\Gustav\\Source\\Repos\\VideoStore\\VideoStore\\elf.jpg")},
                new VideoModels{description="The Holiday är en amerikansk romantisk komedi från 2006 i regi av Nancy Meyers med Cameron Diaz, Kate Winslet, Jude Law och Jack Black i huvudrollerna. Filmen hade världspremiär den 6 december 2006, och utspelar sig under julhelgen.", genre="Komedi", price=99, title="The Holiday", Image = ReadFile("C:\\Users\\Gustav\\Source\\Repos\\VideoStore\\VideoStore\\holiday.jpg")},
                new VideoModels{description="Nu är det jul igen är en amerikansk familjefilm från 1994 i regi av John Pasquin. Huvudrollen Scott Calvin spelas av Tim Allen, en helt vanlig man som råkar ut för att jultomten ramlar ner från hans tak på julafton.", genre="Komedi", price=99, title="Nu är det jul igen", Image = ReadFile("C:\\Users\\Gustav\\Source\\Repos\\VideoStore\\VideoStore\\juligen.jpg")},
                new VideoModels{description="Ett päron till farsa firar jul är en amerikansk komedifilm från 1989 i regi av Jeremiah S. Chechik. I huvudrollerna som familjen Griswold ses Chevy Chase, Beverly D'Angelo, Juliette Lewis och Johnny Galecki.", genre="Komedi", price=99, title="Ett päron till farsa firar jul", Image = ReadFile("C:\\Users\\Gustav\\Source\\Repos\\VideoStore\\VideoStore\\pear.jpg")},
                new VideoModels{description="Polarexpressen är en amerikansk animerad långfilm i regi av Robert Zemeckis. Den hade allmän biopremiär i USA den 10 november 2004.", genre="Komedi", price=99, title="Polarexpressen", Image = ReadFile("C:\\Users\\Gustav\\Source\\Repos\\VideoStore\\VideoStore\\polar.jpg")},

            };
            foreach(var item in video)
            {
                context.Video.Add(item);
            }
            context.SaveChanges();
        }
    }
}