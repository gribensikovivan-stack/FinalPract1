using System;
using System.Collections.Generic;

namespace FinalPract1
{
    static class FileRepository
    {
        public static List<FileItem> GetMockFiles()
        {
            return new List<FileItem>
            {
                new FileItem { Name = "Ajaccgdo", Size = 41739, DateModified = new DateTime(2002,10,11,19,48,0), IsDirectory = false },
                new FileItem { Name = "nc", Size = 0, DateModified = new DateTime(2002,10,11,19,48,0), IsDirectory = true },
                new FileItem { Name = "nc_exit", Size = 1200, DateModified = new DateTime(2002,10,11,19,48,0), IsDirectory = false },
                new FileItem { Name = "telemax", Size = 128380, DateModified = new DateTime(1995,5,25,5,0,0), IsDirectory = false },
                new FileItem { Name = "bitmap", Size = 54613, DateModified = new DateTime(1995,5,25,5,0,0), IsDirectory = false },
                new FileItem { Name = "ansi2866", Size = 255, DateModified = new DateTime(1995,5,25,5,0,0), IsDirectory = false },
                new FileItem { Name = "MyFileWithLongName.txt", Size = 2048, DateModified = new DateTime(2002,10,11,19,48,0), IsDirectory = false },
                new FileItem { Name = "readme.txt", Size = 1024, DateModified = new DateTime(2000,1,1,12,0,0), IsDirectory = false },
                new FileItem { Name = "docs", Size = 0, DateModified = new DateTime(2001,2,2,14,30,0), IsDirectory = true },
                new FileItem { Name = "setup.exe", Size = 589824, DateModified = new DateTime(1999,5,15,8,45,0), IsDirectory = false },
                new FileItem { Name = "autoexec.bat", Size = 512, DateModified = new DateTime(1995,7,10,6,0,0), IsDirectory = false },
                new FileItem { Name = "config.sys", Size = 384, DateModified = new DateTime(1995,7,10,6,0,0), IsDirectory = false },
                new FileItem { Name = "games", Size = 0, DateModified = new DateTime(2003,3,3,17,20,0), IsDirectory = true },
                new FileItem { Name = "music", Size = 0, DateModified = new DateTime(2003,3,3,17,21,0), IsDirectory = true },
                new FileItem { Name = "video", Size = 0, DateModified = new DateTime(2003,3,3,17,22,0), IsDirectory = true },
                new FileItem { Name = "notes.doc", Size = 12288, DateModified = new DateTime(2004,4,4,10,15,0), IsDirectory = false },
                new FileItem { Name = "report.xls", Size = 32768, DateModified = new DateTime(2004,4,4,11,0,0), IsDirectory = false },
                new FileItem { Name = "archive.zip", Size = 204800, DateModified = new DateTime(2005,5,5,9,45,0), IsDirectory = false },
                new FileItem { Name = "src", Size = 0, DateModified = new DateTime(2006,6,6,13,10,0), IsDirectory = true },
                new FileItem { Name = "main.cpp", Size = 4096, DateModified = new DateTime(2006,6,6,13,15,0), IsDirectory = false },
                new FileItem { Name = "program.cs", Size = 8192, DateModified = new DateTime(2006,6,6,13,20,0), IsDirectory = false },
                new FileItem { Name = "script.py", Size = 3072, DateModified = new DateTime(2006,6,6,13,25,0), IsDirectory = false },
                new FileItem { Name = "data.db", Size = 1048576, DateModified = new DateTime(2007,7,7,16,0,0), IsDirectory = false },
                new FileItem { Name = "backup", Size = 0, DateModified = new DateTime(2007,7,7,16,5,0), IsDirectory = true },
                new FileItem { Name = "images", Size = 0, DateModified = new DateTime(2008,8,8,14,0,0), IsDirectory = true },
                new FileItem { Name = "photo1.jpg", Size = 204800, DateModified = new DateTime(2008,8,8,14,15,0), IsDirectory = false },
                new FileItem { Name = "photo2.png", Size = 305600, DateModified = new DateTime(2008,8,8,14,20,0), IsDirectory = false },
                new FileItem { Name = "logs", Size = 0, DateModified = new DateTime(2009,9,9,10,0,0), IsDirectory = true },
                new FileItem { Name = "system.log", Size = 65536, DateModified = new DateTime(2009,9,9,10,5,0), IsDirectory = false },
                new FileItem { Name = "kernel.log", Size = 32768, DateModified = new DateTime(2009,9,9,10,10,0), IsDirectory = false },
                new FileItem { Name = "temp", Size = 0, DateModified = new DateTime(2010,10,10,12,0,0), IsDirectory = true },
                new FileItem { Name = "tmp1.tmp", Size = 5120, DateModified = new DateTime(2010,10,10,12,10,0), IsDirectory = false },
                new FileItem { Name = "tmp2.tmp", Size = 6144, DateModified = new DateTime(2010,10,10,12,15,0), IsDirectory = false },
                new FileItem { Name = "downloads", Size = 0, DateModified = new DateTime(2011,11,11,9,0,0), IsDirectory = true },
                new FileItem { Name = "installer.msi", Size = 7340032, DateModified = new DateTime(2011,11,11,9,30,0), IsDirectory = false },
                new FileItem { Name = "drivers", Size = 0, DateModified = new DateTime(2012,12,12,18,0,0), IsDirectory = true },
                new FileItem { Name = "printer.drv", Size = 10240, DateModified = new DateTime(2012,12,12,18,10,0), IsDirectory = false },
                new FileItem { Name = "sound.drv", Size = 20480, DateModified = new DateTime(2012,12,12,18,15,0), IsDirectory = false },
                new FileItem { Name = "bin", Size = 0, DateModified = new DateTime(2013,1,1,7,0,0), IsDirectory = true },
                new FileItem { Name = "tool.exe", Size = 40960, DateModified = new DateTime(2013,1,1,7,10,0), IsDirectory = false },
                new FileItem { Name = "update.com", Size = 20480, DateModified = new DateTime(2013,1,1,7,20,0), IsDirectory = false },
                new FileItem { Name = "readme.md", Size = 2048, DateModified = new DateTime(2014,2,2,11,0,0), IsDirectory = false },
                new FileItem { Name = "LICENSE", Size = 1024, DateModified = new DateTime(2014,2,2,11,5,0), IsDirectory = false },
                new FileItem { Name = "Makefile", Size = 512, DateModified = new DateTime(2014,2,2,11,10,0), IsDirectory = false },
                new FileItem { Name = "build", Size = 0, DateModified = new DateTime(2015,3,3,16,0,0), IsDirectory = true },
                new FileItem { Name = "release", Size = 0, DateModified = new DateTime(2015,3,3,16,5,0), IsDirectory = true },
                new FileItem { Name = "changelog.txt", Size = 8192, DateModified = new DateTime(2015,3,3,16,10,0), IsDirectory = false },
                new FileItem { Name = "old", Size = 0, DateModified = new DateTime(2016,4,4,19,0,0), IsDirectory = true },
                new FileItem { Name = "trash", Size = 0, DateModified = new DateTime(2017,5,5,20,0,0), IsDirectory = true },
                new FileItem { Name = "desktop.ini", Size = 256, DateModified = new DateTime(2017,5,5,20,5,0), IsDirectory = false },
                new FileItem { Name = "config.json", Size = 3072, DateModified = new DateTime(2018,6,6,21,0,0), IsDirectory = false },
                new FileItem { Name = "appsettings.xml", Size = 4096, DateModified = new DateTime(2018,6,6,21,5,0), IsDirectory = false }
            };
        }
    }
}
