namespace test.netcore.Model
{
    public class fileModel
    {
        public string fileName { get; set; }
        public IFormFile formFile { get; set; }
        public string fileType { get; set; }

        //IF I were to insert request for MULTIPLE FILES, the code would be:
        //public List<IFormFile> formFiles { get; set; }

    }
}
