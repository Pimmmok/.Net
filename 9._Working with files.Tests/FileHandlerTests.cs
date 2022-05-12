using NUnit.Framework;
using System.IO.Abstractions.TestingHelpers;
using System.Windows.Documents;
using System.IO;
using System;

namespace _9._Working_with_files.Tests
{
    public class FileHandlerTests

    {
        [TestCase(@"C:\temp\data.txt", "ABC")]
        [TestCase(@"C:\temp\pim.txt", "Hello! File open!")]
        [TestCase(@"C:\temp\123.rtf", "Hello! File open!")]
        public void OpenToFile_TextInFile_ShouldBeReadCorrectly(string fileName, string textInDocument)
        {
            MockFileSystem mockFileSystem = new MockFileSystem();
            MockFileData mockInputFile = new MockFileData(textInDocument);
            mockFileSystem.AddFile(fileName, mockInputFile);
            FlowDocument flowDocument = new FlowDocument();
            TextRange document = new TextRange(flowDocument.ContentStart, flowDocument.ContentStart)
            {
                Text = textInDocument
            };
            FileHandler fileHandler = new FileHandler(mockFileSystem);
            fileHandler.OpenToFile(fileName, document);
            Assert.AreEqual(mockInputFile.TextContents, document.Text);
        }

        [Test]
        public void OpenToFile_TestException_ShouldBeFileNotFoundException()
        {
            MockFileSystem mockFileSystem = new MockFileSystem();
            FlowDocument flowDocument = new FlowDocument();
            TextRange document = new TextRange(flowDocument.ContentStart, flowDocument.ContentStart);
            FileHandler fileHandler = new FileHandler(mockFileSystem);
            Exception ex = Assert.Throws<FileNotFoundException>(() => fileHandler.OpenToFile("C:\\1234.txt", document));
            Assert.That(ex.Message, Is.EqualTo("Could not find file 'C:\\1234.txt'."));
            Assert.That(ex.Data["Filename"], Is.EqualTo("C:\\1234.txt"));
            Assert.That(ex.Data["Operation"], Is.EqualTo("Open"));
        }

        [Test]
        public void OpenToFile_TestException_ShouldBeDirectoryNotFoundException()
        {
            MockFileSystem mockFileSystem = new MockFileSystem();
            FlowDocument flowDocument = new FlowDocument();
            TextRange document = new TextRange(flowDocument.ContentStart, flowDocument.ContentStart);
            FileHandler fileHandler = new FileHandler(mockFileSystem);
            Exception ex = Assert.Throws<DirectoryNotFoundException>(() => fileHandler.OpenToFile("C:\\123\\1.txt", document));
            Assert.That(ex.Message, Is.EqualTo("Could not find a part of the path 'C:\\123\\1.txt'."));
            Assert.That(ex.Data["Filename"], Is.EqualTo("C:\\123\\1.txt"));
            Assert.That(ex.Data["Operation"], Is.EqualTo("Open"));
        }

        [Test]
        public void OpenToFile_TestException_ShouldBeIOException()
        {
            MockFileSystem mockFileSystem = new MockFileSystem();
            FlowDocument flowDocument = new FlowDocument();
            MockFileData mockInputFile = new MockFileData("ABC")
            {
                AllowedFileShare = FileShare.None
            };
            mockFileSystem.AddFile("C:\\123.txt", mockInputFile);
            TextRange document = new TextRange(flowDocument.ContentStart, flowDocument.ContentStart);
            FileHandler fileHandler = new FileHandler(mockFileSystem);
            Exception ex = Assert.Throws<IOException>(() => fileHandler.OpenToFile("C:\\123.txt", document));
            Assert.That(ex.Message, Is.EqualTo("The process cannot access the file 'C:\\123.txt' because it is being used by another process."));
            Assert.That(ex.Data["Filename"], Is.EqualTo("C:\\123.txt"));
            Assert.That(ex.Data["Operation"], Is.EqualTo("Open"));
        }

        [TestCase(@"C:\temp\data.txt", "ABC")]
        [TestCase(@"C:\temp\pim.txt", "Hello! File save!")]
        [TestCase(@"C:\temp\123.txt", "Hello! File save!")]
        public void SaveToFile_TextInFile_ShouldBeReadCorrectly(string fileName, string textInDocument)
        {
            MockFileSystem mockFileSystem = new MockFileSystem();
            FlowDocument flowDocument = new FlowDocument();
            TextRange document = new TextRange(flowDocument.ContentStart, flowDocument.ContentStart)
            {
                Text = textInDocument
            };
            FileHandler fileHandler = new FileHandler(mockFileSystem);
            fileHandler.SaveToFile(fileName, document);
            MockFileData mockInputFile = mockFileSystem.GetFile(fileName);
            Assert.AreEqual(document.Text, mockInputFile.TextContents);
        }

        [Test]
        public void SaveToFile_TestException_ShouldBeDirectoryNotFoundException()
        {
            MockFileSystem mockFileSystem = new MockFileSystem();
            mockFileSystem.AddDirectory("C:\\temp");
            FlowDocument flowDocument = new FlowDocument();
            TextRange doc = new TextRange(flowDocument.ContentStart, flowDocument.ContentStart)
            {
                Text = "Hello!"
            };
            FileHandler fileHandler = new FileHandler(mockFileSystem);
            Exception ex = Assert.Throws<DirectoryNotFoundException>(() => fileHandler.SaveToFile("C:\\123\\1.txt", doc));
            Assert.That(ex.Message, Is.EqualTo("Could not find a part of the path 'C:\\123\\1.txt'."));
            Assert.That(ex.Data["Filename"], Is.EqualTo("C:\\123\\1.txt"));
            Assert.That(ex.Data["Operation"], Is.EqualTo("Save"));
        }

        [Test]
        public void SaveToFile_TestException_ShouldBeIOException()
        {
            MockFileSystem mockFileSystem = new MockFileSystem();
            MockFileData mockInputFile = new MockFileData("ABC")
            {
                AllowedFileShare = FileShare.None
            };
            mockFileSystem.AddFile("C:\\123.txt", mockInputFile);
            FlowDocument flowDocument = new FlowDocument();
            TextRange doc = new TextRange(flowDocument.ContentStart, flowDocument.ContentStart)
            {
                Text = "Hello!"
            };
            FileHandler fileHandler = new FileHandler(mockFileSystem);
            Exception ex = Assert.Throws<IOException>(() => fileHandler.SaveToFile("C:\\123.txt", doc));
            Assert.That(ex.Message, Is.EqualTo("The process cannot access the file 'C:\\123.txt' because it is being used by another process."));
            Assert.That(ex.Data["Filename"], Is.EqualTo("C:\\123.txt"));
            Assert.That(ex.Data["Operation"], Is.EqualTo("Save"));
        }
    }
}