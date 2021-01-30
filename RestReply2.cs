
namespace NameDayRestClient
{
    public class RestReply2
    {
        public int error_code { get; set; }
        public string error_string { get; set; }

        public int czech_sensitive { get; set; }
        public int case_sensitive { get; set; }

        public string[] data { get; set; }

        public RestReply2()
        {
            error_code = -999;
        }
    }
}
