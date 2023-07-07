using System;

namespace Jarai.Refactoring.Drucker.Original
{
    public class PdfCreator
    {
        private readonly string _pdfFilename;

        public PdfCreator()
        {
            
        }

        public PdfCreator(string pdfFilename)
        {
            _pdfFilename = pdfFilename;
        }

        public virtual void CreatePdfFile(string text)
        {
            Console.WriteLine("Pdf erstellt: {0}", text);
        }
    }
}